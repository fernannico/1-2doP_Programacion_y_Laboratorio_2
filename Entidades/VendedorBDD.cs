using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuarios;

namespace Entidades
{
    public static class VendedorBDD
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;
        //static SqlDataReader dataReader;

        static VendedorBDD()
        {
            connectionString = @"Data Source = DESKTOP-KSE67HS;
                                Database = USUARIOS;
                                Trusted_Connection = True;";

            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.Connection = connection;
            command.CommandType = CommandType.Text;
        }

        public static List<Vendedor> Leer()
        {
            List<Vendedor> vendedores = new List<Vendedor>();

            try
            {
                connection.Open();
                command.CommandText = "SELECT ID, MAIL, CONSTRASENA FROM VENDEDORES";

                SqlDataReader dataReader = command.ExecuteReader();

                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        vendedores.Add(new Vendedor(Convert.ToInt32(dataReader["id"]), 
                                                    dataReader["mail"].ToString(), 
                                                    dataReader["contrasena"].ToString()));
                    }
                }

                return vendedores;

            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
        }
    }
}
