<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Pcg_Storage.Webforms.Party.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><asp:Literal ID="literalPartyName" runat="server"></asp:Literal></h1>
    <fieldset>
        <legend>Characters</legend>
        <asp:Repeater ID="repeaterCharacters" runat="server" OnItemDataBound="RepeaterCharacters_ItemDataBound">
            <ItemTemplate>
                <asp:HyperLink ID="linkCharacterName" runat="server"></asp:HyperLink><br />
            </ItemTemplate>
        </asp:Repeater>
    </fieldset>
    <asp:HyperLink ID="linkGoToIndex" runat="server">Go to index</asp:HyperLink>
</asp:Content>
