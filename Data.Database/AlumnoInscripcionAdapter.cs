﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetInscripcionesAlumnno(int id)
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("SELECT * FROM alumnos_inscripciones ai " +
                    "INNER JOIN cursos c ON ai.id_curso = c.id_curso " +
                    "INNER JOIN materias m ON c.id_materia = m.id_materia " +
                    "INNER JOIN comisiones com ON c.id_comision = com.id_comision " +
                    "INNER JOIN planes p ON m.id_plan = p.id_plan " +
                    "WHERE id_alumno = @id " +
                    "ORDER BY anio_calendario DESC", sqlConn);
                cmdInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
                while (drInscripciones.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.IDAlumno = (int)drInscripciones["id_alumno"];
                    ins.IDCurso = (int)drInscripciones["id_curso"];
                    int anio = (int)drInscripciones["anio_calendario"];
                    ins.DescripcionCurso = anio.ToString();
                    ins.DescripcionCurso += " - ";
                    ins.DescripcionCurso += (string)drInscripciones["desc_comision"];
                    ins.DescripcionCurso += " - ";
                    ins.DescripcionCurso += (string)drInscripciones["desc_materia"];
                    ins.DescripcionCurso += " - ";
                    ins.DescripcionCurso += (string)drInscripciones["desc_plan"];
                    ins.Nota = (int)drInscripciones["nota"];
                    ins.Condicion = (string)drInscripciones["condicion"];
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
        public AlumnoInscripcion GetOne(int id)
        {
            AlumnoInscripcion ins = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripcion = new SqlCommand("SELECT * FROM alumnos_inscripciones ai " +
                    "INNER JOIN cursos c ON ai.id_curso = c.id_curso " +
                    "INNER JOIN materias m ON c.id_materia = m.id_materia " +
                    "INNER JOIN comisiones com ON c.id_comision = com.id_comision " +
                    "INNER JOIN planes p ON m.id_plan = p.id_plan " +
                    "WHERE id_inscripcion = @id ", sqlConn);
                cmdInscripcion.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drInscripcion = cmdInscripcion.ExecuteReader();
                if (drInscripcion.Read())
                {
                    ins.ID = (int)drInscripcion["id_inscripcion"];
                    ins.IDAlumno = (int)drInscripcion["id_alumno"];
                    ins.IDCurso = (int)drInscripcion["id_curso"];
                    int anio = (int)drInscripcion["anio_calendario"];
                    ins.DescripcionCurso = anio.ToString();
                    ins.DescripcionCurso += " - ";
                    ins.DescripcionCurso += (string)drInscripcion["desc_comision"];
                    ins.DescripcionCurso += " - ";
                    ins.DescripcionCurso += (string)drInscripcion["desc_materia"];
                    ins.DescripcionCurso += " - ";
                    ins.DescripcionCurso += (string)drInscripcion["desc_plan"];
                    ins.Nota = (int)drInscripcion["nota"];
                    ins.Condicion = (string)drInscripcion["condicion"];
                }
                drInscripcion.Close();
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
        public void Save(AlumnoInscripcion inscripcion)
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
                SqlCommand cmdDelete = new SqlCommand("DELETE alumnos_inscripciones WHERE id_inscripcion = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("La inscripción seleccionada no existe", Ex);
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
        public void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE alumnos_inscripciones SET id_curso = @id_curso, condicion = @condicion, nota = @nota " +
                    "WHERE id_inscripcion = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = inscripcion.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
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
        public void Insert(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO alumnos_inscripciones (id_curso, id_alumno, condicion, nota) " +
                    "VALUES (@id_curso, @id_alumno, @condicion, @nota) SELECT @@identity", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = inscripcion.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IDAlumno;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
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
        public bool EsInscripcionRepetida(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripcion = new SqlCommand(
                    "SELECT * FROM alumnos_inscripciones " +
                    "WHERE id_curso = @curso " +
                    "AND id_alumno = @id_alumno " +
                    "AND condicion = @condicion " +
                    "AND NOT id_inscripcion = @id", sqlConn);
                cmdInscripcion.Parameters.Add("@curso", SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdInscripcion.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IDAlumno;
                cmdInscripcion.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion    ;
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
