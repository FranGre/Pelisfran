<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="registrarse.aspx.cs" Inherits="Pelisfran.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div>
        <asp:Label ID="lbNombreUsuario" runat="server" Text="Nombre Usuario" />
        <asp:TextBox ID="txtNombreUsuario" runat="server" />
        <asp:RequiredFieldValidator ID="reqNombreUsuario" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="Campo obligatorio" />
    </div>

    <div>
        <asp:Label ID="lbEmail" runat="server" Text="Email" />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Campo obligatorio" />
    </div>

    <div>
        <asp:Label ID="lbPassword" runat="server" Text="Password" />
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Campo obligatorio" />
    </div>

    <div>
        <asp:Label ID="lbFechaNacimiento" runat="server" Text="FechaNacimiento" />
        <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="Campo obligatorio" />
    </div>

    <asp:Button ID="btnAceptar" runat="server" Text="Crear Cuenta" OnClick="btnAceptar_Click"/>

</asp:Content>
