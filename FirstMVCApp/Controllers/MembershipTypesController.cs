using FirstMVCApp.Models;
using FirstMVCApp.ControllerModel;
using FirstMVCApp.Repositories;
using FirstMVCApp.RepoUnitOfWork;

namespace FirstMVCApp.Controllers
{
    public class MembershipTypesController : DefaultController<MembershipTypeModel, MembershipTypesRepository>
    {

        public MembershipTypesController(UnitOfWork unitOfWork) : base(unitOfWork.MembershipTypesRepository)  { }

    }
}
