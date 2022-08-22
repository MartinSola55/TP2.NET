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
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM planes p " +
                    "INNER JOIN especialidades e ON p.id_especialidad = e.id_especialidad " +
                    "ORDER BY p.desc_plan, e.desc_especialidad", sqlConn);
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan plan = new Plan();
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    plan.DescripcionEsp = (string)drPlanes["desc_especialidad"];
                    planes.Add(plan);
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al recuperar la lista de planes", Ex);
                throw exceptionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
            return planes;
        }
        public Plan GetOne(int ID)
        {
            Plan plan = new Plan();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM planes WHERE id_plan = @id", sqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                if (drPlanes.Read())
                {
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                }
                drPlanes.Close();
            }
            catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("El plan seleccionado no existe", Ex);
                throw exceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al recuperar los datos del plan", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return plan;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE planes WHERE id_plan = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("El plan seleccionado no existe", Ex);
                throw exceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("No se pudo eliminar el plan", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE planes SET desc_plan = @desc_plan, id_especialidad = @id_especialidad " +
                    "WHERE id_plan = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                cmdSave.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("El ID de la especialidad seleccionada no existe", Ex);
                throw exceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al modificar los datos del plan", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO planes (desc_plan, id_especialidad)" +
                    "VALUES (@desc_plan, @id_especialidad) SELECT @@identity", sqlConn);
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.VarChar, 50).Value = plan.IDEspecialidad;
                plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al crear el plan", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }
        public List<Plan> FiltraPlanes(string descripcion)
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand(
                    "SELECT * FROM planes p " +
                    "INNER JOIN especialidades e ON p.id_especialidad = e.id_especialidad " +
                    "WHERE p.desc_plan LIKE '%" + descripcion + "%'", sqlConn);
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan plan = new Plan();
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    plan.DescripcionEsp = (string)drPlanes["desc_especialidad"];
                    planes.Add(plan);
                }

                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al filtrar la lista de planes", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;
        }
        public Plan GetByDescripcion(Plan p)
        {
            Plan plan = new Plan();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM planes p " +
                    "INNER JOIN especialidades e ON p.id_especialidad = e.id_especialidad " +
                    "WHERE p.desc_plan = @descripcion " +
                    "AND p.id_especialidad = @id_esp", sqlConn);
                cmdPlanes.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = p.Descripcion;
                cmdPlanes.Parameters.Add("@id_esp", SqlDbType.Int).Value = p.IDEspecialidad;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                if (drPlanes.Read())
                {
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    plan.DescripcionEsp = (string)drPlanes["desc_especialidad"];
                }
                drPlanes.Close();
            }
            catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("El plan seleccionado no existe", Ex);
                throw ExceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar los datos del plan", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return plan;
        }
    }
}
