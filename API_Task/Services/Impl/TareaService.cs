using API_Task.DbContextTask.Impl;
using API_Task.DbContextTask.Interface;
using API_Task.Services.Interface;
using CrossCutting.DTO;
using CrossCutting.DTO.Tarea;
using CrossCutting.DTO.Usuario;
using CrossCutting.Models;
using System.Net;

namespace API_Task.Services.Impl
{



    public class TareaService : ITareaService
    {
        public readonly ITareaContext _tareaContext;

        public TareaService(ITareaContext tareaContext) { 
            _tareaContext = tareaContext;
        }

        public async Task<StatusResponse> ActualizarTarea(TareaUpdateDTO request)
        {
            try
            {
                var result = await _tareaContext.ActualizarTarea(request);


                if (!result)
                {
                    return new StatusResponse()
                    {
                        Success = false,
                        Message = "Ocurrio un problema al actualizar la tarea",
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
                    Message = "Ocurrio un error al actualizar la tarea",
                    Success = false
                };
            }
        }

        public async Task<StatusResponse> BorrarTarea(TareaFilterDTO request)
        {
            try
            {
                var result = await _tareaContext.BorrarTarea(request);


                if (!result)
                {
                    return new StatusResponse()
                    {
                        Success = false,
                        Message = "Ocurrio un problema al borrar la tarea",
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
                    Message = "Ocurrio un error al borrar la tarea",
                    Success = false
                };
            }
        }

        public async Task<StatusResponse> CrearTarea(TareaCreateDTO request)
        {
            try
            {
                var result = await _tareaContext.CrearTarea(request);


                if (!result)
                {
                    return new StatusResponse()
                    {
                        Success = false,
                        Message = "Ocurrio un problema al crear la tarea",
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
                    Message = "Ocurrio un error al crear la tarea",
                    Success = false
                };
            }
        }



        public async Task<StatusResponse<IEnumerable<Tarea>>> ListaTareaPorUsuario(TareaFilterDTO request)
        {
            try
            {
                var result = await _tareaContext.ListaTareaPorUsuario(request);



                return new StatusResponse<IEnumerable<Tarea>>(new List<Tarea>())
                {
                    Success = true,
                    StatusCode = 200,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new StatusResponse<IEnumerable<Tarea>>(null)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Ocurrio un error al listar las tareas.",
                    Success = false
                };
            }
        }

        public async Task<StatusResponse<Tarea>> ObtenerTarea(TareaFilterDTO request)
        {
            try
            {
                var result = await _tareaContext.ObtenerTarea(request);



                return new StatusResponse<Tarea>(new Tarea())
                {
                    Success = true,
                    StatusCode = 200,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new StatusResponse<Tarea>(null)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Ocurrio un error al listar las tareas.",
                    Success = false
                };
            }
        }
    }
}
