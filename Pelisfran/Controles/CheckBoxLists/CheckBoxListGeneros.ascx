<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CheckBoxListGeneros.ascx.cs" Inherits="Pelisfran.Controles.CheckBoxLists.CheckBoxListGeneros" %>


<div>
    <asp:Repeater ID="repGeneros" runat="server" OnItemDataBound="repGeneros_ItemDataBound">
        <ItemTemplate>
            <asp:CheckBox ID="cbGenero" runat="server" AutoPostBack="true" />
        </ItemTemplate>
    </asp:Repeater>
</div>