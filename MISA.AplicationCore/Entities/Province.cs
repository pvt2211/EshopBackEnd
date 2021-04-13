using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Entities
{
    /// <summary>
    /// Thông tin Tỉnh/Thành phố
    /// </summary>
    public class Province : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid ProvinceId { get; set; }
        /// <summary>
        /// Tên Tỉnh/Thành phố
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// Khóa phụ quốc gia
        /// </summary>
        public Guid? CountryId { get; set; }
    }
}
