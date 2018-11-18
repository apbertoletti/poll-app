
using PollApp.Domain.DTOs.PollOption;
using PollApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PollApp.Domain.DTOs.Poll
{
    public class GetPollResponse
    {
        public int Poll_Id { get; set; }

        public string Poll_Description { get; set; }

        public IEnumerable<PollOptionResponse> Options { get; set; }

        public static explicit operator GetPollResponse(Entities.Poll poll)
        {
            return new GetPollResponse()
            {
                Poll_Id = poll.ID,
                Poll_Description = poll.Description,
                Options = poll.Options.ToList().Select(entity => (PollOptionResponse)entity)
            };
        }
    }
}
