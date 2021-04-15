using Microsoft.AspNetCore.Mvc;
using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Enums;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseEntityController<MISAEntity> : ControllerBase
    {
        #region DECLARE
        IBaseService<MISAEntity> _baseService;
        ServiceResult serviceResult;
        #endregion
        #region CONSTRUCTURE
        public BaseEntityController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
            serviceResult = new ServiceResult();
        }
        #endregion
        #region METHOD
        /// <summary>
        /// Lấy tất cả đối tượng
        /// </summary>
        /// <returns>Danh sách tất cả đôi tượng</returns>
        /// Created by pvtung (06/04/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetAllEntities();  
            if (entities.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entities);
            }
        }

        /// <summary>
        /// Lấy danh sách đối tượng theo vị trí bắt đầu và số lượng
        /// </summary>
        /// <param name="positionStart">Vị trí bắt đầu lấy </param>
        /// <param name="offSet">Số lượng lấy</param>
        /// <returns>Danh sách bản ghi đối tượng tương ứng</returns>
        /// Created by pvtung (12/04/2021)
        [HttpGet("page")]
        public IActionResult GetEntityByIndexOffset(int positionStart, int offSet)
        {
            var entities = _baseService.GetEntityByIndexOffset(positionStart, offSet);
            if (entities.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entities);
            }
        }

        /// <summary>
        /// Lấy thông tin đối tượng theo id
        /// </summary>
        /// <param name="id">id tương ứng </param>
        /// <returns>Bản ghi tương ứng theo id</returns>
        /// Created by pvtung(06/04/2021)
        [HttpGet("{id}")]
        public IActionResult GetEntityById(string id)
        {
            var entity = _baseService.GetEntityById(id);
            if (entity == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(entity);
            }
        }
        /// <summary>
        /// Xóa bản ghi đối tượng theo id
        /// </summary>
        /// <param name="id">id của đối tượng muốn xóa</param>
        /// <returns>Kết quả xóa</returns>
        /// Created by pvtung(06/04/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            serviceResult = _baseService.Delete(id);
            if (serviceResult.MISACode == 200)
            {
                return Ok(serviceResult);
            }
            else
            {
                return BadRequest(serviceResult);
            }
        }
        /// <summary>
        /// Tạo một bản ghi đối tượng trong db
        /// </summary>
        /// <param name="entity">Thông tin đối tượng muốn tạo</param>
        /// <returns>Kết quả tạo thành công hoặc ko</returns>
        [HttpPost]
        public IActionResult Insert(MISAEntity entity)
        {
            serviceResult = _baseService.Insert(entity);
            if (serviceResult.MISACode == 200)
            {
                return Ok(serviceResult);
            }
            else
            {
                return BadRequest(serviceResult);
            }   
        }
        /// <summary>
        /// Sửa một bản ghi của đối tượng theo id
        /// </summary>
        /// <param name="entity">Thông tin muốn sửa</param>
        /// <param name="id">id của đối tượng tương ứng</param>
        /// <returns>Kết quả sửa</returns>
        [HttpPut("{id}")]
        public IActionResult Update([FromBody]MISAEntity entity,[FromRoute]string id)
        {
            var keyProperty = entity.GetType().GetProperty($"{typeof(MISAEntity).Name}Id");
            //primaryProperty.SetValue(entity, entityId);
            //Type type = entity.GetType(); 

            //PropertyInfo prop = type.GetProperty($"{typeof(MISAEntity).Name}Id");
            var entityExist = _baseService.GetEntityById(id);
            if (entityExist == null)
            {
                serviceResult.MISACode = (int)MISACode.IsNotValid;
                serviceResult.Messenger = "Không tồn tại Id";
                return BadRequest(serviceResult);
            }
            else
            {
                if (keyProperty.PropertyType == typeof(Guid))
                {
                    keyProperty.SetValue(entity, Guid.Parse(id));
                }
                else if (keyProperty.PropertyType == typeof(int))
                {
                    keyProperty.SetValue(entity, int.Parse(id));

                }
                else
                {
                    keyProperty.SetValue(entity, id);
                }
            }
            serviceResult = _baseService.Update(entity);
            if (serviceResult.MISACode == 200)
            {
                return Ok(serviceResult);
            }
            else
            {
                return BadRequest(serviceResult);
            }
        }
        [HttpGet("valid")]

        public bool CheckValid([FromBody]MISAEntity entity)
        {
            var isValid = _baseService.CheckValid(entity);
            return !isValid;
        }
    }
    #endregion
}
