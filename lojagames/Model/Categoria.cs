using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace lojagames.Model
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(100)]
        public string Tipo { get; set; } = string.Empty;

        public virtual Produto? Produto { get; set; } 

    }
}
