namespace MvcCoreHospitalesBackFront.Models
{
    public class Hospital
    {
        //NO HACE FALTA MAPEAR TODAS, SOLO LAS QUE SE NECESITE  
        public int IdHospital { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Camas { get; set; }
    }
}
