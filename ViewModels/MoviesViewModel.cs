using Movies.Enums;
using Movies.Models;
using System.Collections.Generic;

namespace Movies.ViewModels
{
    public class MoviesViewModel : BaseCatalogViewModel
    {
        public List<Movie> Peliculas { get; set; }
        public Movie Selected { get; set; }

        public bool IsNew { get; set; }

        public IEnumerable<Origin> Origins { get; set; }

        public IEnumerable<Gender> Genders { get; set; }
    }
}
