<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Pelisfran.series._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>Series</h2>

    <asp:Repeater ID="repSeries" runat="server" OnItemDataBound="repSeries_ItemDataBound">
        <ItemTemplate>
            <asp:LinkButton ID="btnVer" runat="server" Text="Ver" OnClick="btnVer_Click">
                <div>
                    <asp:Image ID="portada" runat="server" />
                    <asp:Literal ID="titulo" runat="server"></asp:Literal>
                    <asp:Literal ID="fechaLanzamiento" runat="server"></asp:Literal>
                </div>
            </asp:LinkButton>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
