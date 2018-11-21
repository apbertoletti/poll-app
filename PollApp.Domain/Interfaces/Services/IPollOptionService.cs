using PollApp.Domain.DTOs.PollOption;

namespace PollApp.Domain.Interfaces.Services
{
    public interface IPollOptionService
    {
        GetPollOptionResponse GetById(int id);

        VotePollOptionResponse Vote(VotePollOptionRequest option);
    }
}
