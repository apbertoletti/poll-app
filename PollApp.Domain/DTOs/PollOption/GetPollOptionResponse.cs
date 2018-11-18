using System;
using PollApp.Domain.Entities;

namespace PollApp.Domain.DTOs.PollOption
{
    public class PollOptionResponse
    {
        public int Option_Id { get; set; }

        public string Option_Description { get; set; }

        public static explicit operator PollOptionResponse(Entities.PollOption pollOption)
        {
            return new PollOptionResponse()
            {
                Option_Id = pollOption.ID,
                Option_Description = pollOption.Description
            };
        }
    }
}
