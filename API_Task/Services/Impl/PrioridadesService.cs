using API_Task.DbContextTask.Impl;
using API_Task.DbContextTask.Interface;
using API_Task.Services.Interface;
using Azure.Core;
using CrossCutting.DTO;
using CrossCutting.Models;
using System.Net;

namespace API_Task.Services.Impl
{
    public class PrioridadesService : IPrioridadesService
    {
        public readonly IPrioridadContext _prioridadContext;

        public PrioridadesService(IPrioridadContext prioridadContext)
        {
            _prioridadContext = prioridadContext;
        }

        public async Task<StatusResponse<IEnumerable<Prioridad>>> ListaPrioridad()
        {
            try
            {
                var result = await _prioridadContext.ListaPrioridad();



                return new StatusResponse<IEnumerable<Prioridad>>(new List<Prioridad>())
                {
                    Success = true,
                    StatusCode = 200,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new StatusResponse<IEnumerable<Prioridad>>(null)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Ocurrio un error al listar las tareas.",
                    Success = false
                };
            }
        }
    }
}
