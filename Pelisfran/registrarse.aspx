<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="registrarse.aspx.cs" Inherits="Pelisfran.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div>
        <asp:Label ID="lbNombreUsuario" runat="server" Text="Nombre Usuario" />
        <asp:TextBox ID="txtNombreUsuario" runat="server" />
        <asp:RequiredFieldValidator ID="reqNombreUsuario" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="Campo obligatorio" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="regexNombreUsuario" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="Maximo 20 caracteres" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9]{1,20}$" />
    </div>

    <div>
        <asp:Label ID="lbEmail" runat="server" Text="Email" />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Campo obligatorio" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="regexEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email invalido" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" />
        <asp:CustomValidator ID="custEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" OnServerValidate="custEmail_ServerValidate" />
    </div>

    <div>
        <asp:Label ID="lbPassword" runat="server" Text="Password" />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Campo obligatorio" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="regexPaswword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Minimo 8 caracteres, entre ellos letras y numeros" Display="Dynamic" ValidationExpression="^(?=.*[a-zA-Z])(?=.*\d).{8,}$" />
    </div>

    <div>
        <asp:Label ID="lbFechaNacimiento" runat="server" Text="FechaNacimiento" />
        <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="Campo obligatorio" Display="Dynamic" />
        <asp:RangeValidator ID="rangeFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="Debe estar entre 01/01/1920 y la fecha de hoy"
            Display="Dynamic" Type="Date" MinimumValue="01/01/1920" />
    </div>

    <asp:Button ID="btnAceptar" runat="server" Text="Crear Cuenta" OnClick="btnAceptar_Click" />

</asp:Content>
