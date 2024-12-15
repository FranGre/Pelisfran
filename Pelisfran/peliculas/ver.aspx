<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="ver.aspx.cs" Inherits="Pelisfran.peliculas.ver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <h2 id="titulo" runat="server"></h2>
    <p id="descripcion" runat="server"></p>
    <asp:HiddenField ID="hfId" runat="server" />

    <asp:UpdatePanel ID="upBotonFavorito" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Button ID="btnFavorito" runat="server" OnClick="btnFavorito_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="upFormComentario" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:TextBox ID="tbComentario" runat="server" TextMode="MultiLine" />
            <asp:Button ID="btnGuardarComentario" runat="server" Text="Comentar" OnClick="btnGuardarComentario_Click" />
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
