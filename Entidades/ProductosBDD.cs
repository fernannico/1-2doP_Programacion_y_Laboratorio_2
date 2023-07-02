using ProductosNs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ProductosBDD
    {

        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;
        //static SqlDataReader dataReader;

        static ProductosBDD()
        {
            connectionString = @"Data Source = DESKTOP-KSE67HS;
                                Database = UTN_D2;
                                Trusted_Connection = True;";

            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.Connection = connection;
            command.CommandType = CommandType.Text;
        }

        public static List<Productos> Leer()
        {
            List<Productos> productos = new List<Productos>();

            try
            {
                connection.Open();
                command.CommandText = "SELECT ID, DESCRIPCION, CORTE, KG_EN_STOCK, PRECIO_POR_KG FROM PRODUCTOS WHERE TIPO_PROD = 'Carne'";

                SqlDataReader dataReader /*= command.ExecuteReader()*/;

                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        //if (typeof() == typeof(Carne) && dataReader["Tipo"].ToString() == "Carne")
                        //{
                        productos.Add(/*(T)(object)*/new Carne(Convert.ToInt32(dataReader["id"]),
                                             (float)dataReader.GetDouble(dataReader.GetOrdinal("PRECIO_POR_KG")),
                                             Convert.ToInt32(dataReader["KG_EN_STOCK"]),
                                             dataReader["DESCRIPCION"].ToString(),
                                             dataReader["CORTE"].ToString()));
                    }
                }
                command.CommandText = "SELECT ID, DESCRIPCION, KG_EN_STOCK, PRECIO_POR_KG FROM PRODUCTOS WHERE TIPO_PROD = 'Embutido'";

                //}else if (typeof(T) == typeof(Embutido) && dataReader["Tipo"].ToString() == "Embutido")
                //{
                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        productos.Add(/*(T)(object)*/new Embutido(Convert.ToInt32(dataReader["ID"]),
                                                                 (float)dataReader.GetDouble(dataReader.GetOrdinal("PRECIO_POR_KG")),
                                                                 Convert.ToInt32(dataReader["KG_EN_STOCK"]),
                                                                 dataReader["DESCRIPCION"].ToString()));
                        //}

                    }
                }

                return productos;

            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
        }
    }
}
