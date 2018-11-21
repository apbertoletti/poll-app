using PollApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
