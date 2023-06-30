using Empleados.Context;
using Empleados.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Services
{
    public class EmpleadoServices
    {
        public void Add(Empleado request)
        {
			try
            {   //Habre la cadena de conexion y todo lo que se encuentre en using entrará a la DB
                using (var _context = new ApplicationDbContext())
                {
                    Empleado empleado = new Empleado()
                    {
                        Name = request.Name,
                        LastName = request.LastName,
                        Email = request.Email,
                        RegisterDate = DateTime.Now,
                    };
                    _context.Empleados.Add(empleado);
                    _context.SaveChanges();
                }
			}
			catch (Exception ex)
			{
				throw new Exception("Sucedió un error" + ex.Message);
			}
        }
    }
}
