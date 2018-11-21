using PollApp.Domain.Entities;

namespace PollApp.Domain.Extensions
{
    public static class PollExt
    {
        public static void DoView(this Poll poll)
        {
            poll.Views++;
        }
    }
}
