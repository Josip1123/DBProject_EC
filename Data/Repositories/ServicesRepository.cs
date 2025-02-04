using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ServicesRepository(DataContext context) : BaseRepository<ServicesEntity>(context)
{
}