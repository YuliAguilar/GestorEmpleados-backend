using System.ComponentModel.DataAnnotations;

namespace GestorEmpleados.API.Models
{
    public class RespuestaDB
    {
        [Key]
        public int NumError {  get; set; }
        public string Mensaje { get; set; }
    }
}
