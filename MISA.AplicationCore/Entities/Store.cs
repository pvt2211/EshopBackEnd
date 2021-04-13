using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Entities
{
    /// <summary>
    /// Thông tin cửa hàng
    /// Created by pvtung 12/04/2021
    /// </summary>
    public class Store : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid StoreId { get; set; }
        /// <summary>
        /// Mã cửa hàng
        /// </summary>
        [CheckDuplicate]
        [Required]
        public string StoreCode { get; set; }
        /// <summary>
        /// Tên cửa hàng
        /// </summary>
        [Required]
        public string StoreName { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        [Required]
        public string Address { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string StoreTaxCode { get; set; }
        /// <summary>
        /// Khóa phụ quốc gia
        /// </summary>
        public Guid? CountryId { get; set; }
        /// <summary>
        /// Khóa phụ Tỉnh/ thành phố
        /// </summary>
        public Guid? ProvinceId { get; set; }
        /// <summary>
        /// Khóa phụ Quận/huyện
        /// </summary>
        public Guid? DistrictId { get; set; }
        /// <summary>
        /// Khóa phụ phường/xã
        /// </summary>
        public Guid? WardId { get; set; }
        /// <summary>
        /// Phố
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Tình trạng hoạt động
        /// </summary>
        public int? Status { get; set; }
    }
}
