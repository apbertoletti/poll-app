using PollApp.Domain.DTOs.Poll;
using PollApp.Domain.Entities;
using System.Collections.Generic;

namespace PollApp.Domain.Interfaces.Services
{
    public interface IPollService
    {
        IEnumerable<GetPollResponse> Get();

        GetPollResponse GetById(int id);

        AddPollResponse Add(AddPollRequest poll);

        void Remove(int id);

        void RegisterView(int id);

        StatsPollResponse GetStatsById(int id);
    }
}
