using PollApp.Domain.Entities;
using System.Collections.Generic;

namespace PollApp.Domain.Interfaces.Services
{
    public interface IPollService
    {
        IEnumerable<Poll> Get();

        Poll GetById(int id);

        Poll Add(Poll poll);

        void Remove(int id);
    }
}
