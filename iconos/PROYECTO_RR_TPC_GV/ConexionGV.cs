using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_RR_TPC_GV
{
    internal class ConexionGV
    {
        //Cadena de conexión 
        //string Cadconex = "Server=(local); Database=GestionVeterinaria; uid=sa; pwd=123";
        //string Cadconex = "data source=.; initial catalog=Northwind; user id=sa; password=123";
        string Cadconex = "Server=REGIS-DORIS-EDY\\SQLEXPRESS; Database=GestionVeterinaria; Integrated Security=true";
        //string Cadconex = "Server=DESKTOP-3MKF80Q\\SQLEXPRESS; Database=GestionVeterinaria; integrated security=true";

        public SqlConnection Conex = new SqlConnection();  //se crea un objeto Conex para la conexión

        //Crear un metodo vacío, para Abrir y Cerrar la conexión
        public void abrir()
        {
            try
            {
                Conex.ConnectionString = Cadconex;    //iniciando la propiedad ConnectionString
                Conex.Open();
                Console.WriteLine("Conexión satisfactoria con la BD GestionVeterinaria...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de conexión.." + ex.Message);
            }
        }

        public void cerrar()
        {
            Conex.Close();
        }
    }
}
