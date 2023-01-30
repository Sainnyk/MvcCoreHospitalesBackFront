using MvcCoreHospitalesBackFront.Models;
using System.Net.Http.Headers;

namespace MvcCoreHospitalesBackFront.Services
{
    public class ServiceApiHospital
    {
        private string UrlApi;
        //TENDREMOS UN OBJETO PARA INDICAR EL TIPO DE PETICION QUE HAREMOS (JSON)
        private MediaTypeWithQualityHeaderValue header;

        public ServiceApiHospital()
        {
            //Las url de apis en los servicios solamente se incluye el sitio web, no la peticion(NO api/hospitales)
            this.UrlApi = "https://apihospitalesazure2023aie.azurewebsites.net/";
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        //TAMBIEN PODEMOS TENER UN CONSTRUCTOR DONDE INDICAMOS QUE EL CONTAINER PROGRAM NOS INDIQUE LA URL
        public ServiceApiHospital(string urlapi)
        {
            this.UrlApi = urlapi;
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        //Los metodos de consumo de apis son asincronos
        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            //UTILIZAMOS EL OBJETO HttpClient PARA PETICION
            using (HttpClient client = new HttpClient())
            {
                //LA PETICION
                string request = "/api/hospitales";
                //AÑADIMOS AL CLIENTE LA DIRECCION BASE DE LA URL DEL API
                client.BaseAddress = new Uri(this.UrlApi);
                //LIMPIAMOS LA CABECERA DE OTRAS PETICIONES- NECESARIO SI HACEMOS PETICIONES EN CASCADA (VARIOS METODOS), AHORA SOLO HAY 1
                client.DefaultRequestHeaders.Clear();
                //AÑADIMOS AL HEADER EL TIPO DE DATOS QUE VAMOS A CONSUMIR
                client.DefaultRequestHeaders.Accept.Add(this.header);
                //REALIZAMOS UNA PETICION ASINCRONA CON EL METODO GET Y NOS DEVOLVERA UNA RESPUESTA DE TIPO HttpResponseMessage
                HttpResponseMessage response = await client.GetAsync(request);
                //COMPROBAMOS SI LA RESPUESTA ES CORRECTA
                if (response.IsSuccessStatusCode)
                {
                    //AQUI TENEMOS LOS DATOS. EN LA PROPIEDAD Content DE LA RESPUESTA VIENEN LOS DATOS EN FORMATO JSON.
                    //DEBEMOS CONVERTIR LOS DATOS A CLASES MEDIANTE UN METODO LLAMADO ReadAsAsync() (la conversion sera automatica si el mapeo es correcto)
                    List<Hospital> hospitales = await response.Content.ReadAsAsync<List<Hospital>>();
                    return hospitales;
                }
                else
                {
                    //SIEMPRE QUE ALGO FALLA DEVOLVEREMOS NULL DESDE EL SERVICIO-> ES UNA NORMA
                    return null;
                }
            }

        }

    }
}
