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

                var literalSkillPossibleAddons = (Literal)e.Item.FindControl("literalSkillPossibleAddons");
                literalSkillPossibleAddons.Text = "+" + skill.PossibleAddons.ToString();

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
    }
}