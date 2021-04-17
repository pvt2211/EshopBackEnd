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
        /// <summary>
        /// Ham lay thong tin cua hang theo filter cac param
        /// </summary>
        /// <param name="storeCode">ma cua hang</param>
        /// <param name="storeName">ten cua hang</param>
        /// <param name="address">dia chi</param>
        /// <param name="phoneNumber">so dien thoai</param>
        /// <param name="status">trang thai cua hang</param>
        /// <returns>Danh sach cua hang theo filter</returns>
        /// Created by pvtung(16/04/2021)
        IEnumerable<Store> GetStoreFilters(string storeCode, string storeName, string address, string phoneNumber, int status);
    }
}
