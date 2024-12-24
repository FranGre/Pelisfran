<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextSearch.ascx.cs" Inherits="Pelisfran.Controles.Busqueda.TextSearch" %>

<div class="field is-grouped">
    <div class="control is-expanded">
        <asp:TextBox ID="tbBusqueda" runat="server" CssClass="input"></asp:TextBox>
    </div>
    <div class="control">
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="button is-info" />
    </div>
</div>