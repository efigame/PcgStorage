using Pcg_Storage.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pcg_Storage.Webforms.Party
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = Convert.ToInt32(Page.RouteData.Values["userid"]);

            if (!Page.IsPostBack)
            {
                repeaterOverview.DataSource = PcgManager.Dto.Party.All(userId);
                repeaterOverview.DataBind();
            }

            linkCreateNewParty.NavigateUrl = Url.PartyNew(userId);
        }

        protected void RepeaterOverview_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var userId = Convert.ToInt32(Page.RouteData.Values["userid"]);

                var party = (PcgManager.Dto.Party)e.Item.DataItem;

                var linkPartyName = (HyperLink)e.Item.FindControl("linkPartyName");
                linkPartyName.Text = party.Name;
                linkPartyName.NavigateUrl = Url.Party(userId, party.Id);

                var linkEditParty = (HyperLink)e.Item.FindControl("linkEditParty");
                linkEditParty.NavigateUrl = Url.PartyEdit(userId, party.Id);
            }
        }

        protected void RepeaterOverview_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                var userId = Convert.ToInt32(Page.RouteData.Values["userid"]);
                Response.Redirect(Url.PartyEdit(userId, (int)e.CommandArgument));
            }
        }
    }
}