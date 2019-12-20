using Microsoft.AspNetCore.Mvc;
using OneData.Extensions;
using Movies.Models;
using System;
using Movies.ViewModels;
using Movies.Enums;

namespace Movies.Controllers
{
    public class OriginsController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", GetNewOriginsViewModel(ActionTypes.Catalog));
        }

        private OriginsViewModel GetNewOriginsViewModel(ActionTypes actionType, Guid? id = null)
        {

            OriginsViewModel viewModel = new OriginsViewModel();
            viewModel.ActionTypes = actionType;
            viewModel.Selected = id == null ? new Origin() : Origin.Select(x => x.Id == id.GetValueOrDefault());
            viewModel.Origenes = Origin.SelectAll();
            //viewModel.Genders = Gender.SelectAll();
            //viewModel.Peliculas = Movie.SelectAll();

            return viewModel;
        }

        [HttpPost]
        public ActionResult SaveAdd(OriginsViewModel viewModel)
        {

            viewModel.Selected.Insert();
            return PartialView($"Index", GetNewOriginsViewModel(ActionTypes.Catalog));
        }


        [HttpGet]
        public IActionResult GetEditView(Guid id)
        {
            return PartialView($"_Edit", GetNewOriginsViewModel(ActionTypes.Edit, id));
        }

        public IActionResult GetAddView()
        {
            return PartialView($"_Edit", GetNewOriginsViewModel(ActionTypes.Add));
        }

        [HttpPost]
        public ActionResult SaveEdit(OriginsViewModel viewModel, Guid? searchId)
        {
            viewModel.Selected.Update();

            return PartialView($"Index", GetNewOriginsViewModel(ActionTypes.Catalog));


        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            OriginsViewModel viewModel = new OriginsViewModel();
            new Origin(id).Delete();
            return PartialView($"Index", GetNewOriginsViewModel(ActionTypes.Catalog));
        }


    }
}