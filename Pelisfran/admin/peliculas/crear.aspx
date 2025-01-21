<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="crear.aspx.cs" Inherits="Pelisfran.admin.peliculas.crear" %>

<%@ Register Src="~/Controles/CheckBoxLists/CheckBoxListGeneros.ascx" TagPrefix="controles" TagName="checkboxListGeneros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="csrf-token" content="@Html.AntiForgeryToken()" />
    <link href='<%=ResolveUrl("~/Content/FilePond/filepond.css")%>' rel="stylesheet" />
    <link rel="stylesheet" href="https://unpkg.com/dropzone@5/dist/min/dropzone.min.css" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 id="titulo" runat="server" class="title is-2 mb-6 is-flex is-justify-content-center">Crear Película</h2>

    <input type="hidden" id="originalFileName" name="originalFileName" />
    <input type="hidden" id="tempFileName" name="tempFileName" />
    <div class="columns">
        <div class="column">
            <div class="field">
                <asp:Label ID="lbTitulo" runat="server" CssClass="label">Título</asp:Label>
                <div class="control">
                    <asp:TextBox ID="txtTitulo" runat="server" CssClass="input" />
                </div>
                <asp:RequiredFieldValidator ID="reqTitulo" runat="server" ControlToValidate="txtTitulo" ErrorMessage="Campo obligatorio" Display="Dynamic" CssClass="help is-danger" />
                <asp:RegularExpressionValidator ID="regexTitulo" runat="server" ControlToValidate="txtTitulo" ErrorMessage="Maximo 50 caracteres" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9\s]{1,50}$" CssClass="help is-danger" />
            </div>

            <div class="field">
                <asp:Label ID="lbPelicula" runat="server" Text="Película" CssClass="label" />
                <div class="control">
                    <div id="video" class="dropzone">
                        <!-- Los archivos se soltarán aquí -->
                    </div>
                </div>
            </div>

            <div class="field">
                <asp:Label ID="lbSinopsisBreve" runat="server" Text="Sinopsis" CssClass="label" />
                <div class="control">
                    <asp:TextBox ID="txtSinopsisBreve" runat="server" TextMode="MultiLine" CssClass="input" />
                </div>
                <asp:RequiredFieldValidator ID="reqSinopsisBreve" runat="server" ControlToValidate="txtSinopsisBreve" ErrorMessage="Campo obligatorio" Display="Dynamic" CssClass="help is-danger" />
                <asp:RegularExpressionValidator ID="regexSinopsisBreve" runat="server" ControlToValidate="txtSinopsisBreve" ErrorMessage="Maximo 1000 caracteres" Display="Dynamic" ValidationExpression="^(.|\n){1,1000}$" CssClass="help is-danger" />
            </div>
        </div>
        <div class="column">
            <div class="field">
                <asp:Label ID="lbFechaLanzamiento" runat="server" Text="Fecha Lanzamiento" CssClass="label" />
                <div class="control">
                    <asp:TextBox ID="txtFechaLanzamiento" runat="server" TextMode="Date" CssClass="input" />
                </div>
                <asp:RequiredFieldValidator ID="reqFechaLanzamiento" runat="server" ControlToValidate="txtFechaLanzamiento" ErrorMessage="Campo obligatorio" Display="Dynamic" CssClass="help is-danger" />
                <asp:RangeValidator ID="rangeFechaLanzamiento" runat="server" ControlToValidate="txtFechaLanzamiento" Display="Dynamic" Type="Date" CssClass="help is-danger"></asp:RangeValidator>
            </div>

            <div class="field">
                <asp:Label ID="lbDuracion" runat="server" Text="Duración" CssClass="label" />
                <div class="control">
                    <asp:TextBox ID="txtDuracion" runat="server" TextMode="Number" CssClass="input" />
                </div>
                <asp:RequiredFieldValidator ID="reqDuracion" runat="server" ControlToValidate="txtDuracion" ErrorMessage="Campo obligatorio" Display="Dynamic" CssClass="help is-danger" />
                <asp:RangeValidator ID="rangeDuracion" runat="server" ControlToValidate="txtDuracion" ErrorMessage="Debe estar entre 1 y 300" Display="Dynamic" Type="Integer" MinimumValue="1" MaximumValue="300" CssClass="help is-danger"></asp:RangeValidator>
            </div>

            <div class="field">
                <asp:Label ID="lbGeneros" runat="server" Text="Género/s" CssClass="label" />
                <div class="control">
                    <controles:checkboxListGeneros ID="generos" runat="server" />
                </div>

                <span id="reqGeneros" runat="server" class="help is-danger" />
            </div>

            <div class="field">
                <asp:Label ID="lbPortada" runat="server" Text="Portada" CssClass="label" />
                <div class="control">
                    <input type="file" name="fuPortada" runat="server" class="filepond-portada" cssclass="label" />
                </div>
                <span id="reqPortada" runat="server" class="help is-danger" />
            </div>
        </div>
    </div>

    <asp:Button ID="btnAceptar" runat="server" Text="Crear" OnClick="btnAceptar_Click" CssClass="button is-success" />

    <script src="<%=ResolveUrl("~/Scripts/FilePond/filepond.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/Scripts/FilePond/plugins/filepond-plugin-file-validate-type.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/Scripts/FilePond/plugins/filepond-plugin-file-validate-size.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/Scripts/FilePond/plugins/filepond-plugin-image-preview.js")%>" type="text/javascript"></script>
    <script src="https://unpkg.com/dropzone@5/dist/min/dropzone.min.js"></script>

    <script type="text/javascript">
        FilePond.registerPlugin(FilePondPluginFileValidateType);
        FilePond.registerPlugin(FilePondPluginFileValidateSize);
        FilePond.registerPlugin(FilePondPluginImagePreview);
        FilePond.create(document.querySelector(".filepond-portada"), {
            server: {
                process:
                {
                    url: '/Handlers/HttpHandlerImagenTemporal.ashx',
                    ondata: (formData) => {
                        return formData;
                    },
                    onload: (response) => {
                        const jsonResponse = JSON.parse(response);

                        document.getElementById("originalFileName").value = jsonResponse.originalFileName;
                        document.getElementById("tempFileName").value = jsonResponse.tempFileName;
                    },
                }
            },

            acceptedFileTypes: ['image/webp', 'image/jpg', 'image/jpeg'],
            fileValidateTypeLabelExpectedTypes: 'Admite .webp .jpg .jpeg',
            labelFileTypeNotAllowed: 'Archivo no válido',

            allowFileSizeValidation: true,
            maxFileSize: 1 * 1024 * 1024,
            labelMaxFileSizeExceeded: 'Fichero pesa mucho',
            labelMaxFileSize: 'Máximo de 1 MB',

            allowImagePreview: true
        });

        let myDropzone = new Dropzone("div#video", {
            paramName: "file",
            url: "/Handlers/HttpHandlerVideoTemporal.ashx",
            maxFilesize: 10 * 1024 * 1024 * 1024,
            chunking: true,
            foreChunking: true,
            chunkSize: 2000000,
            retryChunks: true,
            retryChunksLimit: 3,
            init: function () {
                this.on("complete", function (file) {
                    console.log("Archivo subido:", file);
                });
            },
            init: function () {
                this.on("sending", function (file, xhr, formData) {
                    formData.append("name", file.name); // Asegúrate de incluir el nombre del archivo
                });
            }
        });

    </script>
</asp:Content>
