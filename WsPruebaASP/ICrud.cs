using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WsPruebaASP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ICrud" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ICrud
    {
        [OperationContract]
        DataSet GetConsultarLibros();

        [OperationContract]
        bool GetInsertarLibro(string[] oent);

        [OperationContract]
        bool GetActualizarLibro(string[] oent);

        [OperationContract]
        bool GetEliminarLibro(string[] oent);

        [OperationContract]
        DataSet GetConsultarLibroids(int id);

    }
}
