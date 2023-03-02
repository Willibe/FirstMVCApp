using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.ControllerModel
{
    public partial class DefaultController<T> : Controller where T : class, new()
    {
        protected readonly IClubDataRepository<T> _repository;

        public DefaultController(IClubDataRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual IActionResult Index()
        {
            var model = _repository.GetAll();
            return View("Index", model);
        }

        public virtual IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public virtual IActionResult Create(IFormCollection collection)
        {
            T model = new T();
            TryUpdateModelAsync(model); // 1-1 Mapping from collection object to the model object
            _repository.Add(model);
            return RedirectToAction("Index");
        }


        public virtual IActionResult Edit(Guid id)
        {
            T model = _repository.GetById(id);
            return View("Edit", model);
        }

        [HttpPost]
        public virtual IActionResult Edit(Guid id, IFormCollection collection)
        {
            T model = new T();
            TryUpdateModelAsync(model);
            _repository.Update(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public virtual IActionResult Delete(Guid id)
        {
            T model = _repository.GetById(id);
            return View("Delete", model);
        }


        [HttpPost]
        public virtual IActionResult Delete(Guid id, IFormCollection notUsed)
        {

            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public virtual IActionResult Details(Guid id)
        {
            T announcement = _repository.GetById(id);
            return View("Details", announcement);
        }
    }
}
