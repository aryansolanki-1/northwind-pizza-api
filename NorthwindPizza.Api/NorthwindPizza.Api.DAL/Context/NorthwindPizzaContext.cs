using Microsoft.EntityFrameworkCore;

namespace NorthwindPizza.Api.DAL.Context;

public class NorthwindPizzaContext(DbContextOptions<NorthwindPizzaContext> options) : DbContext(options)
{
}
