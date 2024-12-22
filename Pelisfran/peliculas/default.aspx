<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Pelisfran.peliculas._default" %>

<%@ Register Src="~/Controles/CheckBoxLists/CheckBoxListGeneros.ascx" TagPrefix="controles" TagName="checkboxListGeneros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 class="">Peliculas</h2>
    <controles:checkboxListGeneros ID="generos" runat="server" />
    <div>
        <asp:TextBox ID="tbBusqueda" runat="server" placeholder="Buscar Pelicula..."></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Lupa" OnClick="btnBuscar_Click" />
    </div>
    <asp:UpdatePanel ID="upPeliculas" runat="server" UpdateMode="Conditional">
        <triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBuscar" />
        </triggers>
        <contenttemplate>
            <p id="pPeliculasNoEncontradas" runat="server"></p>

            <asp:Repeater ID="repPeliculas" runat="server" OnItemDataBound="repPeliculas_ItemDataBound">
                <itemtemplate>
                    <asp:LinkButton ID="btnVer" runat="server" Text="Ver" OnClick="btnVer_Click">
                        <div>
                            <asp:Image ID="portada" runat="server" />
                            <asp:Literal ID="titulo" runat="server"></asp:Literal>
                            <asp:Literal ID="fechaLanzamiento" runat="server"></asp:Literal>
                        </div>
                    </asp:LinkButton>
                </itemtemplate>
            </asp:Repeater>
        </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
