using Empleados.Entities;
using Empleados.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Empleados23AM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        EmpleadoServices services = new EmpleadoServices();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = new Empleado()
            {
                Name = txtNombre.Text,
                LastName = txtApellido.Text,
                Email = txtCorreo.Text,
                RegisterDate = DateTime.Now
            };
            if (!string.IsNullOrEmpty(txtNombre.Text) || !string.IsNullOrEmpty(txtApellido.Text) || !string.IsNullOrEmpty(txtApellido.Text))
            {
                services.Add(empleado);
                txtNombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                MessageBox.Show("Los datos han sido agregados correctamente");
            }
            else
                MessageBox.Show("Los datos no sido agregados correctamente");
        }
        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {
            int Id = int.Parse(txtId.Text);
            Empleado empleado = services.Read(Id);
            if (empleado != null)
            {
                txtNombre.Text = empleado.Name;
                txtApellido.Text = empleado.LastName;
                txtCorreo.Text = empleado.Email;
                txtFecha.Text = empleado.RegisterDate.ToString();
                txtId.Text = empleado.PKEmpleado.ToString();
            }
            else
            {
                MessageBox.Show("Empleado no encontrado");
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtCorreo.Text = string.Empty;
                txtFecha.Text = string.Empty;
            }
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            int Id = int.Parse(txtId.Text);
            Empleado empleado = services.Delete(Id);
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            txtFecha.Text = "";
            txtId.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   //Boton de editar
            int Id = int.Parse(txtId.Text);

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCorreo.Text))
                MessageBox.Show("Faltan campos por rellenar");
            else
            {
                Empleado empleado = new Empleado();
                empleado.PKEmpleado = Id;
                empleado.Name = txtNombre.Text;
                empleado.LastName = txtApellido.Text;
                empleado.Email = txtCorreo.Text;
                empleado.RegisterDate = DateTime.Now;
                services.Update(empleado);

                txtNombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                txtFecha.Clear();
            }
        }
    }
}