<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Pelisfran.admin.usuarios._default" %>

<%@ Register Src="~/Controles/Busqueda/TextSearch.ascx" TagPrefix="controles" TagName="textsearch" %>
<%@ Register Src="~/Controles/Modales/ModalConfirmar.ascx" TagPrefix="controles" TagName="modalconfirmar" %>
<%@ Register Src="~/Controles/Botones/BotonCrear.ascx" TagPrefix="controles" TagName="botoncrear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 id="titulo" runat="server" class="title is-2 mb-6 is-flex is-justify-content-center">Usuarios</h2>

    <div class="mb-5 is-flex is-justify-content-space-between">
        <controles:botoncrear ID="btnCrearUsuarios" runat="server" Text="Usuario" OnClick="btnCrearUsuarios_Click" />
        <controles:textsearch ID="textsearch" runat="server" OnBuscar="textsearch_Buscar" Placeholder="Buscar..." />
    </div>

    <asp:UpdatePanel ID="upUsuarios" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false"
                CssClass="table is-hoverable is-striped is-bordered is-fullwidth" EnableViewState="true" DataKeyNames="Id"
                OnRowDataBound="gvUsuarios_RowDataBound">
                <EmptyDataTemplate>
                    <p>No hay usuarios</p>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField HeaderText="Nombre Usuario" DataField="NombreUsuario"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered" />

                    <asp:BoundField HeaderText="Nombre" DataField="Nombre"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered" />

                    <asp:BoundField HeaderText="Email" DataField="Email"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered" />

                    <asp:TemplateField HeaderText="Rol"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlRoles" runat="server" OnSelectedIndexChanged="ddlRoles_SelectedIndexChanged" AutoPostBack="true" CssClass="select has-text-centered is-family-monospace has-text-weight-semibold	 has-radius-rounded is-fullwidth" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="Fecha Nacimiento" DataField="FechaNacimiento"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered" />

                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <div class="buttons">
                                <asp:Button ID="btnActivo" runat="server" OnCommand="btnActivo_Command" CommandArgument='<%# Eval("Id") %>' CssClass="button is-fullwidth"/>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="Likes" DataField="Likes"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered" />

                    <asp:HyperLinkField HeaderText="Comentarios" DataTextField="Comentarios"
                        HeaderStyle-CssClass="has-text-weight-bold has-text-centered"
                        ItemStyle-CssClass="has-text-centered"
                        DataNavigateUrlFields="Id"
                        DataNavigateUrlFormatString="~/admin/comentarios/usuario.aspx?id={0}" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="buttons">
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("Id") %>' CssClass="button is-danger" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <controles:modalconfirmar Id="controlesModalConfirmar" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

