<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="crear.aspx.cs" Inherits="Pelisfran.generos.crear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 id="titulo" runat="server" class="title is-2 mb-6 is-flex is-justify-content-center">Crear Genero</h2>

    <div class="field">
        <asp:Label ID="lbNombre" runat="server" Text="Nombre" CssClass="label" />
        <div class="control">
            <asp:TextBox ID="txtNombre" runat="server" CssClass="input" />
        </div>
        <asp:RequiredFieldValidator ID="reqNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Campo obligatorio" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="regexNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Maximo 40 caracteres" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9\s]{1,40}$" />
    </div>

    <asp:Button ID="btnAceptar" runat="server" Text="Crear" OnClick="btnAceptar_Click" CssClass="button is-primary" />
</asp:Content>
