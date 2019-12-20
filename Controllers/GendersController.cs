using Microsoft.AspNetCore.Mvc;
using OneData.Extensions;
using Movies.Models;
using System;
using Movies.ViewModels;
using Movies.Enums;
using OneData.Models;
using OneData.DAO;

namespace Movies.Controllers
{
    public class GendersController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", GetNewViewModel(ActionTypes.Catalog));
        }

        private GendersViewModel GetNewViewModel(ActionTypes actionType, Guid? id = null)
        {

            GendersViewModel viewModel = new GendersViewModel();
            viewModel.ActionTypes = actionType;
            viewModel.Genders = Gender.SelectAll();

            return viewModel;
        }


        [HttpPost]
        public ActionResult SaveAdd(GendersViewModel viewModel)
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
        public ActionResult SaveEdit(GendersViewModel viewModel, Guid? searchId)
        {
            viewModel.Selected.Update();

            return PartialView($"Index", GetNewViewModel(ActionTypes.Catalog));


        }


        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            GendersViewModel viewModel = new GendersViewModel();
            new Gender(id).Delete();
            return PartialView($"Index", GetNewViewModel(ActionTypes.Catalog));
        }


    }
}