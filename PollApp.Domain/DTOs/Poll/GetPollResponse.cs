
using PollApp.Domain.DTOs.PollOption;
using System.Collections.Generic;
using System.Linq;

namespace PollApp.Domain.DTOs.Poll
{
    public class GetPollResponse
    {
        #region Properties

        public int? Poll_Id { get; set; }

        public string Poll_Description { get; set; }

        public IEnumerable<GetPollOptionResponse> Options { get; set; }

        #endregion

        #region Methods

        public static explicit operator GetPollResponse(Entities.Poll poll)
        {
            if (poll == null)
                return null;

            return new GetPollResponse()
            {
                Poll_Id = poll.ID,
                Poll_Description = poll.Description,
                Options = (poll.Options.ToList().Select(entity => (GetPollOptionResponse)entity))
            };
        }

        #endregion
    }
}
