namespace _2.BirdsDomain.Interfaces
{
    public interface IUnitOfWork
    {      
        ISecurityRepository SecurityRepository { get; }

        Task SaveChangesAsync();
    }
}
