<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BotonCrear.ascx.cs" Inherits="Pelisfran.Controles.Botones.BotonCrear" %>

<button id="buttonCrear" runat="server" onserverclick="buttonCrear_ServerClick" class="button is-success is-flex is-align-items-center" causesvalidation="false">
    <i class="fa-solid fa-plus"></i>
    <p id="text" runat="server" class="pl-1"></p>
</button>
