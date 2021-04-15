using MISA.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Interfaces
{
    public interface IProvinceService : IBaseService<Province>
    {
        /// <summary>
        /// Lấy thông tin tỉnh thành theo id quốc gia
        /// </summary>
        /// <param name="countryId">id quốc gia tương<param>
        /// <returns>Các bản ghi theo id quốc gia</returns>
        /// Created by pvtung (14/04/2021)
        IEnumerable<Province> GetProvincesByCountryId(string countryId);
    }
}
