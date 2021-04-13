using Microsoft.Extensions.Configuration;
using MISA.AplicationCore.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using System.Text;
using System.Reflection;
using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Enums;

namespace MISA.Infrastructure.Repositories
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity> where MISAEntity:BaseEntity
                
    {
        #region DECLARE
        IConfiguration _configuration;
        protected string _connectionString = string.Empty;
        protected string _tableName = string.Empty;
        protected IDbConnection _dbConnection;
        #endregion

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _tableName = typeof(MISAEntity).Name;
            _connectionString = _configuration.GetConnectionString("MISAConnectDataBase");
            _dbConnection = new MySqlConnection(_connectionString);
        }

        public IEnumerable<MISAEntity> GetAllEntities()
        {
            var entities = _dbConnection.Query<MISAEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            return entities;
        }

        public MISAEntity GetEntityById(string entityId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeGetByIdInputParamName = $"@{_tableName}Id";
            dynamicParameters.Add(storeGetByIdInputParamName, entityId);
            var entity = _dbConnection.Query<MISAEntity>($"Proc_Get{_tableName}ById",param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }
        public int Delete(string entityId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeGetByIdInputParamName = $"@{_tableName}Id";
            dynamicParameters.Add(storeGetByIdInputParamName, entityId);
            var rowAffects = _dbConnection.Execute($"Proc_Delete{_tableName}", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }
            
        public int Insert(MISAEntity entity)
        {
            var parameters = MappingDbType(entity);
            var rowAffects = _dbConnection.Execute($"Proc_Insert{_tableName}",param: parameters, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        public int Update(MISAEntity entity)
        {
            var parameters = MappingDbType(entity);
            var rowAffects = _dbConnection.Execute($"Proc_Update{_tableName}", param: parameters, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }
        public MISAEntity GetEntityByProperty(MISAEntity entity, PropertyInfo property)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);
            var query = string.Empty;
            if (entity.EntityState == EntityState.Add)
            {
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}'";
            }
            else if (entity.EntityState == EntityState.Update)
            {
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}' AND {_tableName}Id <> '{keyValue}'";

            }
            else
            {
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}'";
            }
            var entityReturn = _dbConnection.Query<MISAEntity>(query, commandType: CommandType.Text).FirstOrDefault();
            return entityReturn;
        }
        /// <summary>
        /// Chuyển đổi kiểu dữ liệu phù hợp với database
        /// </summary>
        /// <param name="entity">đối tượng cần chuyển đổi kiểu dữ liệu</param>
        /// <returns>đối tượng với các property đã được chuyển kiểu dữ liệu</returns>
        /// Created by pvtung (08/04/2021)
        private DynamicParameters MappingDbType(MISAEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
                {
                    var dbValue = (bool)propertyValue == true ? 1 : 0;
                    parameters.Add($"@{propertyName}", dbValue, DbType.Int32);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);

                }
            }
            return parameters;
        }

        public IEnumerable<MISAEntity> GetEntityByIndexOffset(int positionStart, int offSet)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("positionStart", offSet);
            dynamicParameters.Add("offSet", positionStart);
            var entities = _dbConnection.Query<MISAEntity>($"Proc_Get{_tableName}ByIndexOffset", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return entities;
        }
    }
}
