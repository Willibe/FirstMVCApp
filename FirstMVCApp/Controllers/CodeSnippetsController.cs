using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using FirstMVCApp.ControllerModel;


namespace FirstMVCApp.Controllers
{
    public class CodeSnippetsController : DefaultController<CodeSnippetModel>
    {

        public CodeSnippetsController(IClubDataRepository<CodeSnippetModel> repository) : base(repository) { }

    }
}
