using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Entities
{
    /// <summary>
    /// Thông tin kết quả trả về
    /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// Data trả về
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Messenger
        /// </summary>
        public string Messenger { get; set; }
        /// <summary>
        /// Mã trả về
        /// </summary>
        public int MISACode { get; set; }
    }
}
