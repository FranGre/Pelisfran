<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="Pelisfran.admin.comentarios.usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="mb-6">
        <h2 id="titulo" runat="server" class="title is-2 mb-2 is-flex is-justify-content-center">Comentarios</h2>
        <h3 id="subtitulo" runat="server" class="subtitle is-4 is-flex is-justify-content-center has-text-weight-light is-italic"></h3>
    </div>
    <asp:UpdatePanel ID="UpComentarios" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="mx-6">
                <asp:ListView ID="lvComentarios" runat="server" OnPagePropertiesChanging="lvComentarios_PagePropertiesChanging" OnItemDataBound="lvComentarios_ItemDataBound">

                    <EmptyDataTemplate>No hay comentarios</EmptyDataTemplate>

                    <ItemTemplate>
                        <div class="mb-4 box">
                            <div class="flex is-display-flex is-justify-content-space-between">
                                <div class="is-display-flex">
                                    <asp:Image ID="fotoPerfil" runat="server" CssClass="image is-rounded is-16x16" />
                                    <small id="nombre" runat="server" class="ml-1 has-text-weight-semibold"></small>
                                </div>
                                <p id="tituloPelicula" runat="server"></p>
                                <small id="fecha" runat="server" class="ml-6 has-text-weight-semibold"></small>
                            </div>
                            <p id="comentario" runat="server" class="ml-3"></p>
                            <asp:Button ID="btnEstado" runat="server" OnCommand="btnEstado_Command" CommandArgument='<%#Eval("Id") %>' />
                        </div>
                    </ItemTemplate>

                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                        <asp:DataPager ID="dpComentarios" runat="server" PagedControlID="lvComentarios" PageSize="10">
                            <Fields>
                                <asp:NumericPagerField ButtonType="Button" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>

                </asp:ListView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
