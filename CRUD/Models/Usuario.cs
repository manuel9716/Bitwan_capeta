using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    [Table (name:"Usuarios")]
    public class Usuario
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name:"Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName= "VARCHAR")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string Apellido { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string Email { get; set; }

        [MaxLength(11)]
        public int Telefono { get; set; }

    }
}
