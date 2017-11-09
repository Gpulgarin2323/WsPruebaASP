using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WsPruebaASP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Crud" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Crud.svc o Crud.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Crud : ICrud
    {
        readonly SqlConnection oconectar = new SqlConnection("Data Source=DESKTOP-OQ7Q3GE\\PRUEBASSQL;Initial Catalog=PruebaASP;User ID=saPruebas;Password=1234");


        public DataSet GetConsultarLibros()
        {
            try
            {
                oconectar.Open(); //abrir la base de datos   
                SqlCommand ocmd = new SqlCommand("Consultar_Libro", oconectar);

                SqlDataAdapter da = new SqlDataAdapter(ocmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                oconectar.Close();
            }


        }

        public DataSet GetConsultarLibroids(int id)
        {
            try
            {
                oconectar.Open(); //abrir la base de datos   
                SqlCommand ocmd = new SqlCommand("Consultar_Librotodo", oconectar);
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.Parameters.Clear();
                ocmd.Parameters.AddWithValue("@id", id);
                ocmd.CommandText = "Consultar_Librotodo";

                SqlDataAdapter da = new SqlDataAdapter(ocmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                oconectar.Close();
            }


        }

        public bool GetInsertarLibro(string[] oent)
        {

            try
            {

                oconectar.Open(); //abrir la base de datos   
                SqlCommand ocmd = new SqlCommand("Insertar_Libro", oconectar);
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.Parameters.Clear();
                ocmd.Parameters.AddWithValue("@NombreLibro", oent[0].ToString());
                ocmd.Parameters.AddWithValue("@GeneroLibro", oent[1].ToString());
                ocmd.Parameters.AddWithValue("@PrecioLibro", Convert.ToInt32(oent[2]));

                if (ocmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                oconectar.Close();
            }

        }

        public bool GetActualizarLibro(string[] oent)
        {
            try
            {

                oconectar.Open(); //abrir la base de datos   
                SqlCommand ocmd = new SqlCommand("Actualizar_libro", oconectar);
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.Parameters.Clear();
                ocmd.Parameters.AddWithValue("@IdLibro", Convert.ToInt32(oent[0]));
                ocmd.Parameters.AddWithValue("@NombreLibro", oent[1].ToString());
                ocmd.Parameters.AddWithValue("@GeneroLibro", oent[2].ToString());
                ocmd.Parameters.AddWithValue("@PrecioLibro", Convert.ToInt32(oent[3]));
                int result = ocmd.ExecuteNonQuery();

                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                oconectar.Close();
            }
        }

        public bool GetEliminarLibro(string[] oent)
        {
            try
            {

                oconectar.Open(); //abrir la base de datos   
                SqlCommand ocmd = new SqlCommand("Eliminar_libro", oconectar);
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.Parameters.Clear();
                ocmd.Parameters.AddWithValue("@IdLibro", oent[0].ToString());

                if (ocmd.ExecuteNonQuery() < 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                oconectar.Close();
            }
        }
    }
}
