namespace PollApp.Domain.DTOs.PollOption
{
    public class StatsPollOptionResponse
    {
        #region Properties

        public int? Option_Id { get; set; }

        public int Qty { get; set; }

        #endregion

        #region Methods

        public static explicit operator StatsPollOptionResponse(Entities.PollOption entity)
        {
            if (entity == null)
                return null;

            return new StatsPollOptionResponse()
            {
                Option_Id = entity.ID,
                Qty = entity.Votes
            };
        }

        #endregion
    }
}
