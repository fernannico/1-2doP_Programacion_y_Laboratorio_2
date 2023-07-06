using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuarios;
using System.Reflection.PortableExecutable;
using System.Data.Common;
using System.Data.SqlTypes;

namespace Entidades
{
    public class ClientesBDD
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;
        //static SqlDataReader dataReader;

        static ClientesBDD()
        {
            connectionString = @"Data Source = DESKTOP-KSE67HS;
                                Database = UTN_D2;
                                Trusted_Connection = True;";

            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.Connection = connection;
            command.CommandType = CommandType.Text;
        }

        public static List<Cliente> Leer()
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                connection.Open();
                command.CommandText = "SELECT ID, MAIL, CONTRASENA, DINERO FROM CLIENTES";

                SqlDataReader dataReader = command.ExecuteReader();

                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        clientes.Add(new Cliente(Convert.ToInt32(dataReader["id"]),
                                                 dataReader["mail"].ToString(),
                                                 dataReader["contrasena"].ToString(),
                                                 dataReader.GetDecimal(dataReader.GetOrdinal("dinero"))));
                    }
                }

                return clientes;

            }
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is SqlException || ex is InvalidOperationException || ex is SqlNullValueException || ex is DbException)
                {
                    innerExceptions.Add(ex);
                }
                throw new ExcepcionesPropias("Error al leer la base de datos de clientes", innerExceptions);
            }
            finally { connection.Close(); }
        }

    }
}
