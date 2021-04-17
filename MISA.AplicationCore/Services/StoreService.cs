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

        public IEnumerable<Store> GetStoreFilters(string storeCode, string storeName, string address, string phoneNumber, int status)
        {
            return _storeRepository.GetStoreFilters(storeCode, storeName, address, phoneNumber, status);
        }
    }
}
