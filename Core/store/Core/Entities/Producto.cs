namespace Core.Entities;

public class Producto
{
    public int Id {get;set;}
    public int CodInterno {get;set;}
    public string ? Nombre {get;set;}
    public int StackMin {get;set;}
    public int StackMax {get;set;}
    public int Stack {get;set;}
    public decimal ValVenta {get;set;}
    public DateTime FechaCreacion {get;set;}
    public ICollection<ProductoPersona> ? ProductosPersonas{get;set;}
    public ICollection<Persona> ? Personas{get;set;} = new HashSet<Persona>();

}