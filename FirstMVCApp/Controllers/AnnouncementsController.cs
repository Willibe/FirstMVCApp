using Microsoft.AspNetCore.Mvc;
using FirstMVCApp.ControllerModel;
using FirstMVCApp.Models;
using FirstMVCApp.Repositories;

namespace FirstMVCApp.Controllers
{
    public class AnnouncementsController : DefaultController<AnnouncementModel>
    {


        public AnnouncementsController(IClubDataRepository<AnnouncementModel> repository): base(repository) { }

        

    }
}
