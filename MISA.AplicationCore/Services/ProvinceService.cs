using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Services
{
    public class ProvinceService : BaseService<Province>, IProvinceService
    {
        IProvinceRespository _provinceRespository;
        public ProvinceService(IProvinceRespository provinceRespository) : base(provinceRespository)
        {
            _provinceRespository = provinceRespository;
        }

        public IEnumerable<Province> GetProvincesByCountryId(string countryId)
        {
            return _provinceRespository.GetProvincesByCountryId(countryId);

        }
    }
}
