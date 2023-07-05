using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuarios;
using System.Data.Common;

namespace Entidades
{
    public static class UsuariosBDD
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;
        static SqlDataReader dataReader;

        static UsuariosBDD()
        {
            connectionString = @"Data Source = DESKTOP-KSE67HS;
                                Database = UTN_D2;
                                Trusted_Connection = True;";

            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.Connection = connection;
            command.CommandType = CommandType.Text;
        }

        public static List<T> Leer<T>() where T : Usuario
        {
            List<T> usuarios = new List<T>();

            try
            {
                connection.Open();
                command.CommandText = "SELECT ID, MAIL, CONTRASENA FROM USUARIOS WHERE TIPO_USUARIO = 'Vendedor'";

                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        usuarios.Add((T)(Usuario)new Vendedor(Convert.ToInt32(dataReader["id"]),
                                                    dataReader["mail"].ToString(),
                                                    dataReader["contrasena"].ToString()));
                    }
                }

                command.CommandText = "SELECT ID, MAIL, DINERO, CONTRASENA FROM USUARIOS WHERE TIPO_USUARIO = 'Cliente'";
                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        usuarios.Add((T)(Usuario)new Cliente(Convert.ToInt32(dataReader["id"]),
                                                    dataReader["mail"].ToString(),
                                                    dataReader["contrasena"].ToString(),
                                                    dataReader.GetDecimal(dataReader.GetOrdinal("dinero"))));
                    }
                }

                return usuarios;

            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
        }

        public static string TraerTipoUsuario(string mail, string contrasena)
        {
            string tipoUsuario = null;

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT TIPO_USUARIO FROM USUARIOS WHERE MAIL = @mail AND CONTRASENA = @contrasena";
                command.Parameters.AddWithValue("@mail", mail);
                command.Parameters.AddWithValue("@contrasena", contrasena);

                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        tipoUsuario = dataReader["TIPO_USUARIO"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;

            }finally { connection.Close(); }

            return tipoUsuario;
        }
    }
}
