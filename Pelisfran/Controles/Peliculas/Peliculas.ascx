<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Peliculas.ascx.cs" Inherits="Pelisfran.Controles.Peliculas.Peliculas" %>

<div class="mt-6">
    <p id="pPeliculasNoEncontradas" runat="server"></p>
    <div class="columns is-multiline">
        <asp:Repeater ID="repPeliculas" runat="server" OnItemDataBound="repPeliculas_ItemDataBound">
            <ItemTemplate>
                <div class="column is-6-mobile is-4-tablet is-2-desktop">
                    <asp:LinkButton ID="btnVer" runat="server" Text="Ver" OnClick="btnVer_Click">
                        <div class="card">
                            <div class="card-image">
                                <asp:Image ID="portada" runat="server" CssClass="image is-3by5" />
                            </div>

                            <div class="card-content">
                                <div class="content">
                                    <asp:Label ID="titulo" runat="server" CssClass="is-flex is-justify-content-center"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
