using FirstMVCApp.ControllerModel;
using FirstMVCApp.Models;
using FirstMVCApp.Repositories;

namespace FirstMVCApp.Controllers
{
    public class MembershipsController : DefaultController<MembershipModel>
    {

        public MembershipsController(IClubDataRepository<MembershipModel> repository) : base(repository) { }

    }
}
