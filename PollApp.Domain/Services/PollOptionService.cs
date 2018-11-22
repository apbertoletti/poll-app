using PollApp.Domain.DTOs.PollOption;
using PollApp.Domain.Entities;
using PollApp.Domain.Interfaces.Repositories;
using PollApp.Domain.Interfaces.Services;

namespace PollApp.Domain.Services
{
    public class PollOptionService : IPollOptionService
    {
        private IPollOptionRepository _pollOptionRepository;

        public PollOptionService(IPollOptionRepository pollOptionRepository)
        {
            _pollOptionRepository = pollOptionRepository;
        }

        public GetPollOptionResponse GetById(int id)
        {
            return (GetPollOptionResponse)_pollOptionRepository.GetById(id);
        }

        public VotePollOptionResponse Vote(VotePollOptionRequest option)
        {
            return (VotePollOptionResponse)_pollOptionRepository.Vote((int)option.Option_Id);
        }
    }
}
