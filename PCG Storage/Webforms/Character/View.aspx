<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Pcg_Storage.Webforms.Character.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><asp:Literal ID="literalCharacterName" runat="server"></asp:Literal> (<asp:Literal ID="literalPartyName" runat="server"></asp:Literal>)</h1>
    <fieldset>
        <legend>Skills</legend>
        <asp:Repeater ID="repeaterSkills" runat="server" OnItemDataBound="RepeaterSkills_ItemDataBound">
            <ItemTemplate>
                <div>
                    <asp:Literal ID="literalSkillName" runat="server"></asp:Literal>
                    <asp:Literal ID="literalSkillDice" runat="server"></asp:Literal>
                    <asp:HiddenField ID="hiddenSkillId" runat="server" />
                    <asp:Repeater ID="repeaterPossibleSkill" runat="server" OnItemDataBound="RepeaterPossibleSkill_ItemDataBound">
                        <ItemTemplate>
                            <asp:HiddenField ID="hiddenPossibleSkillValue" runat="server" />
                            <asp:CheckBox ID="checkboxSkillSelected" runat="server" OnCheckedChanged="CheckboxSkillSelected_CheckedChanged" TextAlign="Right" AutoPostBack="true" />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <asp:Repeater ID="repeaterSubSkills" runat="server" OnItemDataBound="RepeaterSubSkills_ItemDataBound">
                    <ItemTemplate>
                        <div style="margin-left: 10px;">
                            <asp:Literal ID="literalSubSkillName" runat="server"></asp:Literal>
                            <asp:Literal ID="literalSubSkillAdjustment" runat="server"></asp:Literal>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <hr />
            </ItemTemplate>
        </asp:Repeater>
    </fieldset>
    <fieldset>
        <legend>Powers</legend>
        Hand Size <asp:Literal ID="literalHandSize" runat="server"></asp:Literal>
        <asp:Repeater ID="repeaterHandSize" runat="server" OnItemDataBound="RepeaterHandSize_ItemDataBound">
            <ItemTemplate>
                <asp:HiddenField ID="hiddenPossibleHandSizeValue" runat="server" />
                <asp:CheckBox ID="checkboxHandSizeSelected" runat="server" OnCheckedChanged="CheckboxHandSizeSelected_CheckedChanged" TextAlign="Right" AutoPostBack="true" />
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <hr />
        Proficient with 
        <asp:CheckBox ID="checkboxLightArmors" runat="server" Text="Light Armors" OnCheckedChanged="CheckboxLightArmors_CheckedChanged" AutoPostBack="true" />
        <asp:CheckBox ID="checkboxHeavyArmors" runat="server" Text="Heavy Armors" OnCheckedChanged="CheckboxHeavyArmors_CheckedChanged" AutoPostBack="true" />
        <asp:CheckBox ID="checkboxWeapons" runat="server" Text="Weapons" OnCheckedChanged="CheckboxWeapons_CheckedChanged" AutoPostBack="true" />
        <hr />
        <asp:Repeater ID="repeaterExtraPowers" runat="server" OnItemDataBound="RepeaterExtraPowers_ItemDataBound">
            <ItemTemplate>
                <asp:Literal ID="literalExtraPowerText" runat="server"></asp:Literal>
                <asp:HiddenField ID="hiddenExtraPowerId" runat="server" />
                <asp:CheckBoxList ID="checkboxListExtraPower" OnSelectedIndexChanged="CheckboxListExtraPower_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:CheckBoxList>
                <br />
                <hr />
            </ItemTemplate>
        </asp:Repeater>
    </fieldset>
    <fieldset>
        <legend>Cards</legend>
        <div>Weapon <asp:Literal ID="literalWeaponCards" runat="server"></asp:Literal></div><hr />
        <div>Spell <asp:Literal ID="literalSpellCards" runat="server"></asp:Literal></div><hr />
        <div>Armor <asp:Literal ID="literalArmorCards" runat="server"></asp:Literal></div><hr />
        <div>Item <asp:Literal ID="literalItemCards" runat="server"></asp:Literal></div><hr />
        <div>Ally <asp:Literal ID="literalAllyCards" runat="server"></asp:Literal></div><hr />
        <div>Blessing <asp:Literal ID="literalBlessingCards" runat="server"></asp:Literal></div>
    </fieldset>
    <asp:HyperLink ID="linkEditCharacter" runat="server">Edit character</asp:HyperLink>
    <asp:HyperLink ID="linkGoToPartyView" runat="server">Go to party view</asp:HyperLink>
</asp:Content>
