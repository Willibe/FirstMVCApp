using FirstMVCApp.Repositories;
using FirstMVCApp.ControllerModel;
using FirstMVCApp.Models;
using FirstMVCApp.RepoUnitOfWork;

namespace FirstMVCApp.Controllers
{
    public class AnnouncementsController : DefaultController<AnnouncementModel, AnnouncementsRepository>
    {

        public AnnouncementsController(UnitOfWork unitOfWork): base(unitOfWork.AnnouncementsRepository) { }

    }
}
