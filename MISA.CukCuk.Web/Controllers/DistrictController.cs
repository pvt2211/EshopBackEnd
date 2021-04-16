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
    public class DistrictController : BaseEntityController<District>
    {
        IDistrictService _districtService;
        public DistrictController(IDistrictService districtService) : base(districtService)
        {
            _districtService = districtService;
        }
        /// <summary>
        /// Lấy danh sách quận huyện theo id tỉnh/thành phố
        /// </summary>
        /// <param name="provinceId">id tỉnh thành phố</param>
        /// <returns>Danh sách quận huyện tương ứng</returns>
        /// Created by pvtung (15/04/2021)
        [HttpGet("a")]
        public IActionResult GetDistrictsByProvinceId(string provinceId)
        {
            var entities = _districtService.GetDistrictsByProvinceId(provinceId);
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
