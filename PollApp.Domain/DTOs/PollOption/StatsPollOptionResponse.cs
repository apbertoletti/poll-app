using System;
using System.Collections.Generic;
using PollApp.Domain.Entities;

namespace PollApp.Domain.DTOs.PollOption
{
    public class StatsPollOptionResponse
    {
        public int? Option_Id { get; set; }

        public int? Qty { get; set; }

        public static explicit operator StatsPollOptionResponse(Entities.PollOption entity)
        {
            if (entity == null)
                return null;

            return new StatsPollOptionResponse()
            {
                Option_Id = entity.ID,
                Qty = (entity.Votes == null ? 0 : entity.Votes)
            };
        }
    }
}
