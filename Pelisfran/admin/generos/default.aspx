﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Pelisfran.admin.generos._default_aspx" %>

<%@ Register Src="~/Controles/Modales/ModalConfirmar.ascx" TagPrefix="controles" TagName="modalconfirmar" %>
<%@ Register Src="~/Controles/Busqueda/TextSearch.ascx" TagPrefix="controles" TagName="textsearch" %>
<%@ Register Src="~/Controles/Botones/BotonCrear.ascx" TagPrefix="controles" TagName="botoncrear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 id="titulo" runat="server" class="title is-2 mb-6 is-flex is-justify-content-center">Géneros</h2>

    <div class="mb-5 is-flex is-justify-content-space-between">
        <controles:botoncrear ID="btnCrearGenero" runat="server" Text="Género" OnClick="btnCrearGenero_Click" />
        <controles:textsearch ID="textsearch" runat="server" OnBuscar="textsearch_Buscar" Placeholder="Buscar..." />
    </div>

    <asp:UpdatePanel ID="upGeneros" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gvGeneros" runat="server"
                AutoGenerateColumns="false" ShowFooter="true"
                PageSize="5" AllowPaging="true" AllowSorting="true" SelectMethod="gvGeneros_GetData"
                CssClass="table is-hoverable is-striped is-bordered is-fullwidth" EnableViewState="true">
                <EmptyDataTemplate>
                    <p class="has-text-centered">No hay Géneros disponibles</p>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered"
                        SortExpression="Nombre" />
                    <asp:BoundField HeaderText="Películas" DataField="TotalPeliculas"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered"
                        SortExpression="TotalPeliculas" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="buttons">
                                <asp:Button ID="btnEditar" runat="server" Text="Editar" OnCommand="btnEditar_Command" CommandArgument='<%# Eval("Id") %>' CssClass="button is-dark" />
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnCommand="btnEliminar_Command" CommandArgument='<%# Eval("Id") %>' CssClass="button is-danger" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <controles:modalconfirmar Id="controlesModalConfirmar" runat="server" OnClickEliminar="controlesModalConfirmar_ClickEliminar" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
