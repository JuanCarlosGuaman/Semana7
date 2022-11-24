using Semana7.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana7.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datosRegistro = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, contrasena = txtContrasena.Text };

                con.InsertAsync(datosRegistro);
                DisplayAlert("Mensaje", "Ingreso correcto", "Cerrar");

                txtNombre.Text = "";
                txtUsuario.Text = "";
                txtContrasena.Text = "";

            }
            catch (Exception ex)
            {

                DisplayAlert("Mensaje", ex.Message, "cerrar");
            }

        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}