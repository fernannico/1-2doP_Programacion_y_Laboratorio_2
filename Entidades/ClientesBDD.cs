using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuarios;
using System.Reflection.PortableExecutable;

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
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
        }

        //public static void Modificar(Cliente cliente)
        //{
        //    try
        //    {
        //        command.Parameters.Clear();
        //        connection.Open();
        //        command.CommandText = $"UPDATE Clientes SET DINERO = @DINERO WHERE Clientes.IDCLIENTE = {cliente.ID}";
        //        command.Parameters.AddWithValue("@DINERO", cliente.GastoMaximoPropiedad);
        //        command.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}
    }
}
