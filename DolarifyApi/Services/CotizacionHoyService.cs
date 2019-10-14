﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace DolarifyApi.Services
{
    public class CotizacionHoyService
    {
        private readonly HttpClient _httpClient;
        private readonly string url = "https://api.estadisticasbcra.com/usd";
        private static readonly string token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2MDI1MDM0MjYsInR5cGUiOiJleHRlcm5hbCIsInVzZXIiOiJhYmVsZWRvdmljdG9yQGdtYWlsLmNvbSJ9.udsDbvGqtANRzLGumD0B806yiX1D4g2MRT1go4k7Xdacnv0If3jH8UBu6z1acttLJg3CceDQtzA998avI2zuKQ";

        public CotizacionHoyService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<T> GetOficialMayorista<T>()
        {
            var response = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseContentRead);
            var data = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(data);
        }
    }
}
