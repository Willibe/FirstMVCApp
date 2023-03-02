using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using FirstMVCApp.ControllerModel;
using Microsoft.Identity.Client;

namespace FirstMVCApp.Controllers
{
    public class MembersController : DefaultController<MemberModel>
    {

        public MembersController(IClubDataRepository<MemberModel> repository) : base(repository) { }





    }
}
