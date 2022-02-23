namespace Core.Entities.Concrete
{
    public class UserOperationClaim:IEntity
    {
        public int OperationClaimId { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationUserId { get; set; }

    }

}
