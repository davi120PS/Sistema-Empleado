using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Entities
{
    public class Empleado
    {
        [Key]
        public int PKEmpleado { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Email { get; set; }
    }
}
