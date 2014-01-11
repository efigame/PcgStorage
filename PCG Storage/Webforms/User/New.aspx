<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="Pcg_Storage.Webforms.User.New" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/Modal.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-2.0.3.js"></script>
    <script src="../../Scripts/ModalDialog.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Create User</h1>
    <fieldset>
        <legend>User data</legend>
        <p>
            <label for="inputEmail">Email</label>
            <input id="inputEmail" type="email" runat="server" />
        </p>
        <p>
            <label for="inputPassword">Password</label>
            <input id="inputPassword" type="password" runat="server" />
        </p>
        <p>
            <label for="inputRepeatPassword">Repeat password</label>
            <input id="inputRepeatPassword" type="password" runat="server" />
        </p>
        <p>
            <asp:LinkButton ID="linkCreate" runat="server" OnClick="LinkCreate_Click">Create</asp:LinkButton>
        </p>
    </fieldset>
    <div id="modalPanelSuccess" runat="server" style="display: none;">
        <div class="modal">
            <header>
                <h2>Success</h2>
            </header>
            <section>
                User created successfully<br />
            </section>
            <footer>
                <asp:HyperLink ID="linkGoToPartyView" runat="server">Click here to continue...</asp:HyperLink>
            </footer>
        </div>
        <div class="fade"></div>
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
