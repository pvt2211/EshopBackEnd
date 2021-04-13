using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Enums
{
    /// <summary>
    /// Mã trả về
    /// </summary>
    public enum MISACode
    { 
        /// <summary>
        /// Hợp lệ
        /// </summary>
        IsValid = 100,
        /// <summary>
        /// Không hợp lệ
        /// </summary>
        IsNotValid = 999,

        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,
    }

    /// <summary>
    /// Trạng thái edit entity
    /// </summary>
    public enum EntityState
    {
        /// <summary>
        /// Trạng thái thêm 
        /// </summary>
        Add = 1,
        /// <summary>
        /// Trạng thái chỉnh sửa
        /// </summary>
        Update = 2,
        /// <summary>
        /// Trạng thái xóa
        /// </summary>
        Delete = 0,
    }
}
