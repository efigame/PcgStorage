using Pcg_Storage.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pcg_Storage.Webforms.Party
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = Convert.ToInt32(Page.RouteData.Values["userid"]);
            var partyId = Convert.ToInt32(Page.RouteData.Values["partyid"]);

            if (!Page.IsPostBack)
            {
                var manager = new PcgManager.PcgManager();
                var party = manager.GetParty(partyId);

                literalPartyName.Text = party.Name;

                repeaterCharacters.DataSource = party.Characters;
                repeaterCharacters.DataBind();
            }

            linkGoToIndex.NavigateUrl = Url.PartyIndex(userId);
        }

        protected void RepeaterCharacters_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var userId = Convert.ToInt32(Page.RouteData.Values["userid"]);
            var partyId = Convert.ToInt32(Page.RouteData.Values["partyid"]);
            
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var character = (PcgManager.Dto.Character)e.Item.DataItem;

                var linkCharacterName = (HyperLink)e.Item.FindControl("linkCharacterName");
                linkCharacterName.Text = character.Name;
                linkCharacterName.NavigateUrl = Url.PartyCharacter(userId, partyId, character.Id);
            }
        }
    }
}