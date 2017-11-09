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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Usuario" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Usuario.svc o Usuario.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Usuario : IUsuario
    {
        readonly SqlConnection oconectar = new SqlConnection("Data Source=DESKTOP-OQ7Q3GE\\PRUEBASSQL;Initial Catalog=PruebaASP;User ID=saPruebas;Password=1234");


        public bool GetInsertarUsuario(string[] oent)
        {
            try
            {

                oconectar.Open(); //abrir la base de datos   
                SqlCommand ocmd = new SqlCommand("Insertar_Usuario2", oconectar);
                ocmd.CommandType = CommandType.StoredProcedure;
                //ocmd.Parameters.Clear();
                ocmd.Parameters.AddWithValue("@Usuario", oent[0].ToString());
                ocmd.Parameters.AddWithValue("@Contraseña", (oent[1]).ToString());
                ocmd.Parameters.AddWithValue("@Nombre", oent[2].ToString());
                ocmd.Parameters.AddWithValue("@Email", oent[3].ToString());
                int result =ocmd.ExecuteNonQuery();

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

        public bool GetVerificarUsuario(string[] oent)
        {
            try
            {

                oconectar.Open(); //abrir la base de datos   
                SqlCommand ocmd = new SqlCommand("Verificar_usuario", oconectar);
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.Parameters.Clear();
                ocmd.Parameters.AddWithValue("@Usuario", oent[0].ToString());
                ocmd.Parameters.AddWithValue("@Contrasena", (oent[1]).ToString());
                ocmd.ExecuteNonQuery();
                if (ocmd.ExecuteNonQuery() < 0)
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
