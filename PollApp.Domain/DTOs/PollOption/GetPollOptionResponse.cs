namespace PollApp.Domain.DTOs.PollOption
{
    public class GetPollOptionResponse
    {
        #region Properties

        public int? Option_Id { get; set; }

        public string Option_Description { get; set; }

        #endregion    

        #region Methods

        public static explicit operator GetPollOptionResponse(Entities.PollOption pollOption)
        {
            if (pollOption == null)
                return null;

            return new GetPollOptionResponse()
            {
                Option_Id = pollOption.ID,
                Option_Description = pollOption.Description
            };
        }

        #endregion
    }
}
