using Data.Contexts;
using Data.Entities;


namespace Data.Repositories;

public class CustomersRepository(DataContext context) : BaseRepository<CustomersEntity>(context)
{
}