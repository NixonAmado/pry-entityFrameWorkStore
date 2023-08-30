using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
//patron de diseño singalton
//una instancia por clase
//enpoint
namespace Core.Interfaces;

public interface IPais : IGenericRepoA<Pais>
{
    //Task GetByIdAsync(int id);
    //Task GetByIdAsync(int id);
}
