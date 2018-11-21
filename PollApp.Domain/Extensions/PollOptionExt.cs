using PollApp.Domain.Entities;
    
namespace PollApp.Domain.Extensions
{
    public static class PollOptionExt
    {
        public static PollOption DoVote(this PollOption option)
        {
            option.Votes++;

            return option;
        }
    }
}
