using Empleados.Context;
using Empleados.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                        RegisterDate = DateTime.Now
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
        public Empleado Read(int Id)
        {
            try
            {
                Empleado empleado = new Empleado();
                using (var _context = new ApplicationDbContext())
                {   // Buscar el empleado por su Id
                    empleado = _context.Empleados.Find(Id);
                    return empleado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        public Empleado Delete(int Id)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {   // Buscar el empleado por su Id
                    Empleado empleado = _context.Empleados.Find(Id);
                    if (empleado != null)
                    {   // Remover el empleado de la base de datos
                        _context.Empleados.Remove(empleado);
                        _context.SaveChanges();
                        MessageBox.Show("Empleado eliminado correctamente");
                    }
                    else
                        MessageBox.Show("Empleado ya eliminado");
                    return empleado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message +
                                    "\n\"Empleado no eliminado");
            }
        }
        public void Update(Empleado request)//recibe todos los datos del empleado
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado update = _context.Empleados.Find(request.PKEmpleado);
                    update.Name = request.Name;
                    update.LastName = request.LastName;
                    update.Email = request.Email;
                    update.RegisterDate = request.RegisterDate;

                    //_context.Entry(update).State = EntityState.Modified;
                    _context.Empleados.Update(update);
                    _context.SaveChanges();
                    MessageBox.Show("Empleado editado correctamente");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
    }
}