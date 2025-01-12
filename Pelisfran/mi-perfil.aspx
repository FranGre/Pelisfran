<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="mi-perfil.aspx.cs" Inherits="Pelisfran.mi_perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@24,400,0,0&icon_names=check" />
    <link rel="stylesheet" href="https://unpkg.com/dropzone@5/dist/min/dropzone.min.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 id="titulo" runat="server" class="title is-2 mb-6 is-flex is-justify-content-center">Mi Perfil</h2>

    <div class="notification is-success is-display-inline-block is-center" id="alerta" runat="server">
        <div class="is-flex is-justify-content-center buttons">
            <span class="material-symbols-outlined">check</span>
            <p>
                Perfil actualizado
            </p>
            <button class="delete ml-3"></button>
        </div>
    </div>

    <div class="columns box is-column-gap-6 my-6">
        <div class="column">
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
                <asp:Label ID="lbFotoPerfil" runat="server" Text="FotoPerfil" CssClass="label is-flex is-justify-content-center" />
                <div id="fotoPerfil" class="dropzone"></div>
            </div>

        </div>

        <div class="column">
            <div class="field">
                <asp:Label ID="lbNombre" runat="server" Text="Nombre" CssClass="label is-flex is-justify-content-center" />
                <div class="control">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="input" />
                </div>
                <asp:RequiredFieldValidator ID="reqNombre" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="Campo obligatorio" Display="Dynamic" CssClass="help is-danger" />
                <asp:RegularExpressionValidator ID="regexNombre" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="Maximo 40 caracteres" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9]{1,40}$" CssClass="help is-danger" />
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

            <div class="field">
                <asp:Label ID="lbApellidos" runat="server" Text="Apellidos" CssClass="label is-flex is-justify-content-center" />
                <div class="control">
                    <asp:TextBox ID="txtApellidos" runat="server" CssClass="input" />
                </div>
                <asp:RegularExpressionValidator ID="regexApellidos" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="Maximo 50 caracteres" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9]{1,50}$" CssClass="help is-danger" />
            </div>
        </div>
    </div>

    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button is-primary" OnClick="btnGuardar_Click" />

    <script src="https://code.jquery.com/jquery-3.7.1.slim.js" integrity="sha256-UgvvN8vBkgO0luPSUl2s8TIlOSYRoGFAX4jlCIm9Adc=" crossorigin="anonymous"></script>
    <script src="https://unpkg.com/dropzone@5/dist/min/dropzone.min.js"></script>

    <script type="text/javascript">
        Dropzone.autoDiscover = false;

        $("#fotoPerfil").dropzone({
            url: "/Handlers/Dropzone/FotoPerfil.ashx?id=<%= HttpContext.Current.User.Identity.Name %>",
            maxFilesize: 3,
            dictDefaultMessage: "Suba su foto de perfil",
            dictFileTooBig: "Imagen muy grande ({{filesize}}MiB). Se permite hasta: {{maxFilesize}}MiB.",
            dictInvalidFileType: "Fichero no permitido.",
            success(file) {
                if (file.previewElement) {
                    return file.previewElement.classList.add("dz-success");
                }
            }
        });
    </script>
</asp:Content>
