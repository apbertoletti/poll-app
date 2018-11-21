using PollApp.Domain.Entities;
using PollApp.Domain.Extensions;
using PollApp.Domain.Interfaces.Repositories;
using PollApp.Infra.Persistence.EF;
using System.Linq;

namespace PollApp.Infra.Persistence.Repositories
{
    public class PollOptionRepository : IPollOptionRepository
    {
        private readonly PollAppContext _context;

        public PollOptionRepository(PollAppContext context)
        {
            _context = context;
        }

        public PollOption GetById(int id)
        {
            return _context.PollOptions.FirstOrDefault(c => c.ID == id);
        }

        public PollOption Vote(PollOption option)
        {
            var optionVote = _context.PollOptions.FirstOrDefault(c => c.ID == option.ID);

            optionVote.Vote();

            _context.SaveChanges();

            return optionVote;
        }
    }
}
