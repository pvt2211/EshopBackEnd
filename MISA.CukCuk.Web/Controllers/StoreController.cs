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
    [Route("api/v1/stores")]
    [ApiController]
    public class StoreController : BaseEntityController<Store>
    {
        IStoreService _storeService;
        public StoreController(IStoreService storeService) : base(storeService)
        {
            _storeService = storeService;
        }
        /// <summary>
        /// Lấy thông tin cửa hàng theo Mã cửa hàng
        /// </summary>
        /// <param name="StoreCode">Mã cửa hàng muốn lấy thông tin</param>
        /// <returns>
        /// -HttpCode: 200 nếu lấy được dữ liệu
        /// </returns>
        [HttpGet("code")]
        public IActionResult GetStoreByCode(string StoreCode)
        {
            var entity = _storeService.GetStoreByStoreCode(StoreCode);
            if (entity == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(entity);
            }
        }
    }
}
