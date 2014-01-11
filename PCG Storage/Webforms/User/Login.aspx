<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pcg_Storage.Webforms.User.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/Modal.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-2.0.3.js"></script>
    <script src="../../Scripts/ModalDialog.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>PCG Storage</h1>
    <p>This is for storaging your party information and removed cards for the Pathfinder Card Game</p>
    <div>
        Email: <input id="inputEmail" type="email" required="required" runat="server" /><br />
        Password: <input id="inputPassword" type="password" required="required" runat="server" />
    </div>
    <div>
        <asp:LinkButton ID="linkLogin" runat="server" OnClick="LinkLogin_Click">Login</asp:LinkButton>
    </div>
    <div>
        <asp:HyperLink ID="linkCreateUser" runat="server">Create new user</asp:HyperLink>  
        <asp:HyperLink ID="linkForgottenPassword" runat="server">I forgot my password</asp:HyperLink>  
    </div>
    <div id="modalPanelFailed" runat="server" style="display: none;">
        <div class="modal">
            <header>
                <h2>Failure</h2>
            </header>
            <section>
                Reason: <asp:Literal ID="literalFailedReason" runat="server"></asp:Literal>
            </section>
            <footer>
                <a id="modalPanelFailedClose" href="#" onclick="">Close</a>
            </footer>
        </div>
        <div class="fade"></div>
    </div>
</asp:Content>
