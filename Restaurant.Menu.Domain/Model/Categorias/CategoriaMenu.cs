using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Domain.Model.Categoria;

public class CategoriaMenu : AggregateRoot
{
    public string Nombre { get; set; }
    public bool Activa { get; set; }    

    public CategoriaMenu(string nombre)
    {
        CheckRule(new StringNotNullOrEmptyRule(nombre));
        Nombre = nombre;
        Activa = true;
    }

    public void Editar(string nombre, bool activa)
    {
        CheckRule(new StringNotNullOrEmptyRule(nombre));
        Nombre = nombre;
        Activa = activa;
    }

    private CategoriaMenu() { }
}
