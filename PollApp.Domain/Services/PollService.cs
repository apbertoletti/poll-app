using System.Collections.Generic;
using System.Linq;
using PollApp.Domain.DTOs.Poll;
using PollApp.Domain.Entities;
using PollApp.Domain.Interfaces.Repositories;
using PollApp.Domain.Interfaces.Services;

namespace PollApp.Domain.Services
{
    public class PollService : IPollService
    {
        IPollRepository _pollRepository;

        public PollService(IPollRepository pollRepository)
        {
            _pollRepository = pollRepository; 
        }

        public AddPollResponse Add(AddPollRequest poll)
        {
            var newPoll = new Poll(-1, poll.Poll_Description, new List<PollOption>());

            var newOptions = new List<PollOption>();
            for (int i = 1; i <= poll.Options.Length; i++)
                newOptions.Add(new PollOption(i * (-1), newPoll, poll.Options[i - 1]));

            newPoll.Options.AddRange(newOptions);

            _pollRepository.Add(newPoll);

            return new AddPollResponse() { Poll_Id = newPoll.ID };
        }

        public IEnumerable<GetPollResponse> Get()
        {
            return _pollRepository.Get().ToList().Select(entidade => (GetPollResponse)entidade);
        }

        public GetPollResponse GetById(int id)
        {
            return (GetPollResponse)_pollRepository.GetById(id);
        }

        public StatsPollResponse GetStatsById(int id)
        {
            return (StatsPollResponse)_pollRepository.GetById(id);
        }

        public void RegisterView(int id)
        {
            _pollRepository.RegisterView(id);
        }

        public void Remove(int id)
        {
            _pollRepository.Remove(id);
        }
    }
}
