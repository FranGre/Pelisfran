<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Site1.Master" AutoEventWireup="true" CodeBehind="crear.aspx.cs" Inherits="Pelisfran.peliculas.crear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div>
        <asp:Label ID="lbTitulo" runat="server">Titulo</asp:Label>
        <asp:TextBox ID="txtTitulo" runat="server" />
        <asp:RequiredFieldValidator ID="reqTitulo" runat="server" ControlToValidate="txtTitulo" ErrorMessage="Campo obligatorio" Display="Dynamic" />
    </div>

    <div>
        <asp:Label ID="lbSinopsisBreve" runat="server" Text="Sinopsis" />
        <asp:TextBox ID="txtSinopsisBreve" runat="server" TextMode="MultiLine" />
        <asp:RequiredFieldValidator ID="reqSinopsisBreve" runat="server" ControlToValidate="txtSinopsisBreve" ErrorMessage="Campo obligatorio" Display="Dynamic" />
    </div>

    <div>
        <asp:Label ID="lbFechaLanzamiento" runat="server" Text="Fecha Lanzamiento" />
        <asp:TextBox ID="txtFechaLanzamiento" runat="server" TextMode="Date" />
        <asp:RequiredFieldValidator ID="reqFechaLanzamiento" runat="server" ControlToValidate="txtFechaLanzamiento" ErrorMessage="Campo obligatorio" Display="Dynamic" />
    </div>

    <div>
        <asp:Label ID="lbDuracion" runat="server" Text="Duracion" />
        <asp:TextBox ID="txtDuracion" runat="server" TextMode="Number" />
        <asp:RequiredFieldValidator ID="reqDuracion" runat="server" ControlToValidate="txtDuracion" ErrorMessage="Campo obligatorio" Display="Dynamic" />
    </div>

    <div>
        <asp:Repeater ID="repGeneros" runat="server" OnItemDataBound="repGeneros_ItemDataBound">
            <ItemTemplate>
                <asp:CheckBox ID="cbGenero" runat="server" />
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <asp:Button ID="btnAceptar" runat="server" Text="Crear" OnClick="btnAceptar_Click" />
</asp:Content>
