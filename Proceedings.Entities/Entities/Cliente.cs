using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proceedings.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            this.Expedientes = new HashSet<Expediente>();
        }

        //[Key]
        [Column("ClienteId")]
        [Required(ErrorMessage = "El ID es obligatorio")]
        [Display(Name = "Ident.:")]
        public Int32 ClienteId { get; set; }

        [Column("DNI", TypeName = "nvarchar(50)")]
        [MaxLength(50), MinLength(0)]
        [Display(Name = "DNI:")]
        public string? DNI { get; set; }

        [Column("Nombre", TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100), MinLength(1)]
        [Display(Name = "Nombre:")]
        public string? Nombre { get; set; }

        [Column("Apellidos", TypeName = "nvarchar(100)")]
        [MaxLength(100), MinLength(0)]
        [Display(Name = "Apellidos:")]
        public string? Apellidos { get; set; }

        //***************************************************************************************************
        //***************************************************************************************************
        //***************************************************************************************************
        //***************************************************************************************************

        [Column("Domicilio", TypeName = "nvarchar(100)")]
        [MaxLength(100), MinLength(0)]
        [Display(Name = "Domicilio:")]
        public string? Domicilio { get; set; }

        [Column("CP", TypeName = "nvarchar(5)")]
        [MaxLength(5), MinLength(0)]
        [Display(Name = "CP:")]
        public string? CP { get; set; }

        [Column("Poblacion", TypeName = "nvarchar(100)")]
        [MaxLength(100), MinLength(0)]
        [Display(Name = "Poblacion:")]
        public string? Poblacion { get; set; }

        [Column("Provincia", TypeName = "nvarchar(100)")]
        [MaxLength(100), MinLength(0)]
        [Display(Name = "Provincia:")]
        public string? Provincia { get; set; }

        [Column("Nacionalidad", TypeName = "nvarchar(100)")]
        [MaxLength(100), MinLength(0)]
        [Display(Name = "Nacionalidad:")]
        public string? Nacionalidad { get; set; }

        [Column("Pais", TypeName = "nvarchar(50)")]
        [MaxLength(50), MinLength(0)]
        [Display(Name = "Pais:")]
        public string? Pais { get; set; }

        [MaxLength(100), MinLength(0)]
        public string? Bandera_img_Path { get; set; }

        [Column("Nacionalidad_img", TypeName = "image")]
        public byte[]? Nacionalidad_img { get; set; }

        [Column("Telefono", TypeName = "nvarchar(100)")]
        [MaxLength(100), MinLength(0)]
        [Display(Name = "Teléfono:")]
        public string? Telefono { get; set; }

        [Column("Movil", TypeName = "nvarchar(100)")]
        [MaxLength(100), MinLength(0)]
        [Display(Name = "Móvil:")]
        public string? Movil { get; set; }

        [Column("Email", TypeName = "nvarchar(100)")]
        [MaxLength(100), MinLength(0)]
        [Display(Name = "email:")]
        public string? Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Fecha Alta:")]
        public DateTime FechaAlta { get; set; }


        [Display(Name = "Usuario:")]
        [StringLength(256, MinimumLength = 6)]
        public string? UserAccess { get; set; }

        //******* RELACIÓN CON: Expediente   ************************
        public virtual ICollection<Expediente> Expedientes { get; set; }




    }
}
