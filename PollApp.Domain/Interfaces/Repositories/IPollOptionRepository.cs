using PollApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PollApp.Domain.Interfaces.Repositories
{
    public interface IPollOptionRepository
    {
        PollOption GetById(int id);

        PollOption Vote(PollOption option);
    }
}
