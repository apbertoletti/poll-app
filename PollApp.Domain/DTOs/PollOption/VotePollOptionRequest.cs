namespace PollApp.Domain.DTOs.PollOption
{
    public class VotePollOptionRequest
    {
        #region Fields

        public int? Option_Id { get; set; }

        #endregion

        #region Methods

        public static explicit operator VotePollOptionRequest(GetPollOptionResponse entity)
        {
            if (entity == null)
                return null;

            return new VotePollOptionRequest()
            {
                Option_Id = entity.Option_Id
            };
        }

        #endregion
    }
}
