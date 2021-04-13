using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Entities
{
    /// <summary>
    /// Thông tin quốc gia
    /// </summary>
    public class Country:BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CountryId { get; set; }
        /// <summary>
        /// Tên quốc gia
        /// </summary>
        public string CountryName { get; set; }
    }
}
