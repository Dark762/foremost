using API_Task.DbContextTask.Interface;
using API_Task.Services.Interface;
using Azure.Core;
using CrossCutting.DTO;
using CrossCutting.DTO.Usuario;
using CrossCutting.Models;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;

namespace API_Task.Services.Impl
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioContext _usuarioContext;

        public UsuarioService(IUsuarioContext usuarioContext)
        {
            _usuarioContext = usuarioContext;
        }

        public async Task<StatusResponse> ActualizarUsuario(UsuarioUpdateDTO request)
        {
            try
            {
                var result = await _usuarioContext.ActualizarUsuario(request);


                if (!result)
                {
                    return new StatusResponse()
                    {
                        Success = false,
                        Message = "Ocurrio un problema al actualizar el usuario",
                        StatusCode = 412
                    };
                }

                return new StatusResponse()
                {
                    Success = true,
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new StatusResponse()
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Ocurrio un error al actualizar el usuario",
                    Success = false
                };
            }
        }

        public async Task<StatusResponse> BorrarUsuario(UsuarioFilterDTO request)
        {
            try
            {
                var result = await _usuarioContext.BorrarUsuario(request);


                if (!result)
                {
                    return new StatusResponse()
                    {
                        Success = false,
                        Message = "Ocurrio un problema al botrar el usuario",
                        StatusCode = 412
                    };
                }

                return new StatusResponse()
                {
                    Success = true,
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new StatusResponse()
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Ocurrio un error al borrar el usuario",
                    Success = false
                };
            }
        }

        public async Task<StatusResponse> CrearUsuario(UsuarioCreateDTO request)
        {
            try
            {
                var result = await _usuarioContext.CrearUsuario(request);


                if (!result) {
                    return new StatusResponse()
                    {
                        Success = false,
                        Message = "Ocurrio un problema al crear el usuario",
                        StatusCode = 412
                    };
                }

                return new StatusResponse() {
                    Success = true,
                    StatusCode = 200
                };
            }
            catch(Exception ex)
            {
                return new StatusResponse()
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Ocurrio un error al crear el usuario",
                    Success = false
                };
            }

        }

        public async Task<StatusResponse<IEnumerable<Usuario>>> ListaUsuarios()
        {
            try
            {
                var result = await _usuarioContext.ListaUsuarios();


               
                return new StatusResponse<IEnumerable<Usuario>>(new List<Usuario>())
                {
                    Success = true,
                    StatusCode = 200,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new StatusResponse<IEnumerable<Usuario>>(null)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Ocurrio un error al listar los usuarios.",
                    Success = false
                };
            }
        }
    }
}
