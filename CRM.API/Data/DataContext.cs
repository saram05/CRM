using Microsoft.EntityFrameworkCore;
using CRM.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CRM.API.Data
{
    public class DataContext : IdentityDbContext<Users> /*Obligatoriamente se hereda para poder usar entity framework*/
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    

    }
}
