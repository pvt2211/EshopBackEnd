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
        IBaseService<MISAEntity> _baseService;
        ServiceResult serviceResult;
        public BaseEntityController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
            serviceResult = new ServiceResult();
        }
        // GET: api/<BaseEntityController>
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

        //// GET: api/<BaseEntityController>
        //[HttpGet("{positionStart, offSet}")]
        //public IActionResult GetEntityByIndexOffset(int positionStart,int offSet)
        //{
        //    var entities = _baseService.GetAllEntities();
        //    if (entities.Count() == 0)
        //    {
        //        return NoContent();
        //    }
        //    else
        //    {
        //        return Ok(entities);
        //    }
        //}

        // GET api/<BaseEntityController>/5
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
    }
}
