using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Infrastructure.EF.PersistenceModel
{
    [Table("categoriaMenu")]
    internal class CategoriaMenuPersistenceModel
    {
        [Key]
        [Column("categoriaMenuItemId")]
        public Guid Id { get; set; }

        [Column("nombre")]
        [StringLength(250)]
        [Required]
        public string Nombre { get; set; }

        [Column("activa")]
        [Required]
        public bool Activa { get; set; }
    }
}
