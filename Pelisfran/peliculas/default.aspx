<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Pelisfran.peliculas._default" %>

<%@ Register Src="~/Controles/CheckBoxLists/CheckBoxListGeneros.ascx" TagPrefix="controles" TagName="checkboxListGeneros" %>
<%@ Register Src="~/Controles/Busqueda/TextSearch.ascx" TagPrefix="controles" TagName="textSearch" %>
<%@ Register Src="~/Controles/Peliculas/Peliculas.ascx" TagPrefix="controles" TagName="peliculas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 class="title is-2 mb-6 is-flex is-justify-content-center">Peliculas</h2>

    <div class="mb-5">
        <controles:checkboxListGeneros ID="generos" runat="server" />
    </div>
    <div class="is-flex is-justify-content-right">
        <controles:textSearch ID="tsBusqueda" runat="server" Placeholder="Buscar pelicula..." OnBuscar="tsBusqueda_Buscar" />
    </div>

    <asp:UpdatePanel ID="upPeliculas" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="tsBusqueda" />
        </Triggers>
        <ContentTemplate>
            <controles:peliculas ID="ucPeliculas" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
