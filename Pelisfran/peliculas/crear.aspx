<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="crear.aspx.cs" Inherits="Pelisfran.peliculas.crear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href='<%=ResolveUrl("~/Content/FilePond/filepond.css")%>' rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <input type="hidden" id="originalFileName" name="originalFileName" />
    <input type="hidden" id="tempFileName" name="tempFileName" />

    <div>
        <asp:Label ID="lbTitulo" runat="server">Titulo</asp:Label>
        <asp:TextBox ID="txtTitulo" runat="server" />
        <asp:RequiredFieldValidator ID="reqTitulo" runat="server" ControlToValidate="txtTitulo" ErrorMessage="Campo obligatorio" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="regexTitulo" runat="server" ControlToValidate="txtTitulo" ErrorMessage="Maximo 50 caracteres" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9\s]{1,50}$" />
    </div>

    <div>
        <input type="file" class="filepond-video" />
    </div>

    <div>
        <asp:Label ID="lbSinopsisBreve" runat="server" Text="Sinopsis" />
        <asp:TextBox ID="txtSinopsisBreve" runat="server" TextMode="MultiLine" />
        <asp:RequiredFieldValidator ID="reqSinopsisBreve" runat="server" ControlToValidate="txtSinopsisBreve" ErrorMessage="Campo obligatorio" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="regexSinopsisBreve" runat="server" ControlToValidate="txtSinopsisBreve" ErrorMessage="Maximo 50 caracteres" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9\s]{1,350}$" />
    </div>

    <div>
        <asp:Label ID="lbFechaLanzamiento" runat="server" Text="Fecha Lanzamiento" />
        <asp:TextBox ID="txtFechaLanzamiento" runat="server" TextMode="Date" />
        <asp:RequiredFieldValidator ID="reqFechaLanzamiento" runat="server" ControlToValidate="txtFechaLanzamiento" ErrorMessage="Campo obligatorio" Display="Dynamic" />
        <asp:RangeValidator ID="rangeFechaLanzamiento" runat="server" ControlToValidate="txtFechaLanzamiento" Display="Dynamic" Type="Date"></asp:RangeValidator>
    </div>

    <div>
        <asp:Label ID="lbDuracion" runat="server" Text="Duracion" />
        <asp:TextBox ID="txtDuracion" runat="server" TextMode="Number" />
        <asp:RequiredFieldValidator ID="reqDuracion" runat="server" ControlToValidate="txtDuracion" ErrorMessage="Campo obligatorio" Display="Dynamic" />
        <asp:RangeValidator ID="rangeDuracion" runat="server" ControlToValidate="txtDuracion" ErrorMessage="Debe estar entre 1 y 300" Display="Dynamic" Type="Integer" MinimumValue="1" MaximumValue="300"></asp:RangeValidator>
    </div>

    <div>
        <asp:Repeater ID="repGeneros" runat="server" OnItemDataBound="repGeneros_ItemDataBound">
            <ItemTemplate>
                <asp:CheckBox ID="cbGenero" runat="server" />
            </ItemTemplate>
        </asp:Repeater>
        <span id="reqGeneros" runat="server" />
    </div>

    <div>
        <asp:Label ID="lbPortada" runat="server" Text="Portada" />
        <input type="file" name="fuPortada" runat="server" class="filepond-portada" />
        <span id="reqPortada" runat="server" />
    </div>

    <asp:Button ID="btnAceptar" runat="server" Text="Crear" OnClick="btnAceptar_Click" />

    <script src="<%=ResolveUrl("~/Scripts/FilePond/filepond.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/Scripts/FilePond/plugins/filepond-plugin-file-validate-type.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/Scripts/FilePond/plugins/filepond-plugin-file-validate-size.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/Scripts/FilePond/plugins/filepond-plugin-image-preview.js")%>" type="text/javascript"></script>


    <script>
        FilePond.registerPlugin(FilePondPluginFileValidateType);
        FilePond.registerPlugin(FilePondPluginFileValidateSize);
        FilePond.registerPlugin(FilePondPluginImagePreview);
        FilePond.create(document.querySelector(".filepond-portada"), {
            server: {
                process:
                {
                    url: '/Handlers/HttpHandlerImagenTemporal.ashx',
                    ondata: (formData) => {
                        // Aquí no es necesario procesar respuesta en `ondata`
                        return formData;
                    },
                    onload: (response) => {
                        // Aquí se procesa la respuesta del servidor
                        const jsonResponse = JSON.parse(response);
                        console.log("onLoad", jsonResponse);
                        const originalFileName = jsonResponse.originalFileName;
                        const tempFileName = jsonResponse.tempFileName;

                        // Asignamos los valores a los campos ocultos
                        document.getElementById("originalFileName").value = originalFileName;
                        document.getElementById("tempFileName").value = tempFileName;
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

    </script>
</asp:Content>
