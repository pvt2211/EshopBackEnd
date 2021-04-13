using Microsoft.AspNetCore.Mvc;
using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Controllers
{
    public class CountryController : BaseEntityController<Country>
    {
        IBaseService<Country> _baseService;
        public CountryController(IBaseService<Country> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
