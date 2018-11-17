using PollApp.Domain.Entities.Base;

namespace PollApp.Domain.Entities
{
    public class PollOption : BaseEntity
    {
        #region Constructors

        public PollOption(int id, Poll poll, string description) : base(id)
        {
            Poll = poll;
            Description = description;
        }

        #endregion

        #region Properties

        public Poll Poll { get; private set; }

        public string Description { get; private set; }

        public int? Votes { get; private set; }

        #endregion
    }
}
