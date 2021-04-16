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
        /// <summary>
        /// Lấy danh sách phường xã theo id quận huyện
        /// </summary>
        /// <param name="districtId">id quận huyện</param>
        /// <returns>danh sách phường xã tương ứng</returns>
        /// Created by pvtung (15/04/2021)
        [HttpGet("a")]
        public IActionResult GetWardsByDistrictId(string districtId)
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
