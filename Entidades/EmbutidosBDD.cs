using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuarios;
using ProductosNs;

namespace Entidades
{
    public static class EmbutidosBDD
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;
        //static SqlDataReader dataReader;

        static EmbutidosBDD()
        {
            connectionString = @"Data Source = DESKTOP-KSE67HS;
                                Database = UTN_D2;
                                Trusted_Connection = True;";

            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.Connection = connection;
            command.CommandType = CommandType.Text;
        }

        //public static List<Embutido> Leer()
        //{
        //    List<Embutido> embutidos = new List<Embutido>();

        //    try
        //    {
        //        connection.Open();
        //        command.CommandText = "SELECT ID, DESCRIPCION, KG_EN_STOCK, PRECIO_POR_KG FROM EMBUTIDOS";

        //        SqlDataReader dataReader;

        //        using (dataReader = command.ExecuteReader())
        //        {
        //            while (dataReader.Read())
        //            {
        //                embutidos.Add(new Embutido(Convert.ToInt32(dataReader["id"]),
        //                                         (float)dataReader.GetDouble(dataReader.GetOrdinal("PRECIO_POR_KG")),
        //                                         Convert.ToInt32(dataReader["KG_EN_STOCK"]),
        //                                         dataReader["DESCRIPCION"].ToString()));
        //            }
        //        }

        //        return embutidos;

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally { connection.Close(); }
        //}
    }
}
