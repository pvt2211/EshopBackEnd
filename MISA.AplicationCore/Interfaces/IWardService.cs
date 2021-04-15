using MISA.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Interfaces
{
    public interface IWardService : IBaseService<Ward>
    {
        /// <summary>
        /// Lấy thông tin phường/xã theo id Quận/ huyện
        /// </summary>
        /// <param name="provinceId">id Quận/ huyện tương ứng<param>
        /// <returns>Các bản ghi theo id Quận/ huyện</returns>
        /// Created by pvtung (15/04/2021)
        IEnumerable<Ward> GetWardsByDistrictId(string districtId);
    }
}
