﻿using ProductosNs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.Common;

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

        public static List<T> Leer<T>() where T : Productos 
        {
            List<T> productos = new List<T>();

            try
            {
                connection.Open();
                command.CommandText = "SELECT ID, DESCRIPCION, CORTE, KG_EN_STOCK, PRECIO_POR_KG FROM PRODUCTOS WHERE TIPO_PROD = 'Carne' ORDER BY ID ASC";

                SqlDataReader dataReader;

                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        productos.Add((T)(Productos)new Carne(Convert.ToInt32(dataReader["id"]),
                                             (float)dataReader.GetDouble(dataReader.GetOrdinal("PRECIO_POR_KG")),
                                             Convert.ToInt32(dataReader["KG_EN_STOCK"]),
                                             dataReader["DESCRIPCION"].ToString(),
                                             dataReader["CORTE"].ToString()));
                    }
                }
                command.CommandText = "SELECT ID, DESCRIPCION, KG_EN_STOCK, PRECIO_POR_KG FROM PRODUCTOS WHERE TIPO_PROD = 'Embutido' ORDER BY ID ASC";

                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        productos.Add((T)(Productos)new Embutido(Convert.ToInt32(dataReader["ID"]),
                                                                 (float)dataReader.GetDouble(dataReader.GetOrdinal("PRECIO_POR_KG")),
                                                                 Convert.ToInt32(dataReader["KG_EN_STOCK"]),
                                                                 dataReader["DESCRIPCION"].ToString()));
                    }
                }

                return productos;

            }
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is SqlException || ex is InvalidOperationException || ex is SqlNullValueException || ex is DbException)
                {
                    innerExceptions.Add(ex);
                }
                throw new ExcepcionesPropias("Error al leer la base de datos de productos", innerExceptions);
            }
            finally { connection.Close(); }
        }


        public static void ModificarProducto(Productos producto)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE PRODUCTOS SET KG_EN_STOCK = @KG_EN_STOCK, PRECIO_POR_KG = @PRECIO_POR_KG WHERE PRODUCTOS.ID = @ID";
                command.Parameters.AddWithValue("@KG_EN_STOCK", producto.KgEnStock);
                command.Parameters.AddWithValue("@PRECIO_POR_KG", producto.Precio);
                command.Parameters.AddWithValue("@ID", producto.Id); 
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is SqlException || ex is InvalidOperationException || ex is SqlNullValueException || ex is DbException)
                {
                    innerExceptions.Add(ex);
                }
                throw new ExcepcionesPropias("Error al modificar el producto", innerExceptions);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void Eliminar(int Id)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"DELETE FROM Productos WHERE Productos.ID = @Id";
                command.Parameters.AddWithValue("@Id", Id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is SqlException || ex is InvalidOperationException || ex is SqlNullValueException || ex is DbException)
                {
                    innerExceptions.Add(ex);
                }
                throw new ExcepcionesPropias("Error al eliminar el producto", innerExceptions);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void CrearProducto(Productos producto)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"INSERT INTO PRODUCTOS (DESCRIPCION, CORTE, KG_EN_STOCK, PRECIO_POR_KG, TIPO_PROD) VALUES(@DESCRIPCION, @CORTE, @KG_EN_STOCK, @PRECIO_POR_KG, @TIPO_PROD)";
                command.Parameters.AddWithValue("@KG_EN_STOCK", producto.KgEnStock);
                command.Parameters.AddWithValue("@PRECIO_POR_KG", producto.Precio);

                if(producto is Carne)
                {
                    command.Parameters.AddWithValue("@DESCRIPCION", ((Carne)producto).Animal);
                    command.Parameters.AddWithValue("@CORTE", ((Carne)producto).Corte);
                    command.Parameters.AddWithValue("@TIPO_PROD", "Carne");
                }else if(producto is Embutido)
                {
                    command.Parameters.AddWithValue("@DESCRIPCION", ((Embutido)producto).TipoEmbutido);
                    command.Parameters.AddWithValue("@CORTE", DBNull.Value);
                    command.Parameters.AddWithValue("@TIPO_PROD", "Embutido");
                }

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is SqlException || ex is InvalidOperationException || ex is SqlNullValueException || ex is DbException)
                {
                    innerExceptions.Add(ex);
                }
                throw new ExcepcionesPropias("Error al crear el producto", innerExceptions);
            }
            finally { connection.Close(); }
        }

    }
}
