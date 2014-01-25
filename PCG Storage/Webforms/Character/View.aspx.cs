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

                if (character.LightArmors == 2)
                    checkboxLightArmors.Checked = true;
                else if (character.LightArmors == 1)
                    checkboxLightArmors.Checked = false;
                else
                    checkboxLightArmors.Visible = false;

                if (character.HeavyArmors == 2)
                    checkboxHeavyArmors.Checked = true;
                else if (character.HeavyArmors == 1)
                    checkboxHeavyArmors.Checked = false;
                else
                    checkboxHeavyArmors.Visible = false;

                if (character.Weapons == 2)
                    checkboxWeapons.Checked = true;
                else if (character.Weapons == 1)
                    checkboxWeapons.Checked = false;
                else
                    checkboxWeapons.Visible = false;

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

                var possibleHandSize = new List<KeyValuePair<int, bool>>();
                for (var i = character.HandSize + 1; i <= character.PossibleHandSize; i++)
                {
                    if (character.SelectedHandSize.HasValue && character.SelectedHandSize.Value >= i)
                        possibleHandSize.Add(new KeyValuePair<int, bool>(i, true));
                    else
                        possibleHandSize.Add(new KeyValuePair<int, bool>(i, false));
                }
                repeaterHandSize.DataSource = possibleHandSize;
                repeaterHandSize.DataBind();

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

        protected void RepeaterHandSize_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var item = (KeyValuePair<int, bool>)e.Item.DataItem;

                var checkboxHandSizeSelected = (CheckBox)e.Item.FindControl("checkboxHandSizeSelected");
                checkboxHandSizeSelected.Text = "+" + item.Key.ToString();
                checkboxHandSizeSelected.Checked = item.Value;

                var hiddenPossibleHandSizeValue = (HiddenField)e.Item.FindControl("hiddenPossibleHandSizeValue");
                hiddenPossibleHandSizeValue.Value = item.Key.ToString();
            }
        }

        protected void CheckboxHandSizeSelected_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            var hiddenPossibleHandSize = (HiddenField)checkbox.Parent.FindControl("hiddenPossibleHandSizeValue");
            var selectedHandSizeValue = Convert.ToInt32(hiddenPossibleHandSize.Value);

            var characterId = Convert.ToInt32(Page.RouteData.Values["characterid"]);
            var character = PcgManager.Dto.Character.Get(characterId);

            var repeater = (Repeater)checkbox.Parent.Parent;
            var repeaterItems = (RepeaterItemCollection)repeater.Items;

            var counter = character.HandSize + 1;
            foreach (RepeaterItem item in repeater.Items)
            {
                var innerCheckbox = (CheckBox)item.FindControl("checkboxHandSizeSelected");
                if (counter < selectedHandSizeValue) innerCheckbox.Checked = true;
                if (counter > selectedHandSizeValue) innerCheckbox.Checked = false;

                counter++;
            }
            
            if (checkbox.Checked)
            {
                character.SelectedHandSize = selectedHandSizeValue;
                character.Update();
            }
            else
            {
                character.SelectedHandSize = selectedHandSizeValue - 1;
                character.Update();
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

            var counter = 1;
            foreach (RepeaterItem item in repeater.Items)
            {
                var innerCheckbox = (CheckBox)item.FindControl("checkboxSkillSelected");
                if (counter < selectedSkillValue) innerCheckbox.Checked = true;
                if (counter > selectedSkillValue) innerCheckbox.Checked = false;

                counter++;
            }

            if (checkbox.Checked)
                PcgManager.Dto.Skill.Set(characterId, skillId, selectedSkillValue);
            else
                PcgManager.Dto.Skill.Set(characterId, skillId, selectedSkillValue - 1);
        }

        protected void CheckboxLightArmors_CheckedChanged(object sender, EventArgs e)
        {
            var characterId = Convert.ToInt32(Page.RouteData.Values["characterid"]);

            var character = PcgManager.Dto.Character.Get(characterId);
            
            if (checkboxLightArmors.Visible)
                character.LightArmors = 0;
            else if (!checkboxLightArmors.Checked)
                character.LightArmors = 1;
            else
                character.LightArmors = 2;

            character.Update();
        }

        protected void CheckboxHeavyArmors_CheckedChanged(object sender, EventArgs e)
        {
            var characterId = Convert.ToInt32(Page.RouteData.Values["characterid"]);

            var character = PcgManager.Dto.Character.Get(characterId);

            if (checkboxHeavyArmors.Visible)
                character.HeavyArmors = 0;
            else if (!checkboxHeavyArmors.Checked)
                character.HeavyArmors = 1;
            else
                character.HeavyArmors = 2;

            character.Update();
        }

        protected void CheckboxWeapons_CheckedChanged(object sender, EventArgs e)
        {
            var characterId = Convert.ToInt32(Page.RouteData.Values["characterid"]);

            var character = PcgManager.Dto.Character.Get(characterId);

            if (checkboxWeapons.Visible)
                character.Weapons = 0;
            else if (!checkboxWeapons.Checked)
                character.Weapons = 1;
            else
                character.Weapons = 2;

            character.Update();
        }
    }
}