using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace negocio
{
    public class usuarioNegocio
    {
        public bool Loguin (users usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearCosulta("select Id,email,nombre,apellido,pass,urlImagenPerfil,admin from USERS where email=@Email and pass=@Pass");
                datos.setearParametros("@Email", usuario.Email);
                datos.setearParametros("@Pass", usuario.Pass);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Email = datos.Lector["email"].ToString();
                    usuario.Nombre = datos.Lector["nombre"].ToString();
                    usuario.Apellido = datos.Lector["apellido"].ToString();

                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                    {
                      usuario.UrlImagenPerfil = datos.Lector["urlImagenPerfil"].ToString();
                       
                    }

                    usuario.Admin = (bool)datos.Lector["admin"];
                    usuario.TU = (bool)(datos.Lector["admin"]) ? TipoUsuario.admin : TipoUsuario.normal;

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }

        }

        public int AltaUsuarioRegistro (users alta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsultaSP ("AltaUsuario");
                datos.setearParametros("@Email", alta.Email);
                datos.setearParametros("@Pass", alta.Pass);
                datos.setearParametros("@Nombre", alta.Nombre);
                datos.setearParametros("@Apellido", alta.Apellido);
                             

                //Metodo Scala para que devuelva el id
                return datos.ejecutarAccionScalar();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }
        }


        public void ActualizarDatoMail (string mail,int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsultaSP("UpdateMail");
                datos.setearParametros("@id", id);
                datos.setearParametros("@Mail", mail);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }

        }

        public bool VerificarPass (string Pass, int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsultaSP("VerificarPass");
                datos.setearParametros("@Pass", Pass);
                datos.setearParametros("@Id", Id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }
        }

        // Actualizar Pass
        public void ActualizarDatoPass(string pass, int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsultaSP("UpdatePass");
                datos.setearParametros("@Id", id);
                datos.setearParametros("@Pass", pass);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }

        }

        //Actualizar Nombre
        public void ActualizarDatoNombre(string nombre, int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsultaSP("UpdateNombre");
                datos.setearParametros("@Id", id);
                datos.setearParametros("@Nombre", nombre);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }

        }

        //Actualizar Apellido
        public void ActualizarDatoApellido(string apellido, int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsultaSP("UpdateApellido");
                datos.setearParametros("@Id", id);
                datos.setearParametros("@Apellido", apellido);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }

        }



        // VALIDACION DE EXISTENCIA DE MAIL EN LA BASE
        public bool VerificacionMail(string mail)
        {
                AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsultaSP ("RegistroMail");
                datos.setearParametros("@Email", mail);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }
        }

        public void EliminarCuenta(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsultaSP("EliminarCuenta");
                datos.setearParametros("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }
        }

        public void UpdateImg(users usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsultaSP("UpdateImg");
                datos.setearParametros("@Id", usuario.Id);
                datos.setearParametros("@urlimagenPerfil",usuario.UrlImagenPerfil);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }
        }

        public bool VerificarCoincidenciaStrings(string p1, string p2)
        {
            if (Regex.IsMatch(p1, p2))
            {
                return true;
            }

            return false;
        }

    }
}
