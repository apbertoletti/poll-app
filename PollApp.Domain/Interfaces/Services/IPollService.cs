using PollApp.Domain.DTOs.Poll;
using PollApp.Domain.Entities;
using System.Collections.Generic;

namespace PollApp.Domain.Interfaces.Services
{
    public interface IPollService
    {
        IEnumerable<GetPollResponse> Get();

        GetPollResponse GetById(int id);

        Poll Add(Poll poll);

        void Remove(int id);
    }
}
