﻿using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Pelisfran.Core;

namespace Pelisfran.peliculas
{
    public partial class favoritas : Base
    {
        private PeliculaFavoritaServicio _peliculaFavoritaServicio = new PeliculaFavoritaServicio();
        private PeliculaServicio _peliculaServicio = new PeliculaServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<PeliculaFavorita> misPeliculasFavoritas = _peliculaFavoritaServicio.ObtenerPeliculasMarcadasComoFavoritasDelUsuario(this.usuarioId);
                repPeliculas.DataSource = misPeliculasFavoritas;
                repPeliculas.DataBind();
            }
        }

        protected void repPeliculas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Image portada = (Image)e.Item.FindControl("portada");
            HtmlGenericControl titulo = (HtmlGenericControl)e.Item.FindControl("titulo");
            Button btnFavorito = (Button)e.Item.FindControl("btnFavorito");

            PeliculaFavorita miPeliculaFavorita = (PeliculaFavorita)e.Item.DataItem;
            Pelicula pelicula = _peliculaServicio.ObtenerPeliculaIncluidaPortada(miPeliculaFavorita.PeliculaId);

            var imageUrl = ResolveUrl($"{pelicula.PortadaPelicula.Ruta}/{pelicula.PortadaPelicula.NombreOriginal}");
            portada.ImageUrl = imageUrl;
            titulo.InnerText = pelicula.Titulo;
            btnFavorito.Text = "Eliminar de Favoritos";
            btnFavorito.CommandArgument = pelicula.Id.ToString();
        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            Guid peliculaId = Guid.Parse(((Button)sender).CommandArgument);
            _peliculaFavoritaServicio.DesmarcarPeliculaComoFavorita(this.usuarioId, peliculaId);
            List<PeliculaFavorita> misPeliculasFavoritas = _peliculaFavoritaServicio.ObtenerPeliculasMarcadasComoFavoritasDelUsuario(this.usuarioId);
            repPeliculas.DataSource = misPeliculasFavoritas;
            repPeliculas.DataBind();
        }
    }
}