using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using FirstMVCApp.ViewModels;
using FirstMVCApp.ControllerModel;
using FirstMVCApp.RepoUnitOfWork;

namespace FirstMVCApp.Controllers
{
    
    public class MembersController : DefaultController<MemberModel, MembersRepository>
    {
        
        public MembersController(UnitOfWork unitOfWork) : base(unitOfWork.MembersRepository) { }


        public IActionResult DetailsWithCodeSnippets(Guid id)
        {
            MemberCodeSnippetsViewModel viewModel = _repository.GetMemberCodeSnippets(id);
            return View("DetailsWithCodeSnippets", viewModel);
        }
    }
}
