namespace Core.Entities;

public class Persona
{
    public int Id { get; set;}
    public string? IdPersona { get; set;}
    public string? NombrePersona { get; set;}
    public DateOnly FechaNacimiento { get; set;}
    public int IdTipoPersonaFk { get; set;}
    public TipoPersona ? TipoPersona  { get; set; }
    public String ?  IdRegionFk {get; set;}  
    public Region? Region { get; set; }
    public ICollection<ProductoPersona> ? ProductosPersonas{get;set;}
    public ICollection<Producto> ? Productos{get;set;} = new HashSet<Producto>();

}