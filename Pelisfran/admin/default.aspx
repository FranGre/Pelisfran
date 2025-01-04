<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Pelisfran.admin._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 id="titulo" runat="server" class="title is-2 mb-6 is-flex is-justify-content-center">Admin</h2>
    <div class="columns  is-gap-4">
        <asp:LinkButton ID="lbGeneros" runat="server" CssClass="column box is-flex is-justify-content-space-between has-background-grey-dark" OnClick="lbGeneros_Click">
            <p>Generos</p>
            <p id="pGenerosTotal" runat="server"></p>
        </asp:LinkButton>

        <asp:LinkButton ID="lbPeliculas" runat="server" class="column box is-flex is-justify-content-space-between has-background-grey-dark" OnClick="lbPeliculas_Click">
            <p>Peliculas</p>
            <p id="pPeliculasTotal" runat="server"></p>
        </asp:LinkButton>

        <asp:LinkButton ID="lbUsuarios" runat="server" class="column box is-flex is-justify-content-space-between has-background-grey-dark" OnClick="lbUsuarios_Click">
            <p>Usuarios</p>
            <p id="pUsuariosTotal" runat="server"></p>
        </asp:LinkButton>
    </div>
</asp:Content>
