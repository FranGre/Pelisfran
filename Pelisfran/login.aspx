<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Pelisfran.login1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="alerta" runat="server"></div>
    <div>
        <asp:Label ID="lbEmail" runat="server" Text="Email" />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Campo obligatorio" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="regexEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email invalido" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" />
    </div>

    <div>
        <asp:Label ID="lbPassword" runat="server" Text="Password" />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Campo obligatorio" Display="Dynamic" />
    </div>

    <asp:Button ID="btnAceptar" runat="server" Text="Iniciar Sesion" OnClick="btnAceptar_Click" />
</asp:Content>
