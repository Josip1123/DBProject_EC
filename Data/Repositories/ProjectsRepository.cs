using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ProjectsRepository(DataContext context) : BaseRepository<CustomersEntity>(context)
{
}