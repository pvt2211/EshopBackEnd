using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Services
{
    public class DistrictService : BaseService<District>, IDistrictService
    {
        IDistrictRespository _districtRespository;
        public DistrictService(IDistrictRespository districtRespository) : base(districtRespository)
        {
            _districtRespository = districtRespository;
        }

        public IEnumerable<District> GetDistrictsByProvinceId(string provinceId)
        {
            return _districtRespository.GetDistrictsByProvinceId(provinceId);
        }
    }
}
