using Pcg_Storage.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pcg_Storage.Webforms.Party
{
    public partial class New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var userId = Convert.ToInt32(Page.RouteData.Values["userid"]);

                var manager = new PcgManager.PcgManager();
                var characterCards = manager.GetCards(PcgManager.Dto.CardType.Character);
                repeaterCharacters.DataSource = characterCards;
                repeaterCharacters.DataBind();

                linkCancelCreateParty.NavigateUrl = Url.PartyIndex(userId);
            }
        }
        protected void LinkCreateParty_Click(object sender, EventArgs e)
        {
            var userId = Convert.ToInt32(Page.RouteData.Values["userid"]);
            var name = inputDescription.Value;

            // TODO: Test for valid input

            var party = new PcgManager.Dto.Party();
            party.Name = name;
            party.UserId = userId;

            foreach (RepeaterItem item in repeaterCharacters.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var checkbox = (CheckBox)item.FindControl("checkboxCharacter");
                    if (checkbox.Checked)
                    {
                        var card = new PcgManager.Dto.Character();

                        var hidden = (HiddenField)item.FindControl("hiddenCharacterId");
                        card.CharacterCardId = Convert.ToInt32(hidden.Value);

                        party.Characters.Add(card);
                    }
                }
            }

            party.Persist();

            Response.Redirect(Url.PartyIndex(userId));
        }

        protected void RepeaterCharacters_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var card = (PcgManager.Dto.Card)e.Item.DataItem;

                var literal = (Literal)e.Item.FindControl("literalCharacterName");
                literal.Text = card.Name;

                var hidden = (HiddenField)e.Item.FindControl("hiddenCharacterId");
                hidden.Value = card.Id.ToString();
            }
        }
    }
}