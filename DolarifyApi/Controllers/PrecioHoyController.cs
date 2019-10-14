using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using DolarifyApi.Payloads;
using DolarifyApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DolarifyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrecioHoyController : ControllerBase
    {
        private CotizacionHoyService cotizacionHoyService = new CotizacionHoyService();

        // GET: api/<controller>
        [HttpGet]
        public async Task<DolarDelDiaPayload[]> Get()
        {
            var cotizacion = await cotizacionHoyService.GetOficialMayorista<DolarDelDiaPayload[]>();
            return cotizacion;
        }
    }
}
