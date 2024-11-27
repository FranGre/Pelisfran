<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="favoritas.aspx.cs" Inherits="Pelisfran.peliculas.favoritas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Repeater ID="repPeliculas" runat="server" OnItemDataBound="repPeliculas_ItemDataBound">
        <ItemTemplate>
            <div>
                <asp:Image ID="portada" runat="server" />
                <h4 id="titulo" runat="server"></h4>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
