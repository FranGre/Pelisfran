<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModalConfirmar.ascx.cs" Inherits="Pelisfran.Controles.Modales.ModalConfirmar" %>

<div class="modal" id="modal">
    <div class="modal-card">
        <header class="modal-card-head">
            <p class="modal-card-title">Estas seguro?</p>
            <button class="delete" aria-label="close" onclick="cerrarModal()"></button>
        </header>
        <section class="modal-card-body">
            <p>Este es un ejemplo de modal.</p>
        </section>
        <footer class="modal-card-foot">
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            <button class="button" onclick="cerrarModal()">Cerrar</button>
        </footer>
    </div>
</div>

<script type="text/javascript">
    function mostrarModal() {
        document.getElementById("modal").classList.add("is-active");
    }

    function cerrarModal() {
        document.getElementById("modal").classList.remove("is-active");
    }
</script>
