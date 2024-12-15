<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Pelisfran.peliculas._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Peliculas</h2>
            <div>
                <asp:TextBox ID="tbBusqueda" runat="server" placeholder="Buscar Pelicula..."></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Lupa" OnClick="btnBuscar_Click" />
            </div>
            <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="upPeliculas" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnBuscar" />
                </Triggers>
                <ContentTemplate>
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
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>
</body>
</html>
