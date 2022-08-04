using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios " +
                    "ORDER BY apellido, nombre, nombre_usuario", sqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usuarios.Add(usr);
                }

                drUsuarios.Close();
            } catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al recuperar la lista de usuarios", Ex);
                throw exceptionManejada;

            } finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }
        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios WHERE id_usuario = @id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                }
                drUsuarios.Close();
            } catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("El usuario seleccionado no existe", Ex);
                throw exceptionManejada;
            } catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al recuperar los datos del usuario", Ex);
                throw exceptionManejada;
            } finally
            {
                this.CloseConnection();
            }
            return usr;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE usuarios WHERE id_usuario = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            } catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("El usuario seleccionado no existe", Ex);
                throw exceptionManejada;
            } catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("No se pudo eliminar el usuario", Ex);
                throw exceptionManejada;
            } finally
            {
                this.CloseConnection();
            }
        }
        public void Update (Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave," +
                    " habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email WHERE id_usuario = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.ExecuteNonQuery();
            } catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("El usuario seleccionado no existe", Ex);
                throw exceptionManejada;
            } catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al modificar los datos del usuario", Ex);
                throw exceptionManejada;
            } finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO usuarios (nombre_usuario, clave, habilitado, nombre, apellido, email)" +
                    "VALUES (@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email) SELECT @@identity", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            } catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al crear el usuario", Ex);
                throw exceptionManejada;
            } finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }
        public bool ValidaLogin(string nombre, string clave)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios " +
                    "WHERE nombre_usuario = @nombre_usario AND clave = @clave", sqlConn);
                cmdUsuarios.Parameters.Add("@nombre_usario", SqlDbType.VarChar, 50).Value = nombre;
                cmdUsuarios.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = clave;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    drUsuarios.Close();
                    return true;
                }
            } catch (SqlException Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error con la base de datos", Ex);
                throw exceptionManejada;
            } catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al recuperar los datos del usuario", Ex);
                throw exceptionManejada;
            } finally
            {
                this.CloseConnection();
            }
            return false;
        }
        public List<Usuario> FiltraUsuarios(string nombre, string apellido, string usr, string mail)
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand(
                    "SELECT * FROM usuarios " +
                    "WHERE nombre_usuario LIKE '%" + usr + "%' " +
                    "AND nombre LIKE '%" + nombre + "%'" +
                    "AND apellido LIKE '%" + apellido+ "%' " +
                    "AND email LIKE '%" + mail + "%' ", sqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.ID = (int)drUsuarios["id_usuario"];
                    usuario.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usuario.Clave = (string)drUsuarios["clave"];
                    usuario.Habilitado = (bool)drUsuarios["habilitado"];
                    usuario.Nombre = (string)drUsuarios["nombre"];
                    usuario.Apellido = (string)drUsuarios["apellido"];
                    usuario.Email = (string)drUsuarios["email"];
                    usuarios.Add(usuario);
                }

                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception exceptionManejada = new Exception("Hubo un error al filtrar la lista de usuarios", Ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }
    }
}
