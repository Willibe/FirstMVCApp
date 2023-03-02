﻿using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using FirstMVCApp.ControllerModel;

namespace FirstMVCApp.Controllers
{
    public class MembershipTypesController : DefaultController<MembershipTypeModel>
    {

        public MembershipTypesController(IClubDataRepository<MembershipTypeModel> repository) : base(repository)  { }



    }
}
