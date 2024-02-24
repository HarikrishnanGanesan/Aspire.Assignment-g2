using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Migrations;

namespace Assignment.Core.Data.Repositories
{
    public class CarsRepository : Repository<CarDetails>, ICarsRepository
    {
        public CarsRepository(DatabaseContext context) : base(context)
        {
        }
    }
}