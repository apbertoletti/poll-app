using Microsoft.EntityFrameworkCore;
using PollApp.Domain.Entities;
using PollApp.Domain.Extensions;
using PollApp.Domain.Interfaces.Repositories;
using PollApp.Infra.Persistence.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PollApp.Infra.Persistence.Repositories
{
    public class PollRepository : IPollRepository
    {
        private readonly PollAppContext _context;

        public PollRepository(PollAppContext context)
        {
            _context = context;
        }

        public Poll Add(Poll poll)
        {
            SetNullPKs(poll);

            var x = _context.Polls.Add(poll);           
            _context.SaveChanges();

            return x.Entity;
        }

        private void SetNullPKs(Poll poll)
        {
            /** Estas alterações nos IDs foram necessárias para que o seu conteúdo
              * não sobrescrevesse o ID autogerado pelo BD **/
            poll.SetNewId(null);
            poll.Options.ForEach(c => c.SetNewId(null));
        }        

        public IEnumerable<Poll> Get()
        {
            return _context.Polls.Include(c => c.Options);
        }

        public Poll GetById(int id)
        {
            return _context.Polls.Include(c => c.Options).FirstOrDefault(c => c .ID == id);
        }

        public void Remove(int id)
        {
            _context.Polls.Remove(GetById(id));
            _context.SaveChanges();
        }

        public void RegisterView(int id)
        {
            _context.Polls.FirstOrDefault(c => c.ID == id).DoView();
            _context.SaveChanges();
        }
    }
}
