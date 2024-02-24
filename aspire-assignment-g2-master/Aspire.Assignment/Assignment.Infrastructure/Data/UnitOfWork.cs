using Assignment.Contracts.Data;
using Assignment.Contracts.Data.Repositories;
using Assignment.Core.Data.Repositories;
using Assignment.Migrations;

namespace Assignment.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IAppRepository App => new AppRepository(_context);

        public IUserRepository User => new UserRepository(_context);
        public ICarsRepository Cars => new CarsRepository(_context);
        public IProfileRepository UserProfiles => new ProfileRepository(_context);
        public IBookingRepository Booking => new BookingRepository(_context);
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}