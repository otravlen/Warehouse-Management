using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using System.ComponentModel.DataAnnotations;

namespace Backend.DatabaseLayer
{
	public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {  }     
       
    }

}

