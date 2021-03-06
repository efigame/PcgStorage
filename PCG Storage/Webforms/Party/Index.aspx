﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Pcg_Storage.Webforms.Party.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Party</h1>
    <fieldset>
        <legend>Index</legend>
        <asp:Repeater ID="repeaterOverview" runat="server" OnItemDataBound="RepeaterOverview_ItemDataBound">
            <ItemTemplate>
                <asp:HyperLink ID="linkPartyName" runat="server">HyperLink</asp:HyperLink> - <asp:HyperLink ID="linkEditParty" runat="server">Edit</asp:HyperLink><br />
            </ItemTemplate>
        </asp:Repeater>
    </fieldset>
    <div>
        <asp:HyperLink ID="linkCreateNewParty" runat="server">New party</asp:HyperLink>
    </div>
</asp:Content>
