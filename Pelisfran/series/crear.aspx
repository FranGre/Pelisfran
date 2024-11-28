<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="crear.aspx.cs" Inherits="Pelisfran.series.crear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>Nueva Serie</h2>

    <div>
        <asp:Label ID="lbTitulo" runat="server" Text="Titulo" />
        <asp:TextBox ID="txtTitulo" runat="server" />
        <asp:RequiredFieldValidator ID="reqTitulo" runat="server" ControlToValidate="txtTitulo" ErrorMessage="Campo obligatorio" Display="Dynamic" />
    </div>

    <div>
        <asp:Label ID="lbSinopsisBreve" runat="server" Text="Sinopsis" />
        <asp:TextBox ID="txtSinopsis" runat="server" />
        <asp:RequiredFieldValidator ID="reqSinopsis" runat="server" ControlToValidate="txtSinopsis" ErrorMessage="Campo obligatorio" Display="Dynamic" />
    </div>

    <div>
        <asp:Label ID="lbFechaLanzamiento" runat="server" Text="Fecha Lanzamiento" />
        <asp:TextBox ID="txtFechaLanzamiento" runat="server" TextMode="Date" />
        <asp:RequiredFieldValidator ID="reqFechaLanzamiento" runat="server" ControlToValidate="txtFechaLanzamiento" ErrorMessage="Campo obligatorio" Display="Dynamic" />
    </div>

    <asp:Button ID="btnAceptar" runat="server" Text="Crear" OnClick="btnAceptar_Click" />
</asp:Content>
