using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Entities
{
    /// <summary>
    /// Thông tin Tỉnh/Thành phố
    /// </summary>
    public class Ward : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid WardId { get; set; }
        /// <summary>
        /// Tên Phường/Xã
        /// </summary>
        public string WardName { get; set; }
        /// <summary>
        /// Khóa phụ Quận/Huyện
        /// </summary>
        public Guid? DistrictId { get; set; }
    }
}
