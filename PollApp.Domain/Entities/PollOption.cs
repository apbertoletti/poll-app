using System;
using PollApp.Domain.DTOs.PollOption;
using PollApp.Domain.Entities.Base;

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

        public static explicit operator PollOption(GetPollOptionResponse entity)
        {
            if (entity == null)
                return null;

            return new PollOption(entity.Option_Id, null, entity.Option_Description)
            {
                Votes = entity.Option_Votes
            };
        }

        public static explicit operator PollOption(VotePollOptionRequest v)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
