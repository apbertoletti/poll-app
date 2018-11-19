using PollApp.Domain.DTOs.PollOption;
using System.Collections.Generic;
using System.Linq;

namespace PollApp.Domain.DTOs.Poll
{
    public class AddPollRequest
    {
        public string Poll_Description { get; set; }

        public string[] Options { get; set; }
    }
}
