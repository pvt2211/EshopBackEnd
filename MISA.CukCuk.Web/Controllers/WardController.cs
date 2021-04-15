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
    public class WardController : BaseEntityController<Ward>
    {
        IWardService _wardService;
        public WardController(IWardService wardService) : base(wardService)
        {
            _wardService = wardService;
        }

        [HttpGet("a")]
        public IActionResult GetDistrictsByProvinceId(string districtId)
        {
            var entities = _wardService.GetWardsByDistrictId(districtId);
            if (entities.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entities);
            }
        }
    }
}
