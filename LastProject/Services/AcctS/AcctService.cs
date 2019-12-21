using LastProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastProject.Services.AcctS
{
    public class AcctService
    {
        private readonly IAcctRepository _acctRepository;
        
        public AcctService(IAcctRepository acctRepository)
        {
            _acctRepository = acctRepository;
        }

        public async Task<List<Acct>> GetAccts() => await _acctRepository.GetAll();

        public async Task AddAndSafe(Acct acct)
        {
            _acctRepository.Add(acct);
            await _acctRepository.Save();
        }

        public async Task Edit(Acct acct)
        {
            _acctRepository.Edit(acct);
            await _acctRepository.Save();
        }

        public async Task<List<Acct>> Edit(int id)
        {
            var searchedAccts = await _acctRepository.GetAccts(Acct => Acct.AcctId == id);
            return searchedAccts;
        }

        public async Task Delete(int id)
        {
            _acctRepository.Delete(id);
            await _acctRepository.Save();
        }

        public async Task<Acct> GetAcctById(int id)
        {
            return await _acctRepository.GetAcctById(id);
        }

        public bool IsAcctExist(int id)
        {
            return _acctRepository.AcctExistAndId(id);
        }
    }
}
