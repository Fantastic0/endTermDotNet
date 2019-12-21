using LastProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LastProject.Services.AcctS
{
    public interface IAcctRepository
    {
        void Add(Acct acct);

        Task Save();

        void Delete(int id);

        Task<List<Acct>> GetAll();

        Task<List<Acct>> GetAccts(Expression<Func<Acct, bool>> predicate);

        void Edit(Acct acct);

        Task<Acct> GetAcctById(int id);

        bool AcctExistAndId(int id);

    }
}
