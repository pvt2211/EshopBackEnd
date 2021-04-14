using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Services
{
    public class StoreService : BaseService<Store>, IStoreService
    {
        IStoreRepository _storeRepository;
        public StoreService (IStoreRepository storeRepository): base(storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public Store GetStoreByStoreCode(string storeCode)
        {
            return _storeRepository.GetStoreByStoreCode(storeCode);
        }
    }
}
