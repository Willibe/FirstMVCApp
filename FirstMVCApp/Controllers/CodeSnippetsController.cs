using FirstMVCApp.Models;
using FirstMVCApp.ControllerModel;
using FirstMVCApp.Repositories;
using FirstMVCApp.RepoUnitOfWork;

namespace FirstMVCApp.Controllers
{
    public class CodeSnippetsController : DefaultController<CodeSnippetModel, CodeSnippetRepository>
    {
        private readonly IClubDataRepository<MemberModel> _memberRepository;

        public CodeSnippetsController(UnitOfWork unitOfWork) : base(unitOfWork.CodeSnippetRepository)
        {
            _memberRepository = unitOfWork.MembersRepository;
        }


        public override IActionResult Create()
        {
            var members = _memberRepository.GetAll();
            ViewBag.data = members;
            
            return View("Create");
        }

    }
}
