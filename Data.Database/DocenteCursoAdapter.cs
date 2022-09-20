using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetInscripcionesDocente(int id)
        {
            List<DocenteCurso> inscripciones = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("SELECT * FROM docentes_cursos dc " +
                    "INNER JOIN cursos c ON dc.id_curso = c.id_curso " +
                    "INNER JOIN materias m ON c.id_materia = m.id_materia " +
                    "INNER JOIN comisiones com ON c.id_comision = com.id_comision " +
                    "INNER JOIN planes p ON m.id_plan = p.id_plan " +
                    "INNER JOIN cargos car ON dc.id_cargo = car.id_cargo " +
                    "WHERE id_docente = @id " +
                    "ORDER BY anio_calendario DESC", sqlConn);
                cmdInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
                while (drInscripciones.Read())
                {
                    DocenteCurso ins = new DocenteCurso();
                    ins.ID = (int)drInscripciones["id_dictado"];
                    ins.IDDocente = (int)drInscripciones["id_docente"];
                    ins.IDCurso = (int)drInscripciones["id_curso"];
                    ins.IDComision = (int)drInscripciones["id_comision"];
                    ins.IDMateria = (int)drInscripciones["id_materia"];
                    int anio = (int)drInscripciones["anio_calendario"];
                    ins.DescripcionCurso = anio.ToString();
                    ins.DescripcionCurso += " - ";
                    ins.DescripcionCurso += (string)drInscripciones["desc_comision"];
                    ins.DescripcionCurso += " - ";
                    ins.DescripcionCurso += (string)drInscripciones["desc_materia"];
                    ins.DescripcionCurso += " - ";
                    ins.DescripcionCurso += (string)drInscripciones["desc_plan"];
                    ins.IDCargo = (int)drInscripciones["id_cargo"];
                    ins.DescripcionCargo = (string)drInscripciones["desc_cargo"];
                    inscripciones.Add(ins);
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al recuperar la lista de inscripciones", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripciones;
        }
        public DocenteCurso GetOne(int id)
        {
            DocenteCurso ins = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("SELECT * FROM docentes_cursos dc " +
                    "INNER JOIN cursos c ON dc.id_curso = c.id_curso " +
                    "INNER JOIN materias m ON c.id_materia = m.id_materia " +
                    "INNER JOIN comisiones com ON c.id_comision = com.id_comision " +
                    "INNER JOIN planes p ON m.id_plan = p.id_plan " +
                    "INNER JOIN cargos car ON dc.id_cargo = car.id_cargo " +
                    "WHERE id_dictado = @id ", sqlConn);
                cmdInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
                if (drInscripciones.Read())
                {
                    ins.ID = (int)drInscripciones["id_dictado"];
                    ins.IDDocente = (int)drInscripciones["id_docente"];
                    ins.IDCurso = (int)drInscripciones["id_curso"];
                    int anio = (int)drInscripciones["anio_calendario"];
                    ins.DescripcionCurso = anio.ToString();
                    ins.DescripcionCurso += " - ";
                    ins.DescripcionCurso += (string)drInscripciones["desc_comision"];
                    ins.DescripcionCurso += " - ";
                    ins.DescripcionCurso += (string)drInscripciones["desc_materia"];
                    ins.DescripcionCurso += " - ";
                    ins.DescripcionCurso += (string)drInscripciones["desc_plan"];
                    ins.IDCargo = (int)drInscripciones["id_cargo"];
                    ins.DescripcionCargo += (string)drInscripciones["desc_cargo"];
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al recuperar la inscripción", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ins;
        }
        public void Save(DocenteCurso inscripcion)
        {
            if (inscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(inscripcion);
            }
            else if (inscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(inscripcion.ID);
            }
            else if (inscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(inscripcion);
            }
            inscripcion.State = BusinessEntity.States.Unmodified;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE docentes_cursos WHERE id_dictado = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("La inscripción seleccionada no existe", Ex);
                if (Ex.Number == 547)
                {
                    exceptionManejada = new Exception("Existen dependencias del cargo que desea eliminar", Ex);
                }
                throw exceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("No se pudo eliminar la inscripción", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(DocenteCurso inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE docentes_cursos SET id_curso = @id_curso, id_cargo = @id_cargo " +
                    "WHERE id_dictado = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = inscripcion.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdSave.Parameters.Add("@id_cargo", SqlDbType.VarChar, 50).Value = inscripcion.IDCargo;
                cmdSave.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("La inscripción seleccionada no existe", Ex);
                throw exceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al modificar los datos de la inscripción", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(DocenteCurso inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO docentes_cursos (id_curso, id_docente, id_cargo) " +
                    "VALUES (@id_curso, @id_docente, @id_cargo) SELECT @@identity", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = inscripcion.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = inscripcion.IDDocente;
                cmdSave.Parameters.Add("@id_cargo", SqlDbType.VarChar, 50).Value = inscripcion.IDCargo;
                inscripcion.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al crear la inscripción", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public bool EsInscripcionRepetida(DocenteCurso inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripcion = new SqlCommand(
                    "SELECT * FROM docentes_cursos " +
                    "WHERE id_curso = @curso " +
                    "AND id_docente = @id_docente " +
                    "AND NOT id_dictado = @id", sqlConn);
                cmdInscripcion.Parameters.Add("@curso", SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdInscripcion.Parameters.Add("@id_docente", SqlDbType.Int).Value = inscripcion.IDDocente;
                cmdInscripcion.Parameters.Add("@id", SqlDbType.Int).Value = inscripcion.ID;
                SqlDataReader drInscripcion = cmdInscripcion.ExecuteReader();
                if (drInscripcion.Read())
                {
                    return true;
                }
                drInscripcion.Close();
            }
            catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("No se pueden recuperar las inscripciones", Ex);
                throw ExceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar las inscripciones", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }
    }
}
