using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Interfaces;
using Cadastro.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cadastro.Domain.Interfaces;

namespace Cadastro.Controllers
{
    public class ProductController : Controller
    {

        private readonly IClientRepository _clientRepository;
        private readonly IProductViewModelService _productViewModelService;
        public ProductController(IProductViewModelService productViewModelService, IClientRepository clientRepository)
        {
            _productViewModelService = productViewModelService;
            _clientRepository = clientRepository;
        }

        // GET: Products
        public ActionResult Index()
        {
            var list = _productViewModelService.GetAll();

            return View(list);
        }

        // GET: Products/Details/Get
        public ActionResult Details(int id)
        {
            var viewModel = _productViewModelService.Get(id);
            return View(viewModel);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            PopulateClientsDropDownList();
            return View();
        }

        // POST: Products/Create/Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel)
        {
            try
            {
              
                if (ModelState.IsValid)
                {
                   _productViewModelService.Insert(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }


        private void PopulateClientsDropDownList(object selectedClient = null)
        {
            var clients = _clientRepository.GetAll();

            ViewBag.IdCliente = new SelectList(clients, "Id", "Name", selectedClient);
        }

        // GET: Products/Edit/Get
        public ActionResult Edit(int id)
        {
         
            var viewModel = _productViewModelService.Get(id);
            PopulateClientsDropDownList(viewModel.IdCliente);

            return View(viewModel);
        }

        // POST: Products/Edit/Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   _productViewModelService.Update(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Product/Delete/Get
        public ActionResult Delete(int id)
        {
            var viewModel = _productViewModelService.Get(id);
            return View(viewModel);
        }

        // POST: Product/Delete/Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productViewModelService.Delete(id);

                    return RedirectToAction(nameof(Index));
                }

                var viewModel = _productViewModelService.Get(id);
                return View(viewModel);
            }
            catch
            {
                var viewModel = _productViewModelService.Get(id);
                return View(viewModel);
            }




        }
    }
}
