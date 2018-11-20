using PollApp.Domain.DTOs.Poll;
using PollApp.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PollApp.Domain.Entities
{
    public class Poll : BaseEntity
    {
        #region Construtor

        protected Poll() : base(-1)
        {

        }

        public Poll(int id, string description, List<PollOption> pollOptions) : base(id)
        {
            Description = description;
            Options = pollOptions;
        }

        #endregion

        #region Properties

        public string Description { get; private set; }

        public List<PollOption> Options { get; private set; }

        #endregion

        #region Methods
        
        #endregion
    }
}
