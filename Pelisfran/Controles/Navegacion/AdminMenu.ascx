<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminMenu.ascx.cs" Inherits="Pelisfran.Controles.Navegacion.AdminMenu" %>

<%@ Register Src="~/Controles/Botones/BotonCerrarSesion.ascx" TagPrefix="controles" TagName="botoncerrarsesion" %>

<nav class="navbar mb-3" role="navigation" aria-label="main navigation">
    <div class="navbar-menu">
        <div class="navbar-start">
            <asp:LinkButton ID="lbPelisFran" runat="server" Text="PelisFran" CausesValidation="false" CssClass="navbar-item" OnClick="lbPelisFran_Click"></asp:LinkButton>
            <asp:LinkButton ID="lkPeliculas" runat="server" Text="Peliculas" CausesValidation="false" CssClass="navbar-item" OnClick="lkPeliculas_Click"></asp:LinkButton>
            <asp:LinkButton ID="lkSeries" runat="server" Text="Series" CausesValidation="false" CssClass="navbar-item" OnClick="lkSeries_Click"></asp:LinkButton>
            <asp:LinkButton ID="lkAdmin" runat="server" Text="Admin" CausesValidation="false" CssClass="navbar-item" OnClick="lkAdmin_Click"></asp:LinkButton>
        </div>

        <div class="navbar-end">
            <div class="buttons">
                <asp:UpdatePanel ID="upFotoPerfil" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <a href="<%= ResolveUrl("~/mi-perfil.aspx") %>">
                            <figure class="image is-64x64">
                                <asp:Image ID="imgFotoPerfil" runat="server" CssClass="is-rounded" />
                            </figure>
                        </a>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:LinkButton ID="lbMiPerfil" runat="server" Text="Mi perfil" OnClick="lbMiPerfil_Click" />
                <controles:botoncerrarsesion ID="botonCerrarSesion" runat="server" OnClick="botonCerrarSesion_Click" />
            </div>
        </div>
    </div>
</nav>
