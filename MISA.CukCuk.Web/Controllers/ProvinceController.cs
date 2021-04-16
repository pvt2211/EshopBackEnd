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
        /// <summary>
        /// Lấy danh sách tỉnh/ thành theo id quốc gia
        /// </summary>
        /// <param name="countryId">id quốc gia</param>
        /// <returns>Danh sách tỉnh thành tương ứng</returns>
        /// Created by pvtung (15/04/2021)
        [HttpGet("a")]
        public IActionResult GetProvincesByCountryId(string countryId)
        {
            var entities = _provinceService.GetProvincesByCountryId(countryId);
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
