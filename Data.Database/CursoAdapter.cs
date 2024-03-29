﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand(
                    "SELECT * FROM cursos c " +
                    "INNER JOIN materias m ON c.id_materia = m.id_materia " +
                    "INNER JOIN comisiones com ON c.id_comision = com.id_comision " +
                    "INNER JOIN planes p ON p.id_plan = m.id_plan " +
                    "INNER JOIN especialidades e ON e.id_especialidad = p.id_especialidad " +
                    "ORDER BY m.desc_materia, com.desc_comision"
                    , sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso curso = new Curso();
                    curso.ID = (int)drCursos["id_curso"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];
                    curso.MateriaDesc = (string)drCursos["desc_materia"];
                    curso.MateriaDesc += " - ";
                    curso.MateriaDesc += (string)drCursos["desc_plan"];
                    curso.MateriaDesc += " - ";
                    curso.MateriaDesc += (string)drCursos["desc_especialidad"];
                    curso.ComisionDesc = (string)drCursos["desc_comision"];
                    cursos.Add(curso);
                }

                drCursos.Close();
            } catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al recuperar la lista de cursos", Ex);
                throw exceptionManejada;

            } finally
            {
                this.CloseConnection();
            }
            return cursos;
        }
        public Curso GetOne(int ID)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM cursos WHERE id_curso = @id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    curso.ID = (int)drCursos["id_curso"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];

                }
                drCursos.Close();
            } catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("El curso ingresado no existe", Ex);
                throw exceptionManejada;
            } catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al recuperar datos del curso", Ex);
                throw exceptionManejada;
            } finally
            {
                this.CloseConnection();
            }
            return curso;
        }
        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE cursos WHERE id_curso = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            } catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("El curso seleccionado no existe", Ex);
                if (Ex.Number == 547)
                {
                    exceptionManejada = new Exception("Existen dependencias del curso que desea eliminar", Ex);
                }
                throw exceptionManejada;
            } catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al eliminar el curso", Ex);
                throw exceptionManejada;
            } finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET id_materia = @id_materia, id_comision = @id_comision," +
                    " anio_calendario = @anio_calendario, cupo = @cupo WHERE id_curso = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.ExecuteNonQuery();
            } catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("El ID de materia o comisión ingresados no corresponde a uno existente, " +
                    "o el curso seleccionado no existe", Ex);
                throw exceptionManejada;
            } catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al modificar datos del curso", Ex);
                throw exceptionManejada;
            } finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO cursos (id_materia, id_comision, anio_calendario, cupo)" +
                    "VALUES (@id_materia, @id_comision, @anio_calendario, @cupo) SELECT @@identity", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;

                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            } catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("El ID de materia o comisión ingresados no corresponde a uno existente", Ex);
                throw exceptionManejada;
            } catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al crear el curso", Ex);
                throw exceptionManejada;
            } finally
            {
                this.CloseConnection();
            }
        }
        public Curso GetRepetido(Curso c)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand(
                    "SELECT * FROM cursos c " +
                    "INNER JOIN materias m ON c.id_materia = m.id_materia " +
                    "INNER JOIN comisiones com ON c.id_comision = com.id_comision " +
                    "WHERE c.id_materia = @id_materia " +
                    "AND c.id_comision = @id_comision " +
                    "AND c.anio_calendario = @anio " +
                    "AND NOT c.id_curso = @id_curso"
                    , sqlConn);
                cmdCursos.Parameters.Add("@id_materia", SqlDbType.VarChar, 50).Value = c.IDMateria;
                cmdCursos.Parameters.Add("@id_comision", SqlDbType.Int).Value = c.IDComision;
                cmdCursos.Parameters.Add("@anio", SqlDbType.Int).Value = c.AnioCalendario;
                cmdCursos.Parameters.Add("@id_curso", SqlDbType.Int).Value = c.ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    curso.ID = (int)drCursos["id_curso"];
                    curso.Cupo = (int)drCursos["cupo"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.ComisionDesc = (string)drCursos["desc_comision"];
                    curso.MateriaDesc = (string)drCursos["desc_materia"];
                }
                drCursos.Close();
            }
            catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("El curso seleccionado no existe", Ex);
                throw ExceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar los datos del curso", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return curso;
        }
    }
}
