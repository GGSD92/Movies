using Microsoft.AspNetCore.Mvc;
using OneData.Extensions;
using Movies.Models;
using System;
using Movies.ViewModels;
using Movies.Enums;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", GetNewViewModel(ActionTypes.Catalog));
        }

        private MoviesViewModel GetNewViewModel(ActionTypes actionType, Guid ? id = null)
        {

            MoviesViewModel viewModel = new MoviesViewModel();
            viewModel.ActionTypes = actionType;
            viewModel.Selected = id == null ? new Movie() : Movie.Select(x => x.Id == id.GetValueOrDefault());
            viewModel.Origins = Origin.SelectAll();
            viewModel.Genders = Gender.SelectAll();
            viewModel.Peliculas = Movie.SelectAll();

            return viewModel;
        }

        [HttpPost]
        public ActionResult SaveAdd(MoviesViewModel viewModel)
        {

            viewModel.Selected.Insert();
            return PartialView($"Index", GetNewViewModel(ActionTypes.Catalog));
        }


        [HttpGet]
        public IActionResult GetEditView(Guid id)
        {
            return PartialView($"_Edit", GetNewViewModel(ActionTypes.Edit, id));
        }

        public IActionResult GetAddView()
        {
            return PartialView($"_Edit", GetNewViewModel(ActionTypes.Add));
        }

        [HttpPost]
        public ActionResult SaveEdit(MoviesViewModel viewModel, Guid? searchId)
        {
            viewModel.Selected.Update();
   
            return PartialView($"Index", GetNewViewModel(ActionTypes.Catalog));
           

        }


        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            MoviesViewModel viewModel = new MoviesViewModel();
            new Movie(id).Delete();
            return PartialView($"Index", GetNewViewModel(ActionTypes.Catalog));
        }


    }
}