using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades " +
                    "ORDER BY desc_especialidad", sqlConn);
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                while (drEspecialidades.Read())
                {
                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                    especialidades.Add(esp);
                }

                drEspecialidades.Close();
            } catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar la lista de especialidades", Ex);
                throw ExceptionManejada;

            } finally
            {
                this.CloseConnection();
            }
            return especialidades;
        }
        public Especialidad GetOne(int ID)
        {
            Especialidad esp = new Especialidad();
            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad = @id", sqlConn);
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                if (drEspecialidades.Read())
                {
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                }
                drEspecialidades.Close();
            } catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("La especialidad seleccionada no existe", Ex);
                throw ExceptionManejada;
            }catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar los datos de la especialidad", Ex);
                throw ExceptionManejada;
            } finally
            {
                this.CloseConnection();
            }
            return esp;
        }
        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.New)
            {
                this.Insert(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                this.Update(especialidad);
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE especialidades WHERE id_especialidad = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            } catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("Existen dependencias de esta especialidad", Ex);
                throw ExceptionManejada;
            } catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("No se pudo eliminar la especialidad", Ex);
                throw ExceptionManejada;
            } finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE especialidades SET desc_especialidad = @desc " +
                    "WHERE id_especialidad = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                cmdSave.ExecuteNonQuery();
            } catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("La especialidad seleccionada no existe", Ex);
                throw ExceptionManejada;
            } catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al modificar los datos de la especialidad", Ex);
                throw ExceptionManejada;
            } finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO especialidades (desc_especialidad)" +
                    "VALUES (@desc) SELECT @@identity", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                especialidad.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            } catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al crear la especialidad", Ex);
                throw ExceptionManejada;
            } finally
            {
                this.CloseConnection();
            }
        }
    }
}
