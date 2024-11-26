<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="ver.aspx.cs" Inherits="Pelisfran.peliculas.ver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 id="titulo" runat="server"></h2>
    <p id="descripcion" runat="server"></p>
    <asp:HiddenField ID="hfId" runat="server" />

    <asp:Button ID="btnFavorito" runat="server" OnClick="btnFavorito_Click" />
</asp:Content>
