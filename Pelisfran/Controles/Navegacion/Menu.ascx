<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="Pelisfran.Controles.Navegacion.Menu" %>

<nav>
    <ul>
        <li>
            <asp:LinkButton ID="lbPelisFran" runat="server" Text="PelisFran" CausesValidation="false" OnClick="lbPelisFran_Click"></asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton ID="lkPeliculas" runat="server" Text="Peliculas" CausesValidation="false" OnClick="lkPeliculas_Click"></asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton ID="lkSeries" runat="server" Text="Series" CausesValidation="false" OnClick="lkSeries_Click"></asp:LinkButton>
        </li>
    </ul>
</nav>
