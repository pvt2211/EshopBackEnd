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
    public class ProvinceRespository : BaseRepository<Province>, IProvinceRespository
    {
        public ProvinceRespository(IConfiguration configuration) : base(configuration)
        {

        }

        public IEnumerable<Province> GetProvincesByCountryId(string countryId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("Id", countryId);
            var provinces = _dbConnection.Query<Province>($"Proc_GetProvinceWithCountry", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return provinces;
        }
    }
}
