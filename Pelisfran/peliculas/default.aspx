<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/Base.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Pelisfran.peliculas._default" %>

<%@ Register Src="~/Controles/CheckBoxLists/CheckBoxListGeneros.ascx" TagPrefix="controles" TagName="checkboxListGeneros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2 class="title is-2 mb-6">Peliculas</h2>

    <controles:checkboxListGeneros ID="generos" runat="server" />

    <div class="field is-grouped">
        <div class="control is-expanded">
            <asp:TextBox ID="tbBusqueda" runat="server" placeholder="Buscar Pelicula..." CssClass="input"></asp:TextBox>
        </div>
        <div class="control">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="button is-info" />
        </div>
    </div>

    <asp:UpdatePanel ID="upPeliculas" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBuscar" />
        </Triggers>
        <ContentTemplate>
            <div class="mt-6">
                <p id="pPeliculasNoEncontradas" runat="server"></p>

                <asp:Repeater ID="repPeliculas" runat="server" OnItemDataBound="repPeliculas_ItemDataBound">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnVer" runat="server" Text="Ver" OnClick="btnVer_Click">
                            <div>
                                <asp:Image ID="portada" runat="server" />
                                <asp:Literal ID="titulo" runat="server"></asp:Literal>
                                <asp:Literal ID="fechaLanzamiento" runat="server"></asp:Literal>
                            </div>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
