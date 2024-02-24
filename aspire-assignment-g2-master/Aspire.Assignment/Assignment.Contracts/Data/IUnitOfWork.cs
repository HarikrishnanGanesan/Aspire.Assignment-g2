using Assignment.Contracts.Data.Repositories;

namespace Assignment.Contracts.Data
{
    public interface IUnitOfWork
    {
        IAppRepository App { get; }
        IUserRepository User { get; }
        ICarsRepository Cars {get;}
        IProfileRepository UserProfiles {get;}
        IBookingRepository Booking { get; }
        Task CommitAsync();
    }
}