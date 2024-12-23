<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="Pelisfran.Controles.Navegacion.Menu" %>

<nav class="navbar mb-3" role="navigation" aria-label="main navigation">
    <div class="navbar-menu">
        <div class="navbar-start">
            <asp:LinkButton ID="lbPelisFran" runat="server" Text="PelisFran" CausesValidation="false" CssClass="navbar-item" OnClick="lbPelisFran_Click"></asp:LinkButton>
            <asp:LinkButton ID="lkPeliculas" runat="server" Text="Peliculas" CausesValidation="false" CssClass="navbar-item" OnClick="lkPeliculas_Click"></asp:LinkButton>
            <asp:LinkButton ID="lkSeries" runat="server" Text="Series" CausesValidation="false" CssClass="navbar-item" OnClick="lkSeries_Click"></asp:LinkButton>
        </div>

        <div class="navbar-end">
            <div class="buttons">
                <asp:UpdatePanel ID="upBotonesMenu" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" CssClass="button is-light" OnClick="btnRegistrarse_Click" />
                        <asp:Button ID="btnIniciarSesion" runat="server" Text="Login" CssClass="button is-primary" OnClick="btnIniciarSesion_Click" />
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" CssClass="button is-danger" OnClick="btnCerrarSesion_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</nav>
