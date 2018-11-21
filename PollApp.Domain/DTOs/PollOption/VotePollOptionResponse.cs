using System;
using PollApp.Domain.Entities;

namespace PollApp.Domain.DTOs.PollOption
{
    public class VotePollOptionResponse
    {
        #region Properties

        public int? Option_Id { get; set; }

        public string Option_Description { get; set; }

        public int Option_Votes { get; set; }

        #endregion

        #region Methods

        public static explicit operator VotePollOptionResponse(Entities.PollOption entity)
        {
            if (entity == null)
                return null;

            return new VotePollOptionResponse()
            {
                Option_Id = entity.ID,
                Option_Description = entity.Description,
                Option_Votes = entity.Votes
            };
        }

        #endregion
    }
}
