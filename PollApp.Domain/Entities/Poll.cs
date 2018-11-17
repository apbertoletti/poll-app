using PollApp.Domain.Entities.Base;
using System.Collections.Generic;

namespace PollApp.Domain.Entities
{
    public class Poll : BaseEntity
    {
        #region Construtor

        public Poll(int id, string description, List<PollOption> pollOptions) : base(id)
        {
            Description = description;
            Options = pollOptions;
        }

        #endregion

        #region Properties

        public string Description { get; private set; }

        public List<PollOption> Options { get; private set; }

        #endregion
    }
}
