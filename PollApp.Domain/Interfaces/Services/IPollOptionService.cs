using PollApp.Domain.DTOs.PollOption;
using System;
using System.Collections.Generic;
using System.Text;

namespace PollApp.Domain.Interfaces.Services
{
    public interface IPollOptionService
    {
        GetPollOptionResponse GetById(int id);

        VotePollOptionResponse Vote(VotePollOptionRequest option);
    }
}
