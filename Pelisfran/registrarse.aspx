<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="registrarse.aspx.cs" Inherits="Pelisfran.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1 class="title is-1 mb-6 is-flex is-justify-content-center">PelisFran</h1>

    <div class="box container is-max-tablet">
        <h2 class="title is-2 is-flex is-justify-content-center">Registarse</h2>

        <div id="alerta" runat="server" class="is-flex is-justify-content-center"></div>

        <div class="field">
            <asp:Label ID="lbNombreUsuario" runat="server" Text="Nombre Usuario" CssClass="label is-flex is-justify-content-center" />
            <div class="control">
                <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="input" />
            </div>
            <asp:RequiredFieldValidator ID="reqNombreUsuario" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="Campo obligatorio" Display="Dynamic" CssClass="help is-danger" />
            <asp:RegularExpressionValidator ID="regexNombreUsuario" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="Maximo 20 caracteres" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9]{1,20}$" CssClass="help is-danger" />
        </div>

        <div class="field">
            <asp:Label ID="lbEmail" runat="server" Text="Email" CssClass="label is-flex is-justify-content-center" />
            <div class="control">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="input"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Campo obligatorio" Display="Dynamic" CssClass="help is-danger" />
            <asp:RegularExpressionValidator ID="regexEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email invalido" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" CssClass="help is-danger" />
            <asp:CustomValidator ID="custEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" OnServerValidate="custEmail_ServerValidate" CssClass="help is-danger" />
        </div>

        <div class="field">
            <asp:Label ID="lbPassword" runat="server" Text="Password" CssClass="label is-flex is-justify-content-center" />
            <div class="control">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Campo obligatorio" Display="Dynamic" CssClass="help is-danger" />
            <asp:RegularExpressionValidator ID="regexPaswword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Minimo 8 caracteres, entre ellos letras y numeros" Display="Dynamic" ValidationExpression="^(?=.*[a-zA-Z])(?=.*\d).{8,}$" CssClass="help is-danger" />
        </div>

        <div class="field">
            <asp:Label ID="lbFechaNacimiento" runat="server" Text="FechaNacimiento" CssClass="label is-flex is-justify-content-center" />
            <div class="control">
                <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" CssClass="input"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="reqFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="Campo obligatorio" Display="Dynamic" CssClass="help is-danger" />
            <asp:RangeValidator ID="rangeFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="Debe estar entre 01/01/1920 y la fecha de hoy"
                Display="Dynamic" Type="Date" MinimumValue="01/01/1920" CssClass="help is-danger" />
        </div>

        <div class="mt-2 mb-6 is-flex is-justify-content-center">
            <asp:LinkButton ID="lbLogin" runat="server" OnClick="lbLogin_Click" CausesValidation="false">¿Tienes una cuenta? Iniciar sesión</asp:LinkButton>
        </div>

        <asp:Button ID="btnAceptar" runat="server" Text="Crear Cuenta" OnClick="btnAceptar_Click" CssClass="button is-primary" />
    </div>

</asp:Content>
