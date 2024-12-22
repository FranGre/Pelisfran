<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CheckBoxListGeneros.ascx.cs" Inherits="Pelisfran.Controles.CheckBoxLists.CheckBoxListGeneros" %>


<div class="checkboxes">
    <asp:Repeater ID="repGeneros" runat="server" OnItemDataBound="repGeneros_ItemDataBound">
        <ItemTemplate>
            <asp:CheckBox ID="cbGenero" runat="server" AutoPostBack="true" CssClass="checkbox" />
        </ItemTemplate>
    </asp:Repeater>
</div>
