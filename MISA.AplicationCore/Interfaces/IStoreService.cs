using MISA.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Interfaces
{
    public interface IStoreService : IBaseService<Store>
    {
        /// <summary>
        /// Lấy thông tin cửa hàng theo mã cửa hàng
        /// </summary>
        /// <param name="storeCode">Mã cửa hàng</param>
        /// <returns>bản ghi thông tin cửa hàng theo mã cửa hàng tương ứng</returns>
        /// Created by pvtung (14/04/2021)
        Store GetStoreByStoreCode(string storeCode);
    }
}
