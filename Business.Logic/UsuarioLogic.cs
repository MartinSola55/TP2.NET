using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        public UsuarioAdapter UsuarioData
        {
            get; set;
        }
        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }
        public Usuario GetOne(int id)
        {
            try
            {
                return UsuarioData.GetOne(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public int GetTipoUsuario(string nombre, string clave)
        {
            try
            {
                return UsuarioData.GetTipoUsuario(nombre, clave);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public string GetNombreApellido(string nombre, string clave)
        {
            try
            {
                return UsuarioData.GetNombreApellido(nombre, clave);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public int GetIDPersona(string nombre, string clave)
        {
            try
            {
                return UsuarioData.GetIDPersona(nombre, clave);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public List<Usuario> GetAll()
        {
            try
            {
                return UsuarioData.GetAll();
            } catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public void Save(Usuario usuario)
        {
            try
            {
                UsuarioData.Save(usuario);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public void Create(Usuario usuario)
        {
            try
            {
                UsuarioData.Create(usuario);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public void Delete(int id)
        {
            try
            {
                UsuarioData.Delete(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public bool ValidaLogin(string user, string pass)
        {
            try
            {
                if (UsuarioData.ValidaLogin(user, pass))
                {
                    return true;
                }
            } catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
            return false;
        }
        public List<Usuario> FiltraUsuarios(string usr, string mail)
        {
            try
            {
                return UsuarioData.FiltraUsuarios(usr, mail);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public bool EsRepetido(string usuario)
        {
            try
            {
                return UsuarioData.GetRepetido(usuario);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public bool EsRepetido(Usuario usuario)
        {
            try
            {
                return UsuarioData.GetRepetido(usuario);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
    }
}
