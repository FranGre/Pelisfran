<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="Pelisfran.Controles.Navegacion.Menu" %>

<%@ Register Src="~/Controles/Botones/BotonCerrarSesion.ascx" TagPrefix="controles" TagName="botoncerrarsesion" %>

<nav class="navbar mb-3" role="navigation" aria-label="main navigation">
    <div class="navbar-menu">
        <div class="navbar-start">
            <asp:LinkButton ID="lbPelisFran" runat="server" Text="PelisFran" CausesValidation="false" CssClass="navbar-item" OnClick="lbPelisFran_Click"></asp:LinkButton>
            <asp:LinkButton ID="lkPeliculas" runat="server" Text="Películas" CausesValidation="false" CssClass="navbar-item" OnClick="lkPeliculas_Click"></asp:LinkButton>
            <asp:LinkButton ID="lkSeries" runat="server" Text="Series" CausesValidation="false" CssClass="navbar-item" OnClick="lkSeries_Click"></asp:LinkButton>
        </div>

        <div class="navbar-end">
            <asp:UpdatePanel ID="upBotonesMenu" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="buttons">
                        <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" CssClass="button is-light" OnClick="btnRegistrarse_Click" />
                        <asp:Button ID="btnIniciarSesion" runat="server" Text="Login" CssClass="button is-primary" OnClick="btnIniciarSesion_Click" />
                        <asp:Panel ID="miPerfil" runat="server">
                            <a href="<%= ResolveUrl("~/mi-perfil.aspx") %>">
                                <figure class="image is-64x64">
                                    <asp:Image ID="imgFotoPerfil" runat="server" CssClass="is-rounded" />
                                </figure>
                            </a>
                        </asp:Panel>
                        <controles:botoncerrarsesion ID="botonCerrarSesion" runat="server" OnClick="botonCerrarSesion_Click" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</nav>
