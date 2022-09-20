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
    public class CargoAdapter : Adapter
    {
        public List<Cargo> GetAll()
        {
            List<Cargo> cargos = new List<Cargo>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCargos = new SqlCommand("SELECT * FROM cargos", sqlConn);
                SqlDataReader drCargos = cmdCargos.ExecuteReader();
                while (drCargos.Read())
                {
                    Cargo car = new Cargo();
                    car.ID = (int)drCargos["id_cargo"];
                    car.Descripcion = (string)drCargos["desc_cargo"];
                    cargos.Add(car);
                }

                drCargos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar la lista de cargos", Ex);
                throw ExceptionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
            return cargos;
        }
        public Cargo GetOne(int ID)
        {
            Cargo car = new Cargo();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCargos = new SqlCommand("SELECT * FROM cargos WHERE id_cargo = @id", sqlConn);
                cmdCargos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCargos = cmdCargos.ExecuteReader();
                if (drCargos.Read())
                {
                    car.ID = (int)drCargos["id_cargo"];
                    car.Descripcion = (string)drCargos["desc_cargo"];
                }
                drCargos.Close();
            }
            catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("El cargo seleccionada no existe", Ex);
                throw ExceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar los datos del cargo", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return car;
        }
    }
}
