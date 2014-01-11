using Pcg_Storage.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pcg_Storage.Webforms.User
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                linkCreateUser.NavigateUrl = Url.UserCreate();
                linkForgottenPassword.NavigateUrl = Url.UserForgottenPassword();
            }
        }

        protected void LinkLogin_Click(object sender, EventArgs e)
        {
            var email = inputEmail.Value;
            var password = inputPassword.Value;

            var manager = new PcgManager.PcgManager();
            var user = manager.LoginUser(email, password);

            if (user != null)
                Response.Redirect(Url.PartyIndex(user.Id));
            else
            {
                literalFailedReason.Text = "User not found";
                modalPanelFailed.Style["display"] = "block";
            }
        }
    }
}