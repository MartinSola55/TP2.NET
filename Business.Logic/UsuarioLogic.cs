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
        public bool ValidaLogin(string nombre, string clave)
        {
            try
            {
                if (UsuarioData.ValidaLogin(nombre, clave))
                {
                    return true;
                }
            } catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
            return false;
        }
    }
}
