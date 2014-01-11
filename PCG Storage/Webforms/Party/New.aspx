<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="Pcg_Storage.Webforms.Party.New" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Create Party</h1>
    <fieldset>
        <legend>Basic information</legend>
        <p>
            <label for="inputDescription">Description</label>
            <input id="inputDescription" type="text" runat="server" />
        </p>
    </fieldset>
    <fieldset>
        <legend>Characters</legend>
        <asp:Repeater ID="repeaterCharacters" runat="server" OnItemDataBound="RepeaterCharacters_ItemDataBound">
            <ItemTemplate>
                <asp:CheckBox ID="checkboxCharacter" runat="server" /><asp:Literal ID="literalCharacterName" runat="server"></asp:Literal><asp:HiddenField ID="hiddenCharacterId" runat="server" />
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </fieldset>
    <p>
        <asp:LinkButton ID="linkCreateParty" runat="server" OnClick="LinkCreateParty_Click">Create</asp:LinkButton>
        <asp:HyperLink ID="linkCancelCreateParty" runat="server">Cancel</asp:HyperLink>
    </p>
</asp:Content>
