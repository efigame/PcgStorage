using Pcg_Storage.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pcg_Storage.Webforms.User
{
    public partial class New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkCreate_Click(object sender, EventArgs e)
        {
            var email = inputEmail.Value;
            var password = inputPassword.Value;
            var repeatPassword = inputRepeatPassword.Value;

            if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password) && !String.IsNullOrEmpty(repeatPassword) && password == repeatPassword)
            {
                var manager = new PcgManager.PcgManager();
                var success = manager.CreateUser(email, password);
                if (success.Success)
                {
                    var user = manager.LoginUser(email, password);
                    linkGoToPartyView.NavigateUrl = Url.PartyIndex(user.Id);
                    modalPanelSuccess.Style["display"] = "block";
                }
                else
                {
                    literalFailedReason.Text = success.FailedType.ToString();
                    modalPanelFailed.Style["display"] = "block";
                }
            }
            else
            {
                literalFailedReason.Text = "Input failed";
                modalPanelFailed.Style["display"] = "block";
            }
        }
    }
}