using MISA.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Interfaces
{
    public interface IDistrictService : IBaseService<District>
    {
        /// <summary>
        /// Lấy thông tin quận/huyện theo id tỉnh/ thành phố
        /// </summary>
        /// <param name="provinceId">id tỉnh/thành phố tương<param>
        /// <returns>Các bản ghi theo id tỉnh/thành phố</returns>
        /// Created by pvtung (15/04/2021)
        IEnumerable<District> GetDistrictsByProvinceId(string provinceId);
    }
}
