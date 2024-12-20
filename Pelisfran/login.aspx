<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Pelisfran.login1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1 class="title is-1 mb-6 is-flex is-justify-content-center">PelisFran</h1>

    <div class="box container is-max-tablet">
        <h2 class="title is-2 is-flex is-justify-content-center">Login</h2>

        <div id="alerta" runat="server" class="is-flex is-justify-content-center"></div>

        <div class="field">
            <asp:Label ID="lbEmail" runat="server" Text="Email" CssClass="label is-flex is-justify-content-center" />
            <div class="control">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="input"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Campo obligatorio" Display="Dynamic" CssClass="help is-danger" />
            <asp:RegularExpressionValidator ID="regexEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email invalido" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" CssClass="help is-danger" />
        </div>

        <div class="field">
            <asp:Label ID="lbPassword" runat="server" Text="Password" CssClass="label is-flex is-justify-content-center" />
            <div class="control">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Campo obligatorio" Display="Dynamic" CssClass="help is-danger" />
        </div>

        <div class="mt-2 mb-6 is-flex is-justify-content-center">
            <asp:LinkButton ID="lbRegistrarse" runat="server" OnClick="lbRegistrarse_Click" CausesValidation="false">¿No tienes una cuenta? Regístrate</asp:LinkButton>
        </div>

        <asp:Button ID="btnAceptar" runat="server" Text="Iniciar Sesion" OnClick="btnAceptar_Click" CssClass="button is-primary is-flex is-justify-content-center" />

    </div>
</asp:Content>
