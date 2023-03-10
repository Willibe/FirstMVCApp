using FirstMVCApp.Repositories;
using FirstMVCApp.ControllerModel;
using FirstMVCApp.Models;
using FirstMVCApp.RepoUnitOfWork;

namespace FirstMVCApp.Controllers
{
    public class MembershipsController : DefaultController<MembershipModel, MembershipsRepository>
    {

        public MembershipsController(UnitOfWork unitOfWork) : base(unitOfWork.MembershipsRepository) { }

    }
}
