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
                var manager = new PcgManager.PcgManager();
                var party = manager.GetParty(partyId);
                var character = party.Characters.SingleOrDefault(c => c.Id == characterId);

                literalCharacterName.Text = character.Name;
                literalPartyName.Text = party.Name;
            }

            linkEditCharacter.NavigateUrl = Url.PartyCharacterEdit(userId, partyId, characterId);
            linkGoToPartyView.NavigateUrl = Url.Party(userId, partyId);
        }
    }
}