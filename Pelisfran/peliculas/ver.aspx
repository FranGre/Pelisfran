<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="ver.aspx.cs" Inherits="Pelisfran.peliculas.ver" %>

<%@ Register Src="~/Controles/Botones/BotonLike.ascx" TagPrefix="controles" TagName="botonlike" %>
<%@ Register Src="~/Controles/Botones/BotonFavorito.ascx" TagPrefix="controles" TagName="botonfavorito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 id="titulo" runat="server" class="title is-2 mb-6 is-flex is-justify-content-center">Peliculas</h2>

    <div class="block has-text-centered">
        <p id="descripcion" runat="server"></p>
    </div>

    <asp:UpdatePanel ID="upEstadisticas" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <nav class="level">
                <div class="level-item has-text-centered">
                    <div>
                        <p class="heading">Visitas</p>
                        <p class="title" id="visitas" runat="server"></p>
                    </div>
                </div>
                <div class="level-item has-text-centered">
                    <div>
                        <p class="heading">Likes</p>
                        <p class="title" id="likes" runat="server"></p>
                    </div>
                </div>
                <div class="level-item has-text-centered">
                    <div>
                        <p class="heading">Comentarios</p>
                        <p class="title" id="estadisticaComentarios" runat="server"></p>
                    </div>
                </div>
            </nav>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="upLikes" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <controles:botonlike ID="botonLike" runat="server" OnClick="botonLike_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hfId" runat="server" />

    <asp:UpdatePanel ID="upBotonFavorito" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <controles:botonfavorito ID="botonFavorito" runat="server" OnClick="botonFavorito_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <h3>aqui va la peli</h3>

    <div class="columns mt-4">
        <div class="column is-flex is-justify-content-center">
            <asp:UpdatePanel ID="upComentarios" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="mt-5">
                        <asp:ListView ID="lvComentarios" runat="server" OnPagePropertiesChanging="lvComentarios_PagePropertiesChanging" OnItemDataBound="lvComentarios_ItemDataBound">

                            <EmptyDataTemplate>No hay comentarios</EmptyDataTemplate>

                            <ItemTemplate>
                                <div class="mb-4">
                                    <div class="flex is-display-flex">
                                        <div class="is-display-flex">
                                            <asp:Image ID="fotoPerfil" runat="server" CssClass="image is-rounded is-16x16" ImageUrl="https://bulma.io/assets/images/placeholders/128x128.png" />
                                            <small id="nombre" runat="server" class="ml-1"></small>
                                        </div>
                                        <small id="fecha" runat="server" class="ml-6"></small>
                                    </div>
                                    <p id="comentario" runat="server" class="ml-1"></p>
                                </div>
                            </ItemTemplate>

                            <LayoutTemplate>
                                <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                                <asp:DataPager ID="dpComentarios" runat="server" PagedControlID="lvComentarios" PageSize="2">
                                    <Fields>
                                        <asp:NumericPagerField ButtonType="Button" />
                                    </Fields>
                                </asp:DataPager>
                            </LayoutTemplate>

                        </asp:ListView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="column">
            <asp:UpdatePanel ID="upFormComentario" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="field">
                        <div class="control">
                            <asp:TextBox ID="tbComentario" runat="server" TextMode="MultiLine" CssClass="textarea" Rows="5" placeholder="Escribir comentario..." />
                            <asp:Button ID="btnGuardarComentario" runat="server" Text="Comentar" OnClick="btnGuardarComentario_Click" CssClass="button is-success mt-4" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
