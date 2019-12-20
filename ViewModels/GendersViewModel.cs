using Movies.Models;
using System.Collections.Generic;

namespace Movies.ViewModels
{
    public class GendersViewModel : BaseCatalogViewModel
    {
        public List<Gender> Genders { get; set; }

        public Gender Selected { get; set; }

    }
}