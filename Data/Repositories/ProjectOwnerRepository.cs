using Data.Contexts;
using Data.Entities;

namespace Data.Repositories;

public class ProjectOwnerRepository(DataContext context) : BaseRepository<ProjectOwnerEntity>(context)
{
    
}