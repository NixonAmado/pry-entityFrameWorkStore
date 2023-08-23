using System.Drawing;

namespace Core.Entities;

public class ProductoPersona
{
    public int IdPersonaFk { get; set; }
    public Persona? Persona{ get; set; }
    public int IdProductoFk { get; set; }
    public Color? Color { get; set; }
    

}