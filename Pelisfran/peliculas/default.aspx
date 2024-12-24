<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Pelisfran.peliculas._default" %>

<%@ Register Src="~/Controles/CheckBoxLists/CheckBoxListGeneros.ascx" TagPrefix="controles" TagName="checkboxListGeneros" %>
<%@ Register Src="~/Controles/Busqueda/TextSearch.ascx" TagPrefix="controles" TagName="textSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 class="title is-2 mb-6 is-flex is-justify-content-center">Peliculas</h2>

    <controles:checkboxListGeneros ID="generos" runat="server" />

    <controles:textSearch ID="tsBusqueda" runat="server" Placeholder="Buscar pelicula..." OnBuscar="tsBusqueda_Buscar" />

    <asp:UpdatePanel ID="upPeliculas" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="tsBusqueda" />
        </Triggers>
        <ContentTemplate>
            <div class="mt-6">
                <p id="pPeliculasNoEncontradas" runat="server"></p>
                <div class="columns is-multiline">
                    <asp:Repeater ID="repPeliculas" runat="server" OnItemDataBound="repPeliculas_ItemDataBound">
                        <ItemTemplate>
                            <div class="column is-6-mobile is-4-tablet is-2-desktop">
                                <asp:LinkButton ID="btnVer" runat="server" Text="Ver" OnClick="btnVer_Click">
                                    <div class="card">
                                        <div class="card-image">
                                            <asp:Image ID="portada" runat="server" CssClass="image is-3by5" />
                                        </div>

                                        <div class="card-content">
                                            <div class="content">
                                                <asp:Label ID="titulo" runat="server" CssClass="is-flex is-justify-content-center"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
