using Data.Contexts;
using Data.Entities;



namespace Data.Repositories;

public class ProjectsRepository(DataContext context) : BaseRepository<ProjectEntity>(context)
{
}