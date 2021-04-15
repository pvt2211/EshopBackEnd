using Dapper;
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
    public class WardRespository : BaseRepository<Ward>, IWardRespository
    {
        public WardRespository(IConfiguration configuration) : base(configuration)
        {

        }
        public IEnumerable<Ward> GetWardsByDistrictId(string districtId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("Id", districtId);
            var wards = _dbConnection.Query<Ward>($"Proc_GetWardWithDistrict", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return wards;
        }
    }
}
