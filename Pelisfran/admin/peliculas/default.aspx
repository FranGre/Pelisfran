﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Pelisfran.admin.peliculas._default" %>

<%@ Register Src="~/Controles/Busqueda/TextSearch.ascx" TagPrefix="controles" TagName="textsearch" %>
<%@ Register Src="~/Controles/Botones/BotonCrear.ascx" TagPrefix="controles" TagName="botoncrear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 id="titulo" runat="server" class="title is-2 mb-6 is-flex is-justify-content-center">Peliculas</h2>

    <div class="mb-5 is-flex is-justify-content-space-between">
        <controles:botoncrear ID="btnCrearPelicula" runat="server" Text="Pelicula" OnClick="btnCrearPelicula_Click" />
        <controles:textsearch ID="textsearch" runat="server" OnBuscar="textsearch_Buscar" Placeholder="Buscar..." />
    </div>

    <asp:UpdatePanel ID="upPeliculas" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gvPeliculas" runat="server" AutoGenerateColumns="false"
                CssClass="table is-hoverable is-striped is-bordered is-fullwidth" EnableViewState="true">
                <EmptyDataTemplate>
                    <p>No hay peliculas disponibles</p>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField HeaderText="Titulo" DataField="Titulo"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered" />
                    <asp:BoundField HeaderText="Lanzamiento" DataField="FechaLanzamiento"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered" />

                    <asp:BoundField HeaderText="Duracion" DataField="Duracion"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered" />

                    <asp:BoundField HeaderText="Creado Por" DataField="CreadoPor"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered" />

                    <asp:BoundField HeaderText="Likes" DataField="Likes"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered" />

                    <asp:BoundField HeaderText="Comentarios" DataField="Comentarios"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered" />

                    <asp:BoundField HeaderText="Visitas" DataField="Visitas"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="buttons">
                                <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandArgument='<%# Eval("Id") %>' CssClass="button is-dark" />
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="button is-danger" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
