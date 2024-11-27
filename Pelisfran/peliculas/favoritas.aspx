<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="favoritas.aspx.cs" Inherits="Pelisfran.peliculas.favoritas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="sm" runat="server" />
    <asp:UpdatePanel ID="upPeliculas" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Repeater ID="repPeliculas" runat="server" OnItemDataBound="repPeliculas_ItemDataBound">
                <ItemTemplate>
                    <div>
                        <asp:Image ID="portada" runat="server" />
                        <h4 id="titulo" runat="server"></h4>
                        <asp:Button ID="btnFavorito" runat="server" OnClick="btnFavorito_Click" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
