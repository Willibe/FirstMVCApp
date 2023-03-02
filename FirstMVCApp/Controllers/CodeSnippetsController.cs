using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FirstMVCApp.ControllerModel;


namespace FirstMVCApp.Controllers
{
    public class CodeSnippetsController : DefaultController<CodeSnippetModel>
    {

        public CodeSnippetsController(IClubDataRepository<CodeSnippetModel> repository) : base(repository) { }

    }
}
