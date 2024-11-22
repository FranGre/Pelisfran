<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="crear.aspx.cs" Inherits="Pelisfran.generos.crear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div>
        <asp:Label ID="lbNombre" runat="server" Text="Nombre" />
        <asp:TextBox ID="txtNombre" runat="server" />
        <asp:RequiredFieldValidator ID="reqNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Campo obligatorio" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="regexNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Maximo 40 caracteres" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9]{1,40}$" />
    </div>

    <asp:Button ID="btnAceptar" runat="server" Text="Crear" OnClick="btnAceptar_Click" />
</asp:Content>
