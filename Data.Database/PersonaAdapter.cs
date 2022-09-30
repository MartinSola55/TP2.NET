using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas p " +
                    "INNER JOIN planes pl ON p.id_plan = pl.id_plan " +
                    "INNER JOIN especialidades e ON pl.id_especialidad = e.id_especialidad " +
                    "ORDER BY apellido, nombre", sqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona per = new Persona();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.NacimientoString = per.FechaNacimiento.ToShortDateString();
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (int)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.DescPlan = (string)drPersonas["desc_plan"];
                    per.DescPlan += " - ";
                    per.DescPlan += (string)drPersonas["desc_especialidad"];
                    personas.Add(per);
                }

                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al recuperar la lista de personas", Ex);
                throw exceptionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }
        public List<Persona> GetAlumnos()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas p " +
                    "INNER JOIN planes pl ON p.id_plan = pl.id_plan " +
                    "INNER JOIN especialidades e ON pl.id_especialidad = e.id_especialidad " +
                    "LEFT JOIN usuarios u ON p.id_persona = u.id_persona " +
                    "WHERE p.tipo_persona = 2 " +
                    "ORDER BY apellido, nombre", sqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona per = new Persona();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.NacimientoString = per.FechaNacimiento.ToShortDateString();
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (int)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.DescPlan = (string)drPersonas["desc_plan"];
                    per.DescPlan += " - ";
                    per.DescPlan += (string)drPersonas["desc_especialidad"];
                    if (drPersonas["nombre_usuario"] != DBNull.Value)
                    {
                        per.NombreUsuario = (string)drPersonas["nombre_usuario"];
                    }
                    personas.Add(per);
                }

                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al recuperar la lista de alumnos", Ex);
                throw exceptionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }
        public List<Persona> GetDocentes()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas p " +
                    "INNER JOIN planes pl ON p.id_plan = pl.id_plan " +
                    "INNER JOIN especialidades e ON pl.id_especialidad = e.id_especialidad " +
                    "LEFT JOIN usuarios u ON p.id_persona = u.id_persona " +
                    "WHERE p.tipo_persona = 1 " +
                    "ORDER BY apellido, nombre", sqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona per = new Persona();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.NacimientoString = per.FechaNacimiento.ToShortDateString();
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (int)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.DescPlan = (string)drPersonas["desc_plan"];
                    per.DescPlan += " - ";
                    per.DescPlan += (string)drPersonas["desc_especialidad"];
                    if (drPersonas["nombre_usuario"] != DBNull.Value)
                    {
                        per.NombreUsuario = (string)drPersonas["nombre_usuario"];
                    }
                    personas.Add(per);
                }

                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al recuperar la lista de docentes", Ex);
                throw exceptionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }
        public Persona GetOne(int ID)
            {
            Persona per = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand(
                    "SELECT * FROM personas p " +
                    "LEFT JOIN usuarios u ON p.id_persona = u.id_persona " +
                    "INNER JOIN planes pl ON p.id_plan = pl.id_plan " +
                    "INNER JOIN especialidades e ON pl.id_especialidad = e.id_especialidad " +
                    "WHERE p.id_persona = @id", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.NacimientoString = per.FechaNacimiento.ToShortDateString();
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (int)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.DescPlan = (string)drPersonas["desc_plan"];
                    per.DescPlan += " - ";
                    per.DescPlan += (string)drPersonas["desc_especialidad"];
                    per.NombreUsuario = drPersonas["nombre_usuario"] as string;
                }
                drPersonas.Close();
            }
            catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("La persona seleccionada no existe", Ex);
                throw exceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al recuperar los datos de la persona", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return per;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE personas WHERE id_persona = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("La persona seleccionada no existe", Ex);
                if (Ex.Number == 547)
                {
                    exceptionManejada = new Exception("Existen dependencias de la persona que desea eliminar", Ex);
                }
                throw exceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("No se pudo eliminar la persona", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE personas SET nombre = @nombre, apellido = @apellido, " +
                    "direccion = @direccion, email = @email, telefono = @telefono, fecha_nac = @fecha_nac, " +
                    "legajo = @legajo, tipo_persona = @tipo_persona, id_plan = @id_plan WHERE id_persona = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("La persona seleccionada no existe", Ex);
                throw exceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al modificar los datos de la persona", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO personas (nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan) " +
                    "VALUES (@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan) SELECT @@identity", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al crear la persona", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }
        public bool EsLegajoRepetido(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand(
                    "SELECT legajo FROM personas " +
                    "WHERE legajo = @legajo " +
                    "AND NOT id_persona = @id", sqlConn);
                cmdPersonas.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                if (drPersonas.Read())
                {
                    return true;
                }
                drPersonas.Close();
            }
            catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("No se pueden recuperar los legajos", Ex);
                throw ExceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar los legajos", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }
        public Persona GetRepetido(Persona per)
        {
            Persona persona = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand(
                    "SELECT * FROM personas p " +
                    "INNER JOIN planes pl ON p.id_plan = pl.id_plan " +
                    "INNER JOIN especialidades e ON pl.id_especialidad = e.id_especialidad " +
                    "WHERE p.nombre = @nombre " +
                    "AND p.apellido = @apellido " +
                    "AND p.fecha_nac = @nacimiento " +
                    "AND p.tipo_persona = @tipo_persona " +
                    "AND p.id_plan = @id_plan " +
                    "AND NOT p.id_persona = @id_persona", sqlConn);
                cmdPersonas.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = per.Nombre;
                cmdPersonas.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = per.Apellido;
                cmdPersonas.Parameters.Add("@nacimiento", SqlDbType.DateTime).Value = per.FechaNacimiento.ToShortDateString();
                cmdPersonas.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = per.TipoPersona;
                cmdPersonas.Parameters.Add("@id_plan", SqlDbType.Int).Value = per.IDPlan;
                cmdPersonas.Parameters.Add("@id_persona", SqlDbType.Int).Value = per.ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                if (drPersonas.Read())
                {
                    persona.ID = (int)drPersonas["id_persona"];
                    persona.Nombre = (string)drPersonas["nombre"];
                    persona.Apellido = (string)drPersonas["apellido"];
                    persona.Direccion = (string)drPersonas["direccion"];
                    persona.Email = (string)drPersonas["email"];
                    persona.Telefono = (string)drPersonas["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    persona.NacimientoString = per.FechaNacimiento.ToShortDateString();
                    persona.Legajo = (int)drPersonas["legajo"];
                    persona.TipoPersona = (int)drPersonas["tipo_persona"];
                    persona.IDPlan = (int)drPersonas["id_plan"];
                    persona.DescPlan = (string)drPersonas["desc_plan"];
                    persona.DescPlan += " - ";
                    persona.DescPlan += (string)drPersonas["desc_especialidad"];
                }
                drPersonas.Close();
            }
            catch (SqlException Ex)
            {
                Exception ExceptionManejada = new Exception("La persona seleccionada no existe", Ex);
                throw ExceptionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Hubo un error al recuperar los datos de la persona", Ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return persona;
        }
        public List<Persona> GetByLegajo(string nombre, string apellido, string legajo)
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand(
                    "SELECT * FROM personas p " +
                    "INNER JOIN planes pl ON p.id_plan = pl.id_plan " +
                    "INNER JOIN especialidades e ON pl.id_especialidad = e.id_especialidad " +
                    "WHERE p.nombre LIKE '%" + nombre + "%' " +
                    "AND p.apellido LIKE '%" + apellido + "%' " +
                    "AND p.legajo LIKE '%" + int.Parse(legajo) + "%' " +
                    "ORDER BY apellido, nombre", sqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona persona = new Persona();
                    persona.ID = (int)drPersonas["id_persona"];
                    persona.Nombre = (string)drPersonas["nombre"];
                    persona.Apellido = (string)drPersonas["apellido"];
                    persona.Direccion = (string)drPersonas["direccion"];
                    persona.Email = (string)drPersonas["email"];
                    persona.Telefono = (string)drPersonas["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    persona.NacimientoString = persona.FechaNacimiento.ToShortDateString();
                    persona.Legajo = (int)drPersonas["legajo"];
                    persona.TipoPersona = (int)drPersonas["tipo_persona"];
                    persona.IDPlan = (int)drPersonas["id_plan"];
                    persona.DescPlan = (string)drPersonas["desc_plan"];
                    persona.DescPlan += " - ";
                    persona.DescPlan += (string)drPersonas["desc_especialidad"];
                    personas.Add(persona);  
                }

                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al filtrar la lista de personas", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }
        public List<Persona> FiltraPersonas(string nombre, string apellido)
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand(
                    "SELECT * FROM personas p " +
                    "INNER JOIN planes pl ON p.id_plan = pl.id_plan " +
                    "INNER JOIN especialidades e ON pl.id_especialidad = e.id_especialidad " +
                    "WHERE p.nombre LIKE '%" + nombre + "%' " +
                    "AND p.apellido LIKE '%" + apellido + "%' " +
                    "ORDER BY apellido, nombre", sqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona persona = new Persona();
                    persona.ID = (int)drPersonas["id_persona"];
                    persona.Nombre = (string)drPersonas["nombre"];
                    persona.Apellido = (string)drPersonas["apellido"];
                    persona.Direccion = (string)drPersonas["direccion"];
                    persona.Email = (string)drPersonas["email"];
                    persona.Telefono = (string)drPersonas["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    persona.NacimientoString = persona.FechaNacimiento.ToShortDateString();
                    persona.Legajo = (int)drPersonas["legajo"];
                    persona.TipoPersona = (int)drPersonas["tipo_persona"];
                    persona.IDPlan = (int)drPersonas["id_plan"];
                    persona.DescPlan = (string)drPersonas["desc_plan"];
                    persona.DescPlan += " - ";
                    persona.DescPlan += (string)drPersonas["desc_especialidad"];
                    personas.Add(persona);  
                }

                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al filtrar la lista de personas", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }
    }
}
