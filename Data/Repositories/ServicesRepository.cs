using Data.Contexts;
using Data.Entities;

namespace Data.Repositories;

public class ServicesRepository(DataContext context) : BaseRepository<ServicesEntity>(context)
{
}