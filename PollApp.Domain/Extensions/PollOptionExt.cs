using PollApp.Domain.Entities;

namespace PollApp.Domain.Extensions
{
    public static class PollOptionExt
    {
        /// <summary>
        /// Registra um voto a mais na opção em questão
        /// </summary>
        /// <param name="poll">Opção a receber ser votada</param>
        public static PollOption DoVote(this PollOption option)
        {
            option.Votes++;

            return option;
        }
    }
}
