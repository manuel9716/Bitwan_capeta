using CRUD.DbContexts;
using CRUD.Dto;
using CRUD.Dto.Inputs;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Data.Common;
using System.Linq.Expressions;

namespace CRUD.Repositories
{
    public class UsuarioRespositories : IUsuarioRepositories
    {
        private readonly CrudDbContext _context;

        public UsuarioRespositories(CrudDbContext context)
        {
            _context = context;
        }

        #region Usuario
        public async Task<UsuarioModels> GetUsuarios()
        {
            UsuarioModels usuario = new UsuarioModels();

            using (var db = _context )
            {
                var usua = await (from a in db.Usuarios
                                  select new UsuarioModels.Usuario
                                  {
                                      UsuarioId = a.Id,
                                      Nombre = a.Nombre,
                                      Apellido = a.Apellido,
                                      Email = a.Email,
                                      Telefono = a.Telefono

                                  }).ToListAsync();
                usuario.Usuarios = usua;
            }
            return usuario;
        }

        public ResponseModels InsertUsuario(InputUsuarioModels Dta)
        {
            var Responseusuarios = new ResponseModels();

            Responseusuarios.IsSuccess = false;

            try
            {
                using (var db = _context)
                {
                    using (var dbTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var insertusuario = new Usuario();
                            insertusuario.Nombre = Dta.Nombre;
                            insertusuario.Apellido = Dta.Apellido;
                            insertusuario.Email = Dta.Email;
                            insertusuario.Telefono = Dta.Telefono;
                            
                            db.Entry(insertusuario).State = EntityState.Added;
                            db.SaveChanges();
                            //throw new InvalidOperationException("Logfile cannot be read-only");
                            dbTransaction.Commit();
                            Responseusuarios.IsSuccess = true;
                            Responseusuarios.Message = "Registro insertado correctamente en la base de datos";
                            
                        }
                        catch (Exception Ex)
                        {
                            dbTransaction.Rollback();
                            Responseusuarios.Message = "Se genero un error al insertar el registro en la base de datos:" + Ex;
                            
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Responseusuarios.Message = "Se genero un error al inserta el registro en la base de datos:" + Ex;
            }
            return Responseusuarios;
        }

        public ResponseModels DeleteUsuarios(int Id)
        {
            var ResponseDele = new ResponseModels();

            ResponseDele.IsSuccess = false;

            try
            {
                using (var db = _context)
                {
                   
                        using (var dbTransaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                                var UsuarioDate = db.Usuarios.Where(x => x.Id == Id).FirstOrDefault();
                                if (UsuarioDate != null)
                                {
                                    db.Usuarios.Remove(UsuarioDate);
                                    db.SaveChanges();

                                    dbTransaction.Commit();
                                    ResponseDele.IsSuccess = true;
                                    ResponseDele.Message = "El usuario fue eliminado correctamente";
                                }
                                else
                                {
                                    ResponseDele.Message = "Usuario no encontrado en la base de datos";
                                }
                                
                            }
                            catch (Exception Ex)
                            {
                                dbTransaction.Rollback();
                                ResponseDele.Message = "Ocurrio un error en la base de datos, detalle: " + Ex.Message + "_" + Ex.InnerException + "_" + Ex.StackTrace;
                            }
                        }
                    }
                
            }
            catch (Exception Ex)
            {
                ResponseDele.Message = "Ocurrio un error en la base de datos, detalle: " + Ex.Message + "_" + Ex.InnerException + "_" + Ex.StackTrace;

            }
            return ResponseDele;
        }

        public ResponseModels UpdateUsuarios (InputUsuarioModels Dta)
        {
            var Responseupd = new ResponseModels();
            Responseupd.IsSuccess = false;
            try
            {
                using (var db = _context)
                {
                    using (var dbTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var updUsuario = db.Usuarios.Where(x => x.Id == Dta.UsuarioId).FirstOrDefault();
                            if (updUsuario != null)
                            {
                                updUsuario.Nombre = Dta.Nombre;
                                updUsuario.Apellido = Dta.Apellido ;
                                updUsuario.Telefono = Dta.Telefono;
                                updUsuario.Email = Dta.Email;
                                db.Entry(updUsuario).Property(x => x.Nombre).IsModified = true;
                                db.Entry(updUsuario).Property(x => x.Apellido).IsModified = true;
                                db.Entry(updUsuario).Property(x => x.Telefono).IsModified = true;
                                db.Entry(updUsuario).Property(x => x.Email).IsModified = true;
                                db.SaveChanges();
                                dbTransaction.Commit();
                                Responseupd.IsSuccess = true;
                                Responseupd.Message = "EL usuario fue editado correctamente";

                            }
                            else
                            {
                                Responseupd.Message = "Usuario no encontrado en la base de datos";
                            }
                        }
                        catch (Exception Ex)
                        {
                            dbTransaction.Rollback();
                            Responseupd.Message = "Ocurrio un error en la base de datos, detalle: " + Ex.Message + "_" + Ex.InnerException + "_" + Ex.StackTrace;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Responseupd.Message = "Ocurrio un error en la base de datos, detalle: " + Ex.Message + "_" + Ex.InnerException + "_" + Ex.StackTrace;
            }
            return Responseupd;
        }
        #endregion
    }
}
