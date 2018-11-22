using PollApp.Domain.Entities;
using PollApp.Domain.Extensions;
using PollApp.Domain.Interfaces.Repositories;
using PollApp.Infra.Persistence.EF;
using System.Linq;

namespace PollApp.Infra.Persistence.Repositories
{
    public class PollOptionRepository : IPollOptionRepository
    {
        #region Fields

        private readonly PollAppContext _context;

        #endregion

        #region Constructors

        public PollOptionRepository(PollAppContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public PollOption GetById(int id)
        {
            return _context.PollOptions.FirstOrDefault(c => c.ID == id);
        }

        public PollOption Vote(PollOption option)
        {
            var optionVote = _context.PollOptions.FirstOrDefault(c => c.ID == option.ID);

            optionVote.DoVote();

            _context.SaveChanges();

            return optionVote;
        }

        #endregion
    }
}
