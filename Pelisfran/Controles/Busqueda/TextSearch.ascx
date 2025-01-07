﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextSearch.ascx.cs" Inherits="Pelisfran.Controles.Busqueda.TextSearch" %>

<%@ Register Src="~/Controles/Botones/BotonBuscar.ascx" TagPrefix="controles" TagName="botonbuscar" %>

<div class="field is-grouped">
    <div class="control is-expanded">
        <asp:TextBox ID="tbBusqueda" runat="server" CssClass="input"></asp:TextBox>
    </div>
    <div class="control">
        <controles:botonbuscar ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" />
    </div>
</div>
