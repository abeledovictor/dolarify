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
        public async Task<DolarDelDiaPayload[]> Get(string from, string to)
        {
            DolarDelDiaPayload[] cotizacion;
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to)) {
            cotizacion = await cotizacionHoyService.GetOficialMayorista<DolarDelDiaPayload[]>();
            } else {
                cotizacion = await cotizacionHoyService.GetOficialMayoristaByRange(from, to);
            }

            return cotizacion;
        }

        [HttpGet("{date}")]
        public async Task<DolarDelDiaPayload> Get(string date)
        {
            DolarDelDiaPayload cotizacion = await cotizacionHoyService.GetOficialMayoristaByDate(date);
            return cotizacion;
        }
    }
}
