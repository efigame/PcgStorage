﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Pcg_Storage.Webforms.Character.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><asp:Literal ID="literalCharacterName" runat="server"></asp:Literal> (<asp:Literal ID="literalPartyName" runat="server"></asp:Literal>)</h1>
    <fieldset>
        <legend>Skills</legend>
        <asp:Repeater ID="repeaterSkills" runat="server" OnItemCommand="RepeaterSkills_ItemCommand" OnItemDataBound="RepeaterSkills_ItemDataBound">
            <ItemTemplate>
                <asp:Literal ID="literalSkillName" runat="server"></asp:Literal>
                <asp:Literal ID="literalSkillDice" runat="server"></asp:Literal>
                <asp:Literal ID="literalSkillAdjustment" runat="server"></asp:Literal>
                <asp:Literal ID="literalSkillPossibleAddons" runat="server"></asp:Literal>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </fieldset>
    <asp:HyperLink ID="linkEditCharacter" runat="server">Edit character</asp:HyperLink>
    <asp:HyperLink ID="linkGoToPartyView" runat="server">Go to party view</asp:HyperLink>
</asp:Content>