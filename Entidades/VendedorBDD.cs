using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
                                Database = UTN_D2;
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
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is SqlException || ex is InvalidOperationException || ex is SqlNullValueException || ex is DbException)
                {
                    innerExceptions.Add(ex);
                }
                throw new ExcepcionesPropias("Error al leer la base de datos de vendores", innerExceptions);
            }
            finally { connection.Close(); }
        }
    }
}
