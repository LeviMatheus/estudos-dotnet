using Microsoft.EntityFrameworkCore;

namespace Comercio.API.Database
{
    public class eCommerceContext : DbContext
    {
        /* 
         Conexão sem distinção de ambientes de execução
         */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Indicando qual banco vai ser utilizado (SqlServer)
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eCommerce;Integrated Security=True");
        }
    }
}
