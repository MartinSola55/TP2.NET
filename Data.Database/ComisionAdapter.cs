using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand(
                    "SELECT * FROM comisiones c " +
                    "INNER JOIN planes p ON c.id_plan = p.id_plan " +
                    "INNER JOIN especialidades e ON p.id_especialidad = e.id_especialidad " +
                    "ORDER BY desc_comision", sqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision com = new Comision();
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];
                    com.PlanDesc = (string)drComisiones["desc_plan"];
                    com.PlanDesc += " - ";
                    com.PlanDesc += (string)drComisiones["desc_especialidad"];
                    comisiones.Add(com);
                }

                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar la lista de comisiones", Ex);
                throw ExceptionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }
        public Comision GetOne(int ID)
        {
            Comision com = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("SELECT * FROM comisiones WHERE id_comision = @id", sqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                if (drComisiones.Read())
                {
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];
                }
                drComisiones.Close();
            } catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("La comisión seleccionada no existe", Ex);
                throw ExceptionManejada;
            } catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar los datos de la comisión", Ex);
                throw ExceptionManejada;
            } finally
            {
                this.CloseConnection();
            }
            return com;
        }
        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comision.ID);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                this.Update(comision);
            }
            comision.State = BusinessEntity.States.Unmodified;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE comisiones WHERE id_comision = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("La comisión seleccionada no existe", Ex);
                if (Ex.Number == 547)
                {
                    ExceptionManejada = new Exception("No se pudo eliminar la comisión\nSe debe elimnar el curso que la contiene", Ex);
                }
                throw ExceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("No se pudo eliminar la comisión", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision = @desc_comision, " +
                    "anio_especialidad = @anio_especialidad, id_plan = @id_plan WHERE id_comision = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                cmdSave.ExecuteNonQuery();
            } catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("El ID del plan ingresado no pertenece a un plan existente", Ex);
                throw ExceptionManejada;
            } catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al modificar los datos de la comisión", Ex);
                throw ExceptionManejada;
            } finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO comisiones (desc_comision, anio_especialidad, id_plan)" +
                    "VALUES (@desc_comision, @anio_especialidad, @id_plan) SELECT @@identity", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                comision.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            } catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("El ID del plan ingresado no pertenece a un plan existente", Ex);
                throw ExceptionManejada;
            } catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al crear la comisión", Ex);
                throw ExceptionManejada;
            } finally
            {
                this.CloseConnection();
            }
        }
        public List<Comision> FiltraComisiones(string descripcion)
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand(
                    "SELECT * FROM comisiones c " +
                    "INNER JOIN planes p ON c.id_plan = p.id_plan " +
                    "INNER JOIN especialidades e ON p.id_especialidad = e.id_especialidad " +
                    "WHERE c.desc_comision LIKE '%" + descripcion + "%' " +
                    "ORDER BY desc_comision", sqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision comision = new Comision();
                    comision.ID = (int)drComisiones["id_comision"];
                    comision.Descripcion = (string)drComisiones["desc_comision"];
                    comision.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comision.IDPlan = (int)drComisiones["id_plan"];
                    comision.PlanDesc = (string)drComisiones["desc_plan"];
                    comision.PlanDesc += " - ";
                    comision.PlanDesc += (string)drComisiones["desc_especialidad"];
                    comisiones.Add(comision);
                }

                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al filtrar la lista de comisiones", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }
        public Comision GetRepetido(Comision c)
        {
            Comision comision = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand(
                     "SELECT * FROM comisiones c " +
                    "INNER JOIN planes p ON c.id_plan = p.id_plan " +
                    "INNER JOIN especialidades e ON p.id_especialidad = e.id_especialidad " +
                    "WHERE c.desc_comision = @descripcion " +
                    "AND c.id_plan = @id_plan " +
                    "AND c.anio_especialidad = @anio " +
                    "AND NOT c.id_comision = @id_comision", sqlConn);
                cmdComisiones.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = c.Descripcion;
                cmdComisiones.Parameters.Add("@id_plan", SqlDbType.Int).Value = c.IDPlan;
                cmdComisiones.Parameters.Add("@anio", SqlDbType.Int).Value = c.AnioEspecialidad;
                cmdComisiones.Parameters.Add("@id_comision", SqlDbType.Int).Value = c.ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                if (drComisiones.Read())
                {
                    comision.ID = (int)drComisiones["id_comision"];
                    comision.Descripcion = (string)drComisiones["desc_comision"];
                    comision.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comision.IDPlan = (int)drComisiones["id_plan"];
                    comision.PlanDesc = (string)drComisiones["desc_plan"];
                    comision.PlanDesc += " - ";
                    comision.PlanDesc += (string)drComisiones["desc_especialidad"];
                }
                drComisiones.Close();
            }
            catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("La comisión seleccionada no existe", Ex);
                throw ExceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar los datos de la comisión", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comision;
        }
    }
}
