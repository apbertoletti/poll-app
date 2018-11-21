using PollApp.Domain.Entities;
using System.Collections.Generic;

namespace PollApp.Domain.Interfaces.Repositories
{
    public interface IPollRepository
    {
        IEnumerable<Poll> Get();

        Poll GetById(int id);

        Poll Add(Poll poll);

        void Remove(int id);

        void RegisterView(int id);
    }
}
