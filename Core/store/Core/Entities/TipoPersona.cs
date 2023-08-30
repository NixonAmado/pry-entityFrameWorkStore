namespace Core.Entities;

public class TipoPersona: BaseEntity
{
    public int IdTPersona { get; set; }
    public string ? Descripcion { get; set;}
    public ICollection<Persona> Personas { get; set; }

}