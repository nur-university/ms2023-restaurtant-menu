using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Infrastructure.EF.PersistenceModel
{

    [Table("menuItem")]
    internal class MenuItemPersistenceModel
    {
        [Key]
        [Column("menuItemId")]
        public Guid Id { get; set; }
        
        [Column("nombre", TypeName = "nvarchar(250)")]
        [Required]
        public string Nombre { get; set; }
        
        [Column("descripcion", TypeName = "nvarchar(max)")]
        [Required]
        public string Descripcion { get; set; }

        [Column("activo")]
        [Required]
        public bool Activo { get; set; }

        [Column("precio", TypeName = "decimal(12,2)")]
        [Required]
        public decimal Precio { get; set; }
        
        [Column("tipo", TypeName = "nvarchar(50)")]
        [Required]
        public string Tipo { get; set; }

        [Column("categoriaMenuId")]
        [Required]
        public Guid CategoriaMenuId { get; set; }        
        
        public CategoriaMenuPersistenceModel CategoriaMenu { get; set; }
    }
}
