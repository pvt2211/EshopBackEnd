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
    public class ProvinceController : BaseEntityController<Province>
    {
        IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService) : base(provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpGet("a")]
        public IActionResult GetProvincesByCountryId(string CountryId)
        {
            var entities = _provinceService.GetProvincesByCountryId(CountryId);
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
