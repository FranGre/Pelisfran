﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Pelisfran.admin.generos._default_aspx" %>

<%@ Register Src="~/Controles/Modales/ModalConfirmar.ascx" TagPrefix="controles" TagName="modalconfirmar" %>
<%@ Register Src="~/Controles/Busqueda/TextSearch.ascx" TagPrefix="controles" TagName="textsearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 id="titulo" runat="server" class="title is-2 mb-6 is-flex is-justify-content-center">Generos</h2>

    <div class="mb-5">
        <asp:Button ID="btnCrearGenero" runat="server" Text="Crear Genero" OnClick="btnCrearGenero_Click" CssClass="button is-success" />
        <controles:textsearch ID="textsearch" runat="server" OnBuscar="textsearch_Buscar" Placeholder="Buscar..." />
    </div>

    <asp:UpdatePanel ID="upGeneros" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gvGeneros" runat="server" AutoGenerateColumns="false"
                CssClass="table is-hoverable is-striped is-bordered is-fullwidth" EnableViewState="true">
                <EmptyDataTemplate>
                    <p>No hay Géneros disponibles</p>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered" />
                    <asp:BoundField HeaderText="Películas" DataField="TotalPeliculas"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="buttons">
                                <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandArgument='<%# Eval("Id") %>' OnClick="btnEditar_Click" CssClass="button is-dark" />
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("Id") %>' OnClick="btnEliminar_Click" CssClass="button is-danger" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <controles:modalconfirmar Id="controlesModalConfirmar" runat="server" OnClickEliminar="controlesModalConfirmar_ClickEliminar" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
