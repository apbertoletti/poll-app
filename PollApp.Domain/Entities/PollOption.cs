using PollApp.Domain.DTOs.PollOption;
using PollApp.Domain.Entities.Base;
using System;

namespace PollApp.Domain.Entities
{
    public class PollOption : BaseEntity
    {
        #region Constructors

        protected PollOption() : base(-1)
        {

        }

        public PollOption(int? id, Poll poll, string description) : base(id)
        {
            Poll = poll;
            Description = description;
            Votes = 0;
        }

        #endregion

        #region Properties

        public Poll Poll { get; private set; }

        public string Description { get; private set; }

        public int Votes { get; internal set; }

        #endregion

        #region Methods
       

        #endregion
    }
}
