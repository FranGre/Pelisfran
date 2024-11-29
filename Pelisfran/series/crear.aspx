<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="crear.aspx.cs" Inherits="Pelisfran.series.crear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>Nueva Serie</h2>

    <div>
        <asp:Label ID="lbTitulo" runat="server" Text="Titulo" />
        <asp:TextBox ID="txtTitulo" runat="server" />
        <asp:RequiredFieldValidator ID="reqTitulo" runat="server" ControlToValidate="txtTitulo" ErrorMessage="Campo obligatorio" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="regexTitulo" runat="server" ControlToValidate="txtTitulo" ErrorMessage="Maximo 50 caracteres" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9\s]{1,50}$" />
    </div>

    <div>
        <asp:Label ID="lbSinopsisBreve" runat="server" Text="Sinopsis" />
        <asp:TextBox ID="txtSinopsis" runat="server" />
        <asp:RequiredFieldValidator ID="reqSinopsis" runat="server" ControlToValidate="txtSinopsis" ErrorMessage="Campo obligatorio" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="regexSinopsis" runat="server" ControlToValidate="txtSinopsis" ErrorMessage="Maximo 350 caracteres" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9\s]{1,350}$" />
    </div>

    <div>
        <asp:Label ID="lbFechaLanzamiento" runat="server" Text="Fecha Lanzamiento" />
        <asp:TextBox ID="txtFechaLanzamiento" runat="server" TextMode="Date" />
        <asp:RequiredFieldValidator ID="reqFechaLanzamiento" runat="server" ControlToValidate="txtFechaLanzamiento" ErrorMessage="Campo obligatorio" Display="Dynamic" />
        <asp:RangeValidator ID="rangeFechaLanzamiento" runat="server" ControlToValidate="txtFechaLanzamiento" Display="Dynamic" Type="Date" />
    </div>

    <asp:Button ID="btnAceptar" runat="server" Text="Crear" OnClick="btnAceptar_Click" />
</asp:Content>
