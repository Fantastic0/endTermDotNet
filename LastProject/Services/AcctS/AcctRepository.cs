using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LastProject.Data;
using LastProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LastProject.Services.AcctS
{
    public class AcctRepository : IAcctRepository
    {
        readonly DataContext _context;

        public AcctRepository(DataContext context)
        {
            _context = context;
        }

        public bool AcctExistAndId(int id)
        {
            return _context.Acct.Any(m => m.AcctId == id);
        }

        public void Add(Acct acct)
        {
            _context.Add(acct);
        }

        public void Delete(int id)
        {
            var Acct = _context.Acct.Find(id);
            _context.Remove(Acct);
        }

        public void Edit(Acct acct)
        {
            _context.Update(acct);
        }

        public Task<Acct> GetAcctById(int id)
        {
            return _context.Acct.FirstOrDefaultAsync(m => m.AcctId == id);
        }

        public Task<List<Acct>> GetAll()
        {
            return _context.Acct.ToListAsync();
        }

        public Task<List<Acct>> GetAccts(Expression<Func<Acct, bool>> predicate)
        {
            return _context.Acct.Where(predicate).ToListAsync();
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
