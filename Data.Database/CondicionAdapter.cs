using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class CondicionAdapter : Adapter
    {
        public List<Condicion> GetAll()
        {
            List<Condicion> condiciones = new List<Condicion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCondiciones = new SqlCommand("SELECT * FROM condiciones_alumnos", sqlConn);
                SqlDataReader drCondiciones = cmdCondiciones.ExecuteReader();
                while (drCondiciones.Read())
                {
                    Condicion con = new Condicion();
                    con.ID = (int)drCondiciones["id_condicion"];
                    con.Descripcion = (string)drCondiciones["desc_condicion"];
                    condiciones.Add(con);
                }

                drCondiciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar la lista de condiciones", Ex);
                throw ExceptionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
            return condiciones;
        }
        public Condicion GetOne(int ID)
        {
            Condicion con = new Condicion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCondiciones = new SqlCommand("SELECT * FROM condiciones_alumnos WHERE id_condicion = @id", sqlConn);
                cmdCondiciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCondiciones = cmdCondiciones.ExecuteReader();
                if (drCondiciones.Read())
                {
                    con.ID = (int)drCondiciones["id_condicion"];
                    con.Descripcion = (string)drCondiciones["desc_condicion"];
                }
                drCondiciones.Close();
            }
            catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("La conndición seleccionada no existe", Ex);
                throw ExceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar los datos de la condición", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return con;
        }
    }
}
