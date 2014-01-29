using Pcg_Storage.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pcg_Storage.Webforms.Character
{
    public partial class Edit : System.Web.UI.Page
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

                if (!checkboxLightArmors.Visible && !checkboxHeavyArmors.Visible && !checkboxWeapons.Visible)
                    panelProficiencies.Visible = false;

                literalFavoredCardType.Text = character.FavoredCardType;
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

                var possibleHandSize = GetPossibleValues(character.HandSize, character.PossibleHandSize, character.SelectedHandSize);
                repeaterHandSize.DataSource = possibleHandSize;
                repeaterHandSize.DataBind();

                var possibleWeaponCards = GetPossibleValues(character.WeaponCards, character.PossibleWeaponCards, character.SelectedWeaponCards);
                repeaterPossibleWeaponCards.DataSource = possibleWeaponCards;
                repeaterPossibleWeaponCards.DataBind();

                var possibleSpellCards = GetPossibleValues(character.SpellCards, character.PossibleSpellCards, character.SelectedSpellCards);
                repeaterPossibleSpellCards.DataSource = possibleSpellCards;
                repeaterPossibleSpellCards.DataBind();

                var possibleArmorCards = GetPossibleValues(character.ArmorCards, character.PossibleArmorCards, character.SelectedArmorCards);
                repeaterPossibleArmorCards.DataSource = possibleArmorCards;
                repeaterPossibleArmorCards.DataBind();

                var possibleItemCards = GetPossibleValues(character.ItemCards, character.PossibleItemCards, character.SelectedItemCards);
                repeaterPossibleItemCards.DataSource = possibleItemCards;
                repeaterPossibleItemCards.DataBind();

                var possibleAllyCards = GetPossibleValues(character.AllyCards, character.PossibleAllyCards, character.SelectedAllyCards);
                repeaterPossibleAllyCards.DataSource = possibleAllyCards;
                repeaterPossibleAllyCards.DataBind();

                var possibleBlessingCards = GetPossibleValues(character.BlessingCards, character.PossibleBlessingCards, character.SelectedBlessingCards);
                repeaterPossibleBlessingCards.DataSource = possibleBlessingCards;
                repeaterPossibleBlessingCards.DataBind();
            }

            linkEditCharacter.NavigateUrl = Url.PartyCharacterEdit(userId, partyId, characterId);
            linkGoToPartyView.NavigateUrl = Url.Party(userId, partyId);
        }

        private List<KeyValuePair<int, bool>> GetPossibleValues(int baseValue, int possibleValue, int? selectedValue)
        {
            var possibleValues = new List<KeyValuePair<int, bool>>();

            for (var i = baseValue + 1; i <= possibleValue; i++)
            {
                if (selectedValue.HasValue && selectedValue.Value >= i)
                    possibleValues.Add(new KeyValuePair<int, bool>(i, true));
                else
                    possibleValues.Add(new KeyValuePair<int, bool>(i, false));
            }

            return possibleValues;
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
                for (var i = 1; i <= skill.PossibleAddons; i++)
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
        protected void RepeaterExtraPowers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var power = (PcgManager.Dto.Power)e.Item.DataItem;

                string[] powerlist = power.Text.Split(new string[] { "{format:check}" }, StringSplitOptions.None);

                var literalExtraPowerText = (Literal)e.Item.FindControl("literalExtraPowerText");
                literalExtraPowerText.Text = powerlist[0];

                var hiddenExtraPowerId = (HiddenField)e.Item.FindControl("hiddenExtraPowerId");
                hiddenExtraPowerId.Value = power.Id.ToString();

                var checkboxlist = (CheckBoxList)e.Item.FindControl("checkboxListExtraPower");
                checkboxlist.RepeatDirection = RepeatDirection.Horizontal;
                checkboxlist.RepeatLayout = RepeatLayout.Flow;

                for (var i = 1; i < powerlist.Count(); i++)
                {
                    var itemIsChecked = false;
                    if ((i & power.SelectedPowers) == i)
                    {
                        itemIsChecked = true;
                    }

                    var item = new ListItem(powerlist[i], i.ToString(), true);
                    item.Selected = itemIsChecked;

                    checkboxlist.Items.Add(item);
                }
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
        protected void RepeaterPossibleCards_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var item = (KeyValuePair<int, bool>)e.Item.DataItem;

                var checkboxSelected = (CheckBox)e.Item.FindControl("checkboxSelected");
                checkboxSelected.Text = "+" + item.Key.ToString();
                checkboxSelected.Checked = item.Value;

                var hiddenValue = (HiddenField)e.Item.FindControl("hiddenValue");
                hiddenValue.Value = item.Key.ToString();
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
        protected void CheckboxWeaponCardSelected_CheckedChanged(object sender, EventArgs e)
        {
            var characterId = Convert.ToInt32(Page.RouteData.Values["characterid"]);
            var character = PcgManager.Dto.Character.Get(characterId);

            character.SelectedWeaponCards = GetSelectedValue(sender, e, character);
            character.Update();
        }
        protected void CheckboxSpellCardSelected_CheckedChanged(object sender, EventArgs e)
        {
            var characterId = Convert.ToInt32(Page.RouteData.Values["characterid"]);
            var character = PcgManager.Dto.Character.Get(characterId);

            character.SelectedSpellCards = GetSelectedValue(sender, e, character);
            character.Update();
        }
        protected void CheckboxArmorCardSelected_CheckedChanged(object sender, EventArgs e)
        {
            var characterId = Convert.ToInt32(Page.RouteData.Values["characterid"]);
            var character = PcgManager.Dto.Character.Get(characterId);

            character.SelectedArmorCards = GetSelectedValue(sender, e, character);
            character.Update();
        }
        protected void CheckboxItemCardSelected_CheckedChanged(object sender, EventArgs e)
        {
            var characterId = Convert.ToInt32(Page.RouteData.Values["characterid"]);
            var character = PcgManager.Dto.Character.Get(characterId);

            character.SelectedItemCards = GetSelectedValue(sender, e, character);
            character.Update();
        }
        protected void CheckboxAllyCardSelected_CheckedChanged(object sender, EventArgs e)
        {
            var characterId = Convert.ToInt32(Page.RouteData.Values["characterid"]);
            var character = PcgManager.Dto.Character.Get(characterId);

            character.SelectedAllyCards = GetSelectedValue(sender, e, character);
            character.Update();
        }
        protected void CheckboxBlessingCardSelected_CheckedChanged(object sender, EventArgs e)
        {
            var characterId = Convert.ToInt32(Page.RouteData.Values["characterid"]);
            var character = PcgManager.Dto.Character.Get(characterId);

            character.SelectedBlessingCards = GetSelectedValue(sender, e, character);
            character.Update();
        }

        private int GetSelectedValue(object sender, EventArgs e, PcgManager.Dto.Character character)
        {
            var checkbox = (CheckBox)sender;
            var hiddenValue = (HiddenField)checkbox.Parent.FindControl("hiddenValue");
            var selectedValue = Convert.ToInt32(hiddenValue.Value);

            var repeater = (Repeater)checkbox.Parent.Parent;
            var repeaterItems = (RepeaterItemCollection)repeater.Items;

            var counter = character.WeaponCards + 1;
            foreach (RepeaterItem item in repeater.Items)
            {
                var innerCheckbox = (CheckBox)item.FindControl("checkboxSelected");
                if (counter < selectedValue) innerCheckbox.Checked = true;
                if (counter > selectedValue) innerCheckbox.Checked = false;

                counter++;
            }

            if (checkbox.Checked)
                return selectedValue;
            else
                return selectedValue - 1;
        }

        protected void CheckboxListExtraPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkboxlist = (CheckBoxList)sender;
            var repeaterItem = checkboxlist.Parent;
            var hiddenExtraPowerId = (HiddenField)repeaterItem.FindControl("hiddenExtraPowerId");
            var powerId = Convert.ToInt32(hiddenExtraPowerId.Value);

            int selectedValue = 0;
            int bitStep = 1;
            for (var i = 0; i < checkboxlist.Items.Count; i++)
            {
                if (checkboxlist.Items[i].Selected)
                    selectedValue += bitStep;

                bitStep += bitStep;
            }

            var characterId = Convert.ToInt32(Page.RouteData.Values["characterid"]);
            var character = PcgManager.Dto.Character.Get(characterId);

            PcgManager.Dto.Power.Set(characterId, powerId, selectedValue);
        }
    }
}