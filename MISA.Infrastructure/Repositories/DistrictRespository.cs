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
    public class DistrictRespository : BaseRepository<District>, IDistrictRespository
    {
        public DistrictRespository(IConfiguration configuration) : base(configuration)
        {

        }

        public IEnumerable<District> GetDistrictsByProvinceId(string provinceId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("Id", provinceId);
            var district = _dbConnection.Query<District>($"Proc_GetDistrictWithProvince", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return district;
        }

    }
}
