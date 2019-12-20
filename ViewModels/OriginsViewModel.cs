using Movies.Models;
using System.Collections.Generic;

namespace Movies.ViewModels
{
    public class OriginsViewModel : BaseCatalogViewModel
    {
        public List<Origin> Origenes { get; set; }

        public Origin Selected { get; set; }
    }
}