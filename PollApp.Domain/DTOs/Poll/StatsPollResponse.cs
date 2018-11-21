using PollApp.Domain.DTOs.PollOption;
using PollApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PollApp.Domain.DTOs.Poll
{
    public class StatsPollResponse 
    {
        public int Views { get; set; }

        public IEnumerable<StatsPollOptionResponse> Votes { get; set; }

        public static explicit operator StatsPollResponse(Entities.Poll entity)
        {
            if (entity == null)
                return null;

            return new StatsPollResponse()
            {
                Views = entity.Views,
                Votes = (entity.Options == null ? null : entity.Options.ToList().Select(e => (StatsPollOptionResponse)e))
            };
        }
    }
}
