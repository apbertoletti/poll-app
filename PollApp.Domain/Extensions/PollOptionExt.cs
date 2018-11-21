using PollApp.Domain.Entities;
    
namespace PollApp.Domain.Extensions
{
    public static class PollOptionExt
    {
        public static PollOption DoVote(this PollOption option)
        {
            if (option.Votes == null)
                option.Votes = 1;
            else
                option.Votes++;

            return option;
        }
    }
}
