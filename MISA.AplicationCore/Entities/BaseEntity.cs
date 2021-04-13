using MISA.AplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Entities
{
    /// <summary>
    /// Class bắt buộc nhập cho các property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Required:Attribute
    {

    }
    /// <summary>
    /// Class check trùng lặp cho các property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {

    }
    /// <summary>
    /// Thông tin chung các đối tượng
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Trạng thái chính sửa
        /// </summary>
        public EntityState EntityState { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string ModifiedBy { get; set; }
    }

}
