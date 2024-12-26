<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="ver.aspx.cs" Inherits="Pelisfran.peliculas.ver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 id="titulo" runat="server" class="title is-2 mb-6 is-flex is-justify-content-center">Peliculas</h2>

    <div class="block">
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
            <asp:Button ID="btnLike" runat="server" OnClick="btnLike_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hfId" runat="server" />

    <asp:UpdatePanel ID="upBotonFavorito" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Button ID="btnFavorito" runat="server" OnClick="btnFavorito_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="upFormComentario" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="field">
                <div class="control">
                    <asp:TextBox ID="tbComentario" runat="server" TextMode="MultiLine" CssClass="textarea" Rows="5" />
                    <asp:Button ID="btnGuardarComentario" runat="server" Text="Comentar" OnClick="btnGuardarComentario_Click" CssClass="button is-success mt-4" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upComentarios" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Repeater ID="repComentarios" runat="server" OnItemDataBound="repComentarios_ItemDataBound">
                <ItemTemplate>
                    <div>
                        <div>
                            <small id="nombre" runat="server"></small>
                            <small id="fecha" runat="server"></small>
                        </div>
                        <p id="comentario" runat="server"></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
