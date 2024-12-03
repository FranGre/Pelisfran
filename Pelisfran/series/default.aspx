<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Pelisfran.series._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>Series</h2>

    <asp:Repeater ID="repSeries" runat="server" OnItemDataBound="repSeries_ItemDataBound">
        <ItemTemplate>
            <div>
                <asp:ImageButton ID="imgbPortada" runat="server" OnClick="imgbPortada_Click" />
                <asp:Label ID="lbNombre" runat="server" />
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
