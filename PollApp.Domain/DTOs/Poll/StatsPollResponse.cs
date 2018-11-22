using PollApp.Domain.DTOs.PollOption;
using System.Collections.Generic;
using System.Linq;

namespace PollApp.Domain.DTOs.Poll
{
    public class StatsPollResponse 
    {
        #region Properties

        public int Views { get; set; }

        public IEnumerable<StatsPollOptionResponse> Votes { get; set; }

        #endregion

        #region Methods

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

        #endregion
    }
}
