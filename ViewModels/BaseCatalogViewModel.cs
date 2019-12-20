using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.Enums;

namespace Movies.ViewModels
{
    public class BaseCatalogViewModel
    {
        public string ControllerName { get; set; }
        public ActionTypes ActionTypes { get; set; }
    }
}
