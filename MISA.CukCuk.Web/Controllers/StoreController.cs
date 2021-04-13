﻿using Microsoft.AspNetCore.Mvc;
using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Controllers
{
    public class StoreController : BaseEntityController<Store>
    {
        IBaseService<Store> _baseService;
        public StoreController(IBaseService<Store> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
