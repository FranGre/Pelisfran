﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Pelisfran.admin._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 id="titulo" runat="server" class="title is-2 mb-6 is-flex is-justify-content-center">Admin</h2>
    <div class="mt-4 columns is-variable is-5 is-gap-4">
        <asp:LinkButton ID="lbGeneros" runat="server" CssClass="column box is-flex is-justify-content-space-between has-background-grey-dark" OnClick="lbGeneros_Click">
            <p class="is-family-code is-uppercase">Géneros</p>
            <p id="pGenerosTotal" runat="server" class="has-text-weight-bold"></p>
        </asp:LinkButton>

        <asp:LinkButton ID="lbPeliculas" runat="server" class="column box is-flex is-justify-content-space-between has-background-grey-dark" OnClick="lbPeliculas_Click">
            <p class="is-family-code is-uppercase">Películas</p>
            <p id="pPeliculasTotal" runat="server" class="has-text-weight-bold"></p>
        </asp:LinkButton>

        <asp:LinkButton ID="lbUsuarios" runat="server" class="column box is-flex is-justify-content-space-between has-background-grey-dark mb-5" OnClick="lbUsuarios_Click">
            <p class="is-family-code is-uppercase">Usuarios</p>
            <p id="pUsuariosTotal" runat="server" class="has-text-weight-bold"></p>
        </asp:LinkButton>
    </div>
</asp:Content>
