using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Entities
{
    /// <summary>
    /// Thông tin Quận/Huyện
    /// </summary>
    public class District : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid DistrictId { get; set; }
        /// <summary>
        /// Tên Quận/Huyện
        /// </summary>
        public string DistrictName { get; set; }
        /// <summary>
        /// Khóa phụ Tỉnh/Thành phố
        /// </summary>
        public Guid? ProvinceId { get; set; }
    }
}
