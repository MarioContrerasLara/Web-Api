using Microsoft.VisualBasic;

namespace Web2.Models
{
    public class Productos
    {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripción { get; set; }
    public DateAndTime FechaEntrada { get; set; }
    //public DateFormat FechaEntrada { get; set; }
    public int Cantidad { get; set; }
    }
}
