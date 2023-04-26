using System;
using ProyectoMuebleria.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Collections.Specialized;

namespace ProyectoMuebleria.Controllers
{
    public class ClientesController : Controller
    { 

  public string conexionString = ConfigurationManager.ConnectionStrings["bdOracle"].ConnectionString; 
    
        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }
        // Función para agregar un nuevo cliente
        public void AgregarCliente(int idCliente, int numDocumento,string nombre1,string nombre2, string otrosNombres, string apellido1,string apellido2, string apellidoCasado, string estado,string profesion, string tipoPersona, string nit)
        {
            using (OracleConnection conexion = new OracleConnection())
            {
                conexion.ConnectionString = conexionString;
                conexion.Open();

                using (OracleCommand comando = new OracleCommand())
                {
                    comando.CommandText = "INSERTAR_CLIENTE"; //nombre del procedimiento almacenado en Oracle
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Connection = conexion;

                    comando.Parameters.Add("IdCliente ", OracleDbType.Int64).Value = idCliente;
                    comando.Parameters.Add("numDocumento ", OracleDbType.Int64).Value = numDocumento ;
                    comando.Parameters.Add("P_Nombre ", OracleDbType.Varchar2).Value = nombre1;
                    comando.Parameters.Add("S_Nombre ", OracleDbType.Varchar2).Value = nombre1;
                    comando.Parameters.Add("P_Apellido ", OracleDbType.Varchar2).Value = apellido1;
                    comando.Parameters.Add("S_apellido ", OracleDbType.Varchar2).Value = apellido2;
                    comando.Parameters.Add("ApellidoCasado ", OracleDbType.Varchar2).Value = apellidoCasado;
                    comando.Parameters.Add("Estado ", OracleDbType.Varchar2).Value = estado;
                    comando.Parameters.Add("TipoPersona ", OracleDbType.Varchar2).Value = tipoPersona;
                    comando.Parameters.Add("Nit ", OracleDbType.Date).Value = nit;
                    comando.ExecuteNonQuery();
                }
            }
        }

        // Función para editar un cliente existente
        public void EditarCliente(int idCliente, int numDocumento, string nombre1, string nombre2, string otrosNombres, string apellido1, string apellido2, string apellidoCasado, string estado, string profesion, string tipoPersona, string nit)
        {
            using (OracleConnection conexion = new OracleConnection())
            {
                conexion.ConnectionString = conexionString;
                conexion.Open(); //abrir la conexion

                using (OracleCommand comando = new OracleCommand())
                {
                    comando.CommandText = "ACTUALIZAR_CLIENTE"; //nombre del procedimiento almacenado en Oracle
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Connection = conexion;

                    comando.Parameters.Add("IdCliente", OracleDbType.Int64).Value = idCliente;
                    comando.Parameters.Add("numDocumento", OracleDbType.Int64).Value = numDocumento;
                    comando.Parameters.Add("P_Nombre", OracleDbType.Varchar2).Value = nombre1;
                    comando.Parameters.Add("S_Nombre", OracleDbType.Varchar2).Value = nombre1;
                    comando.Parameters.Add("P_Apellido", OracleDbType.Varchar2).Value = apellido1;
                    comando.Parameters.Add("S_apellido", OracleDbType.Varchar2).Value = apellido2;
                    comando.Parameters.Add("ApellidoCasado", OracleDbType.Varchar2).Value = apellidoCasado;
                    comando.Parameters.Add("Estado", OracleDbType.Varchar2).Value = estado;
                    comando.Parameters.Add("TipoPersona", OracleDbType.Varchar2).Value = tipoPersona;
                    comando.Parameters.Add("Nit", OracleDbType.Date).Value = nit;

                    comando.ExecuteNonQuery();
                }
            }
        }

        // Función para eliminar un cliente existente
        public void EliminarCliente(int idCliente)
        {
            using (OracleConnection conexion = new OracleConnection())
            {
                conexion.ConnectionString = conexionString;
                conexion.Open();

                using (OracleCommand comando = new OracleCommand())
                {
                    comando.CommandText = "ELIMINAR_CLIENTE"; //nombre del procedimiento almacenado en Oracle
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Connection = conexion;

                    comando.Parameters.Add("id_Cliente", OracleDbType.Int32).Value = idCliente;

                    comando.ExecuteNonQuery();
                }
            }
        
        }
       


        /*


        public void Guardar()
        {
            using (OracleConnection conexion = new OracleConnection())
            {
                conexion.ConnectionString= conexionString;
                conexion.Open(); //abrir la conexion
                using (OracleCommand comando = new OracleCommand()) //Guardar con procedimientos 
                {
                 comando.CommandText = ""; //el NOM Lo jalo de um procedimiento de Guardar en ORACLE
                 comando.CommandType = CommandType.StoredProcedure;
                 comando.Connection = conexion;

                    comando.Parameters.Add("");//van los nombres que van dentro del procedim.. almace
                    comando.Parameters.Add("");
                    comando.Parameters.Add("");
                    comando.Parameters.Add("");
                    comando.Parameters.Add("");
                }
            }
        }
        */

    }
}