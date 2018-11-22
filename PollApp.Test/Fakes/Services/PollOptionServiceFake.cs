using PollApp.Domain.DTOs.PollOption;
using PollApp.Domain.Entities;
using PollApp.Domain.Interfaces.Repositories;
using PollApp.Domain.Interfaces.Services;

namespace PollApp.Test.Fakes.Services
{
    public class PollOptionServiceFake : IPollOptionService
    {
        #region Fields

        private IPollOptionRepository _pollOptionRepository;

        #endregion

        #region Constructors

        public PollOptionServiceFake(IPollOptionRepository pollOptionRepository)
        {
            _pollOptionRepository = pollOptionRepository;
        }

        #endregion

        #region Methods

        public GetPollOptionResponse GetById(int id)
        {
            return (GetPollOptionResponse)_pollOptionRepository.GetById(id);
        }

        public VotePollOptionResponse Vote(VotePollOptionRequest option)
        {
            var optionVote = GetById((int)option.Option_Id);

            if (optionVote == null)
                return null;

            return (VotePollOptionResponse)_pollOptionRepository.Vote((PollOption)optionVote);
        }
        
        #endregion
    }
}
