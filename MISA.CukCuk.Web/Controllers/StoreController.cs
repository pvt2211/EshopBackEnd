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
        /// -httpcode 204 nếu không có dữ liệu
        /// -httpcode 400 có lỗi phía client
        /// -httpcode 500 có lỗi phía serve
        /// </returns>
        ///  Created by pvtung (15/04/2021)
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
        /// <summary>
        /// Lấy thông tin cửa hàng theo cac param filter
        /// </summary>
        /// <param name="StoreCode">Mã cửa hàng muốn lấy thông tin</param>
        /// <param name="storeName">Ten cua hang muốn lấy thông tin</param>
        /// <param name="address">Dia chi muốn lấy thông tin</param>
        /// <param name="phoneNumber">Sod ein thoai muốn lấy thông tin</param>
        /// <param name="status">Trang thai muốn lấy thông tin</param>
        /// <returns>
        /// -HttpCode: 200 nếu lấy được dữ liệu
        /// -httpcode 204 nếu không có dữ liệu
        /// -httpcode 400 có lỗi phía client
        /// -httpcode 500 có lỗi phía serve
        /// </returns>
        ///  Created by pvtung (16/04/2021)
        [HttpGet("filter")]
        public IActionResult GetStoreByCode(string storeCode, string storeName, string address, string phoneNumber, int status)
        {
            var entities = _storeService.GetStoreFilters(storeCode, storeName, address, phoneNumber, status);
            if (entities == null)
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
