using PollApp.Domain.Entities;

namespace PollApp.Domain.Interfaces.Repositories
{
    public interface IPollOptionRepository
    {
        PollOption GetById(int id);

        PollOption Vote(PollOption option);
    }
}
