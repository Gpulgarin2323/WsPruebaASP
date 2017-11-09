using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WsPruebaASP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUsuario" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuario
    {
        [OperationContract]
        bool GetInsertarUsuario(string[] oent);

        [OperationContract]
        DataSet GetVerificarUsuario(string[] oent);
    }
}
