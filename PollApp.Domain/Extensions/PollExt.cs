using PollApp.Domain.Entities;

namespace PollApp.Domain.Extensions
{
    public static class PollExt
    {
        /// <summary>
        /// Registra uma visualização a mais na enquete em questão
        /// </summary>
        /// <param name="poll">Enquete a receber ser visualizada</param>
        public static void DoView(this Poll poll)
        {
            poll.Views++;
        }
    }
}
