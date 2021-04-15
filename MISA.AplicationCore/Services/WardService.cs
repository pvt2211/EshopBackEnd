using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Services
{
    public class WardService : BaseService<Ward>, IWardService
    {
        IWardRespository _wardRespository;
        public WardService(IWardRespository wardRespository) : base(wardRespository)
        {
            _wardRespository = wardRespository;
        }

        public IEnumerable<Ward> GetWardsByDistrictId(string districtId)
        {
            return _wardRespository.GetWardsByDistrictId(districtId);
        }
    }
}
