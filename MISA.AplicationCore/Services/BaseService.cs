using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using MISA.AplicationCore.Enums;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Linq;

namespace MISA.AplicationCore.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity: BaseEntity
    {
        #region DECLARE
        protected ServiceResult serviceResult;
        protected IBaseRepository<MISAEntity> _baseRepository;
        #endregion
        #region CONSTRUCTURE
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            serviceResult = new ServiceResult();
            serviceResult.MISACode = (int)MISACode.Success;
            serviceResult.Messenger = "Thành công";
        }
        #endregion
        #region METHOD
        public IEnumerable<MISAEntity> GetAllEntities()
        {
            var entities = _baseRepository.GetAllEntities();
            return entities;
        }

        public MISAEntity GetEntityById(string entityId)
        {
            var entity = _baseRepository.GetEntityById(entityId);
            return entity;
        }

        public ServiceResult Delete(string entityId)
        {
            var rowAffects = _baseRepository.Delete(entityId);
            if (rowAffects >= 1)
            {
                serviceResult.Data = rowAffects;
                serviceResult.MISACode = (int)MISACode.Success;
                return serviceResult;
            }
            else
            {
                serviceResult.Data = "Không tồn tại Id";
                serviceResult.MISACode = (int)MISACode.IsNotValid;
                serviceResult.Messenger = "Dữ liệu không hợp lệ";
                return serviceResult;
            }
        }
            
        public ServiceResult Insert(MISAEntity entity)
        {
            entity.EntityState = EntityState.Add;
            var isValid = Validate(entity);
            if (isValid == true)    
            {
                serviceResult.Data = _baseRepository.Insert(entity);
                serviceResult.MISACode = (int)Enums.MISACode.Success;
                return serviceResult;
            }
            else
            {
                serviceResult.MISACode = (int)MISACode.IsNotValid;
                serviceResult.Data = "Thêm thất bại";
                serviceResult.Messenger = "Dữ liệu không hợp lệ";
                return serviceResult;
            }
        }

        public ServiceResult Update(MISAEntity entity)
        {
            entity.EntityState = EntityState.Update;
            var isValid = Validate(entity);
            if (isValid == true)
            {
                serviceResult.Data = _baseRepository.Update(entity);
                serviceResult.MISACode = (int)Enums.MISACode.Success;
                return serviceResult;
            }
            else
            {
                return serviceResult;
            }
        }
        /// <summary>
        /// Hàm validate dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng cần validate</param>
        /// <returns>True khi validate thành công và False khi không thành công</returns>
        private bool Validate(MISAEntity entity)
        {
            var messageError = new List<string>();
            var isValid = true;
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                //var displayName = property.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                //Check bắt buộc nhập
                if (property.IsDefined(typeof(Required),false))
                {
                    if (propertyValue == null)
                    {
                        messageError.Add($"Thông tin {property.Name} không được để trống");
                        serviceResult.Messenger = "Dữ liệu không hợp lệ";
                        serviceResult.MISACode = (int)MISACode.IsNotValid;
                        isValid = false;
                    }
                }
                //Check trùng dữ liệu
                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    var entityDuplicate = _baseRepository.GetEntityByProperty(entity, property);
                    if (entityDuplicate != null)
                    {
                        isValid = false;
                        messageError.Add($"Thông tin {property.Name} đã có trên hệ thống");
                        serviceResult.Messenger = "Dữ liệu không hợp lệ";
                        serviceResult.MISACode = (int)MISACode.IsNotValid;
                    }
                }
            }
            serviceResult.Data = messageError;
            return isValid;
        }

        public MISAEntity GetEntityByProperty(MISAEntity entity, PropertyInfo property)
        {
            var entityReturn = _baseRepository.GetEntityByProperty(entity,property);
            return entityReturn;
        }

        public IEnumerable<MISAEntity> GetEntityByIndexOffset(int positionStart, int offSet)
        {
            var entities = _baseRepository.GetEntityByIndexOffset(positionStart, positionStart);
            return entities;
        }
        #endregion
    }
}
