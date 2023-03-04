using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using FirstMVCApp.ControllerModel;

namespace FirstMVCApp.Controllers
{
    public class MembersController : DefaultController<MemberModel>
    {

        public MembersController(IClubDataRepository<MemberModel> repository) : base(repository) { }

    }
}
