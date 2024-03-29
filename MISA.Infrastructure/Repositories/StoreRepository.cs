﻿using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure.Repositories
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        public StoreRepository (IConfiguration configuration): base(configuration)
        {

        }
        public Store GetStoreByStoreCode(string storeCode)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeGetByIdInputParamName = $"@{_tableName}Code";
            dynamicParameters.Add(storeGetByIdInputParamName, storeCode);
            var store = _dbConnection.Query<Store>($"Proc_Get{_tableName}By{_tableName}Code", param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return store;
        }

        public IEnumerable<Store> GetStoreFilters(string storeCode, string storeName, string address, string phoneNumber, int status)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("StoreCode", storeCode);
            dynamicParameters.Add("StoreName", storeName);
            dynamicParameters.Add("Address", address);
            dynamicParameters.Add("PhoneNumber", phoneNumber);
            dynamicParameters.Add("Status", status);
            var stores = _dbConnection.Query<Store>($"Proc_GetStoreFilter", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return stores;
        }
    }
}
