using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.AplicationCore.Interfaces
{
    public interface IBaseRepository<MISAEntity>
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
        int Insert(MISAEntity entity);
        /// <summary>
        /// Sửa đổi thông tin bản ghi của đối tượng theo Id
        /// </summary>
        /// <param name="entityId">id của đối tượng tương ứng</param>
        /// <returns>Số bản ghi thay đổi</returns>
        int Update(MISAEntity entityId);
        /// <summary>
        /// Xóa bản ghi của đối tượng theo id
        /// </summary>
        /// <param name="entityId">id của đối tượng tương ứng</param>
        /// <returns>Số bản ghi bị xóa</returns>
        int Delete(string entityId);
        /// <summary>
        /// Lấy thông tin đối tượng theo property
        /// </summary>
        /// <param name="entity">đối tượng</param>
        /// <param name="property">property tương ứng</param>
        /// <returns>bản ghi đối tượng theo property tương ứng</returns>
        /// Created by pvtung (08/04/2021)
        MISAEntity GetEntityByProperty(MISAEntity entity,PropertyInfo property);
        IEnumerable<MISAEntity> GetEntityByIndexOffset(int positionStart, int offSet);
        #endregion
    }
}
