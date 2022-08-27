using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
        public UsuarioLogic UsuarioNegocio
        {
            get; set;
        }
        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }
        public void Menu()
        {
            int op = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1- Listado general");
                Console.WriteLine("2- Consulta");
                Console.WriteLine("3- Agregar");
                Console.WriteLine("4- Modificar");
                Console.WriteLine("5- Eliminar");
                Console.WriteLine("6- SALIR");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        {
                            ListadoGeneral();
                            break;
                        }
                    case 2:
                        {
                            Consultar();
                            break;
                        }
                    case 3:
                        {
                            Agregar();
                            break;
                        }
                    case 4:
                        {
                            Modificar();
                            break;
                        }
                    case 5:
                        {
                            Eliminar();
                            break;
                        }
                    case 6:
                        {
                            Environment.Exit(0);
                            break;
                        }

                }
            } while(op != 6);
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usuario in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usuario);
                Console.WriteLine("\nPresione una tecla para ver otro usuario. ");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                Console.Clear();
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException e)
            {
                Console.Clear();
                Console.WriteLine("La ID ingresada debe ser un numero entero.");
            }
            catch (NullReferenceException e)
            {
                Console.Clear();
                Console.WriteLine("La ID ingresada no corresponde con ningun usuario.");
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);     
            }
            finally {
                Console.WriteLine("\n\nPresione una tecla para continuar.");
                Console.ReadKey();
            }
        }
        public void Agregar()
        {
            Console.Clear();
            Usuario usuario = new Usuario();
            Console.Write("\nIngrese su nombre de usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("\nIngrese una clave: ");
            usuario.Clave = Console.ReadLine();
            Console.Write("\nIngrese su e-mail: ");
            usuario.Email = Console.ReadLine();
            Console.Write("\nIngrese la habilitación del usuario (1-Sí / Otro- No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.Clear();
            Console.WriteLine("ID {0}", usuario.ID);
            Console.ReadKey();
        }
        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.Write("\nIngrese un nuevo nombre de usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("\nIngrese una nueva clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("\nIngrese un nuevo e-mail: ");
                usuario.Email = Console.ReadLine();
                Console.Write("\nIngrese la habilitación del usuario (1-Sí / Otro- No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
                Console.Clear();

            }
            catch (FormatException e)
            {
                Console.Clear();
                Console.WriteLine("La ID ingresada debe ser un número entero. ");
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\n\nPresione una tecla para continuar.");
                Console.ReadKey();
            }
        }
        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException e)
            {
                Console.Clear();
                Console.WriteLine("La ID ingresada debe ser un número entero. ");
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\n\nPresione una tecla para continuar.");
                Console.ReadKey();
            }
        }
        public void MostrarDatos(Usuario usuario)
        {
            Console.WriteLine("---- Usuario ID: " + usuario.ID + " ----");
            Console.WriteLine("Nombre de usuario: " + usuario.NombreUsuario);
            Console.WriteLine("Clave: " + usuario.Clave);
            Console.WriteLine("Email: " + usuario.Email);
            Console.WriteLine("Habilitado: " + usuario.Habilitado, "\n\n");
        }

    }
}
