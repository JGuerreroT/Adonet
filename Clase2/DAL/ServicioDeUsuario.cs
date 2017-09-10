using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.DAL
{
    public class ServicioDeUsuario
    {
        public void CrearUnNuevoUsuario(NuevoUsuario Usuario) {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("CrearUsuario", conection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Nombre", Usuario.Nombre));
            comando.Parameters.Add(new SqlParameter("@clave", Usuario.Clave ));
            comando.Parameters.Add(new SqlParameter("@habilitado", Usuario.habilitado ));
            conection.Open();
            comando.ExecuteNonQuery();
            conection.Close();
        }

        public List<UsuarioGenerico> ListarTodosLosUsuarios() {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("ListarTodosLosUsuarios", conection);
            comando.CommandType = CommandType.StoredProcedure;
            conection.Open();
            SqlDataReader lectorDeDatos = comando.ExecuteReader();
            List<UsuarioGenerico> Usuarios = new List<UsuarioGenerico>();
            while (lectorDeDatos.Read())
            {
                UsuarioGenerico Usuario = new UsuarioGenerico();
                Usuario.Id = (int)lectorDeDatos.GetInt32(0);
                Usuario.Nombre = lectorDeDatos.GetString(1);
                Usuario.Clave  = lectorDeDatos.GetString(2);
                Usuario.habilitado  = lectorDeDatos.GetBoolean(3);
                Usuarios.Add(Usuario);
            }
            conection.Close();
            return Usuarios;
        }

        private SqlConnection iniciarConexion() {
            SqlConnection conection = new SqlConnection();
            conection.ConnectionString = ConfigurationManager.ConnectionStrings["Tienda"].ConnectionString;
            return conection;
        }

        public void BorrarUsuario(int userId)
        {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("BorrarUsuario", conection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@id", userId));
            conection.Open();
            comando.ExecuteNonQuery();
            conection.Close();
        }

    }
}
