using MISA.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.AplicationCore.Interfaces
{
    public interface IBaseService<MISAEntity>
    {
        #region Method
        /// <summary>
        /// Lấy danh sách đối tượng trong db
        /// </summary>
        /// <returns>Danh sách các đối tượng</returns>
        /// Created by pvtung (06/04/2021)
        IEnumerable<MISAEntity> GetAllEntities();
        /// <summary>
        /// Lấy đối tượng tương ứng theo Id
        /// </summary>
        /// <param name="entityId">Id của đối tượng trong db</param>
        /// <returns>Bản ghi của đối tượng có Id tương ứng</returns>
        /// Created by pvtung (06/04/2021)
         MISAEntity GetEntityById(string entityId);
        /// <summary>
        /// Thêm bản ghi của đối tượng vào db
        /// </summary>
        /// <param name="entity">Bản ghi của đối tượng</param>
        /// <returns>Số bản ghi được thêm</returns>
        /// Created by pvtung (06/04/2021)
        ServiceResult Insert(MISAEntity entity);
        /// <summary>
        /// Sửa đổi thông tin bản ghi của đối tượng theo Id
        /// </summary>
        /// <param name="entityId">id của đối tượng tương ứng</param>
        /// <returns>Số bản ghi thay đổi</returns>
        ServiceResult Update(MISAEntity entityId);
        /// <summary>
        /// Xóa bản ghi của đối tượng theo id
        /// </summary>
        /// <param name="entityId">id của đối tượng tương ứng</param>
        /// <returns>Số bản ghi bị xóa</returns>
        ServiceResult Delete(string entityId);
        /// <summary>
        /// Lấy thông tin đối tượng theo property cụ thể
        /// </summary>
        /// <param name="entity">Đối tượng muốn lấy thông tin</param>
        /// <param name="property">Property muốn lấy theo</param>
        /// <returns>Bản ghi đốii tượng tương ứng theo property</returns>
        /// Created by pvtung (12/04/2021)
        MISAEntity GetEntityByProperty(MISAEntity entity, PropertyInfo property);
        /// <summary>
        /// Lấy danh sách đối tượng theo vị trí bắt đầu và số lượng
        /// </summary>
        /// <param name="positionStart">Vị trí bắt đầu lấy </param>
        /// <param name="offSet">Số lượng lấy</param>
        /// <returns>Danh sách bản ghi đối tượng tương ứng</returns>
        /// Created by pvtung (12/04/2021)
        IEnumerable<MISAEntity> GetEntityByIndexOffset(int positionStart, int offSet);
        #endregion
    }
}
