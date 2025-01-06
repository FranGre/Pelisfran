<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Pelisfran.admin.generos._default_aspx" %>

<%@ Register Src="~/Controles/Modales/ModalConfirmar.ascx" TagPrefix="controles" TagName="modalconfirmar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>Generos</h2>

    <asp:Button ID="btnCrearGenero" runat="server" Text="Crear Genero" OnClick="btnCrearGenero_Click" />

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
                                <asp:Button ID="btnEditar" runat="server" Text="Editar" CausesValidation="false" />
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("Id") %>' OnClick="btnEliminar_Click" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <controles:modalconfirmar Id="controlesModalConfirmar" runat="server" OnClickEliminar="controlesModalConfirmar_ClickEliminar" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
