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
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand(
                    "SELECT * FROM materias m " +
                    "INNER JOIN planes p ON p.id_plan = m.id_plan " +
                    "INNER JOIN especialidades e ON e.id_especialidad = p.id_especialidad " +
                    "ORDER BY m.desc_materia, m.id_plan, p.desc_plan, e.desc_especialidad", sqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];
                    mat.DescripcionPlan = (string)drMaterias["desc_plan"];
                    mat.DescripcionPlan += " - ";
                    mat.DescripcionPlan += (string)drMaterias["desc_especialidad"];
                    materias.Add(mat);
                }

                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar la lista de materias", Ex);
                throw ExceptionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }
        public Materia GetOne(int ID)
        {
            Materia mat = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias m " +
                    "INNER JOIN planes p ON p.id_plan = m.id_plan " +
                    "INNER JOIN especialidades e ON e.id_especialidad = p.id_especialidad " +
                    "WHERE id_materia = @id " +
                    "ORDER BY m.desc_materia, m.id_plan, p.desc_plan, e.desc_especialidad", sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                if (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];
                    mat.DescripcionPlan = (string)drMaterias["desc_plan"];
                    mat.DescripcionPlan += " - ";
                    mat.DescripcionPlan += (string)drMaterias["desc_especialidad"];
                }
                drMaterias.Close();
            }
            catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("La materia seleccionada no existe", Ex);
                throw ExceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar los datos de la materia", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mat;
        }
        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.New)
            {
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE materias WHERE id_materia = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("La materia seleccionada no existe", Ex);
                throw ExceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("No se pudo eliminar la materia", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET desc_materia = @desc_materia, " +
                    "hs_semanales = @hs_semanales, hs_totales = @hs_totales, id_plan = @id_plan WHERE id_materia = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IDPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("El ID del plan ingresado no pertenece a uno existente", Ex);
                throw ExceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al modificar los datos de la materia", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO materias (desc_materia, hs_semanales, hs_totales, id_plan)" +
                    "VALUES (@desc_materia, @hs_semanales, @hs_totales, @id_plan) SELECT @@identity", sqlConn);
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IDPlan;
                materia.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("El ID del plan ingresado no pertenece a una materia existente", Ex);
                throw ExceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al crear la materia", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public List<Materia> FiltraMaterias(string descripcion)
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand(
                    "SELECT * FROM materias m " +
                    "INNER JOIN planes p ON p.id_plan = m.id_plan " +
                    "INNER JOIN especialidades e ON e.id_especialidad = p.id_especialidad " +
                    "WHERE m.desc_materia LIKE '%" + descripcion + "%' " +
                    "ORDER BY m.desc_materia, m.id_plan, p.desc_plan, e.desc_especialidad", sqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia materia = new Materia();
                    materia.ID = (int)drMaterias["id_materia"];
                    materia.Descripcion = (string)drMaterias["desc_materia"];
                    materia.HSSemanales = (int)drMaterias["hs_semanales"];
                    materia.HSTotales = (int)drMaterias["hs_totales"];
                    materia.IDPlan = (int)drMaterias["id_plan"];
                    materia.DescripcionPlan = (string)drMaterias["desc_plan"];
                    materia.DescripcionPlan += " - ";
                    materia.DescripcionPlan += (string)drMaterias["desc_especialidad"];
                    materias.Add(materia);
                }

                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al filtrar la lista de materias", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }
        public Materia GetRepetido(Materia m)
        {
            Materia materia = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand(
                    "SELECT * FROM materias m " +
                    "INNER JOIN planes p ON p.id_plan = m.id_plan " +
                    "INNER JOIN especialidades e ON e.id_especialidad = p.id_especialidad " +
                    "WHERE m.desc_materia = @descripcion " +
                    "AND m.id_plan = @id_plan " +
                    "AND NOT m.id_materia = @id_materia", sqlConn);
                cmdMaterias.Parameters.Add("@id_materia", SqlDbType.Int).Value = m.ID;
                cmdMaterias.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = m.Descripcion;
                cmdMaterias.Parameters.Add("@id_plan", SqlDbType.Int).Value = m.IDPlan;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                if (drMaterias.Read())
                {
                    materia.ID = (int)drMaterias["id_materia"];
                    materia.Descripcion = (string)drMaterias["desc_materia"];
                    materia.HSSemanales = (int)drMaterias["hs_semanales"];
                    materia.HSTotales = (int)drMaterias["hs_totales"];
                    materia.IDPlan = (int)drMaterias["id_plan"];
                    materia.DescripcionPlan = (string)drMaterias["desc_plan"];
                    materia.DescripcionPlan += " - ";
                    materia.DescripcionPlan += (string)drMaterias["desc_especialidad"];
                }
                drMaterias.Close();
            }
            catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("la materia seleccionada no existe", Ex);
                throw ExceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar los datos de la materia", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materia;
        }
    }
}
