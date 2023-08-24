namespace Core.Entities;

public class Producto
{
    public int Id {get;set;}
    public int CodInterno {get;set;}
    public string ? Nombre {get;set;}
    public int StockMin {get;set;}
    public int StockMax {get;set;}
    public int Stock {get;set;}
    public decimal ValVenta {get;set;}
    public DateTime FechaCreacion {get;set;}
    public ICollection<ProductoPersona> ? ProductosPersonas{get;set;}
    public ICollection<Persona> ? Personas{get;set;} = new HashSet<Persona>();

}
