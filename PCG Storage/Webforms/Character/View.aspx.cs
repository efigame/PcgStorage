using Pcg_Storage.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pcg_Storage.Webforms.Character
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = Convert.ToInt32(Page.RouteData.Values["userid"]);
            var partyId = Convert.ToInt32(Page.RouteData.Values["partyid"]);
            var characterId = Convert.ToInt32(Page.RouteData.Values["characterid"]);

            if (!Page.IsPostBack)
            {
                var party = PcgManager.Dto.Party.Get(partyId);
                var character = party.Characters.SingleOrDefault(c => c.Id == characterId);

                literalCharacterName.Text = character.Name;
                literalPartyName.Text = party.Name;
                literalHandSize.Text = character.HandSize.ToString();

                checkboxLightArmors.Checked = character.LightArmors;
                checkboxHeavyArmors.Checked = character.HeavyArmors;
                checkboxWeapons.Checked = character.Weapons;

                literalWeaponCards.Text = character.WeaponCards.ToString();
                literalSpellCards.Text = character.SpellCards.ToString();
                literalArmorCards.Text = character.ArmorCards.ToString();
                literalItemCards.Text = character.ItemCards.ToString();
                literalAllyCards.Text = character.AllyCards.ToString();
                literalBlessingCards.Text = character.BlessingCards.ToString();

                repeaterExtraPowers.DataSource = character.Powers;
                repeaterExtraPowers.DataBind();

                repeaterSkills.DataSource = character.Skills;
                repeaterSkills.DataBind();
            }

            linkEditCharacter.NavigateUrl = Url.PartyCharacterEdit(userId, partyId, characterId);
            linkGoToPartyView.NavigateUrl = Url.Party(userId, partyId);
        }

        protected void RepeaterSkills_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var skill = (PcgManager.Dto.Skill)e.Item.DataItem;

                var literalSkillName = (Literal)e.Item.FindControl("literalSkillName");
                literalSkillName.Text = skill.Name;

                var literalSkillDice = (Literal)e.Item.FindControl("literalSkillDice");
                literalSkillDice.Text = "d" + skill.Dice.ToString();

                var hiddenSkillId = (HiddenField)e.Item.FindControl("hiddenSkillId");
                hiddenSkillId.Value = skill.Id.ToString();

                var possibleSkills = new List<KeyValuePair<int, bool>>();
                for(var i = 1; i <= skill.PossibleAddons; i++)
                {
                    if (skill.SelectedAddons >= i)
                        possibleSkills.Add(new KeyValuePair<int, bool>(i, true));
                    else
                        possibleSkills.Add(new KeyValuePair<int, bool>(i, false));
                }

                var repeaterPossibleSkill = (Repeater)e.Item.FindControl("repeaterPossibleSkill");
                repeaterPossibleSkill.DataSource = possibleSkills;
                repeaterPossibleSkill.DataBind();

                var repeaterSubSkills = (Repeater)e.Item.FindControl("repeaterSubSkills");
                repeaterSubSkills.DataSource = skill.SubSkills;
                repeaterSubSkills.DataBind();
            }
        }

        protected void RepeaterSkills_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void RepeaterSubSkills_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var skill = (PcgManager.Dto.SubSkill)e.Item.DataItem;

                var literalSubSkillName = (Literal)e.Item.FindControl("literalSubSkillName");
                literalSubSkillName.Text = skill.Name;

                var literalSubSkillAdjustment = (Literal)e.Item.FindControl("literalSubSkillAdjustment");
                literalSubSkillAdjustment.Text = "+" + skill.Adjustment.ToString();
            }
        }

        protected void RepeaterSubSkills_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void RepeaterExtraPowers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var power = (PcgManager.Dto.Power)e.Item.DataItem;

                var literalText = (Literal)e.Item.FindControl("literalText");
                literalText.Text = power.Text;
            }
        }

        protected void RepeaterPossibleSkill_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var item = (KeyValuePair<int, bool>)e.Item.DataItem;

                var checkboxSkillSelected = (CheckBox)e.Item.FindControl("checkboxSkillSelected");
                checkboxSkillSelected.Text = "+" + item.Key.ToString();
                checkboxSkillSelected.Checked = item.Value;

                var hiddenPossibleSkillValue = (HiddenField)e.Item.FindControl("hiddenPossibleSkillValue");
                hiddenPossibleSkillValue.Value = item.Key.ToString();
            }
        }

        protected void CheckboxSkillSelected_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            var hiddenPossibleSkill = (HiddenField)checkbox.Parent.FindControl("hiddenPossibleSkillValue");
            var selectedSkillValue = Convert.ToInt32(hiddenPossibleSkill.Value);

            var characterId = Convert.ToInt32(Page.RouteData.Values["characterid"]);

            var hiddenSkillId = (HiddenField)checkbox.Parent.Parent.Parent.FindControl("hiddenSkillId");
            var skillId = Convert.ToInt32(hiddenSkillId.Value);

            var repeater = (Repeater)checkbox.Parent.Parent;
            var repeaterItems = (RepeaterItemCollection)repeater.Items;

            for(int i = 0; i < repeater.Items.Count; i++)
            {
                if (i < selectedSkillValue - 1)
                {
                    var innerCheckbox = (CheckBox)repeaterItems[i].FindControl("checkboxSkillSelected");
                    innerCheckbox.Checked = true;
                }
                else if (i == selectedSkillValue - 1)
                {
                    if (checkbox.Checked)
                        PcgManager.Dto.Skill.Set(characterId, skillId, selectedSkillValue);
                    else
                        PcgManager.Dto.Skill.Set(characterId, skillId, selectedSkillValue - 1);
                }
                else
                {
                    var innerCheckBox = (CheckBox)repeaterItems[i].FindControl("checkboxSkillSelected");
                    innerCheckBox.Checked = false;
                }
            }
        }

        protected void CheckboxLightArmors_CheckedChanged(object sender, EventArgs e)
        {
            var characterId = Convert.ToInt32(Page.RouteData.Values["characterid"]);

            var character = PcgManager.Dto.Character.Get(characterId);
            character.LightArmors = checkboxLightArmors.Checked;

            character.Update();
        }

        protected void CheckboxHeavyArmors_CheckedChanged(object sender, EventArgs e)
        {
            var characterId = Convert.ToInt32(Page.RouteData.Values["characterid"]);

            var character = PcgManager.Dto.Character.Get(characterId);
            character.HeavyArmors = checkboxHeavyArmors.Checked;

            character.Update();
        }

        protected void CheckboxWeapons_CheckedChanged(object sender, EventArgs e)
        {
            var characterId = Convert.ToInt32(Page.RouteData.Values["characterid"]);

            var character = PcgManager.Dto.Character.Get(characterId);
            character.Weapons = checkboxWeapons.Checked;

            character.Update();
        }
    }
}