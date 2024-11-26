<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="ver.aspx.cs" Inherits="Pelisfran.peliculas.ver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <h2 id="titulo" runat="server"></h2>
    <p id="descripcion" runat="server"></p>
    <asp:HiddenField ID="hfId" runat="server" />

    <asp:UpdatePanel ID="upBotonFavorito" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Button ID="btnFavorito" runat="server" OnClick="btnFavorito_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
