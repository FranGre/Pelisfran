<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Pelisfran.peliculas._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Peliculas</h2>
            <asp:Repeater ID="repPeliculas" runat="server" OnItemDataBound="repPeliculas_ItemDataBound">
                <ItemTemplate>
                    <div>
                        <asp:Literal id="titulo" runat="server"></asp:Literal>
                        <asp:Literal id="fechaLanzamiento" runat="server"></asp:Literal>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
