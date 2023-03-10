using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.ControllerModel
{
    public class DefaultController<TEntity, TRepository> : Controller where TEntity : class, new() where TRepository : IClubDataRepository<TEntity>
    {
        protected readonly TRepository _repository;

        public DefaultController(TRepository repository)
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
            TEntity model = new TEntity();
            TryUpdateModelAsync(model); // 1-1 Mapping from collection object to the model object
            _repository.Add(model);
            return RedirectToAction("Index");
        }


        public virtual IActionResult Edit(Guid id)
        {
            TEntity model = _repository.GetById(id);
            return View("Edit", model);
        }

        [HttpPost]
        public virtual IActionResult Edit(Guid id, IFormCollection collection)
        {
            TEntity model = new TEntity();
            TryUpdateModelAsync(model);
            _repository.Update(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public virtual IActionResult Delete(Guid id)
        {
            TEntity model = _repository.GetById(id);
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
            TEntity announcement = _repository.GetById(id);
            return View("Details", announcement);
        }
    }
}
