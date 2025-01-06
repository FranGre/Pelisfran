<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Pelisfran.admin.peliculas._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 id="titulo" runat="server" class="title is-2 mb-6 is-flex is-justify-content-center">Peliculas</h2>

    <asp:Button ID="btnCrearPelicula" runat="server" Text="Crear Pelicula" OnClick="btnCrearPelicula_Click" CssClass="button is-success" />

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
                                <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandArgument='<%# Eval("Id") %>' />
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="button is-danger" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
