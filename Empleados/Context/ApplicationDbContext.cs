using Empleados.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Context
{
    public class ApplicationDbContext : DbContext //Hereda una libreria de EntityFramework
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Cadena de conexion
            optionsBuilder.UseMySQL("server=localhost; database=Empleado23am; user=root; password=");
        }
        //Mapeo de la BD
        DbSet<Empleado> Empleados { get; set; }

    }
}
