using Data.Contexts;
using Data.Entities;

namespace Data.Repositories;

public class ProjectBaseRepository(DataContext context) : BaseRepository<CustomersEntity>(context)
{
    
}