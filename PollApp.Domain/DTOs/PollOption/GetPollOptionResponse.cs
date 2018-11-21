namespace PollApp.Domain.DTOs.PollOption
{
    public class GetPollOptionResponse
    {
        #region Methods

        public int? Option_Id { get; set; }

        public string Option_Description { get; set; }

        public int Option_Votes { get; set; }

        #endregion    

        #region Methods

        public static explicit operator GetPollOptionResponse(Entities.PollOption pollOption)
        {
            if (pollOption == null)
                return null;

            return new GetPollOptionResponse()
            {
                Option_Id = pollOption.ID,
                Option_Description = pollOption.Description,
                Option_Votes = pollOption.Votes
            };
        }

        #endregion
    }
}
