using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proceedings.Entities
{
    public class Expediente
    {
        [Key]
        [Column("ExpedienteID")]
        [Required(ErrorMessage = "El identificador de expediente es obligatorio.")]
        [Display(Name = "Exp. ID:")]
        public Int32 ExpedienteID { get; set; }

        [Column("AnyoExpediente")]
        [Required(ErrorMessage = "El año es obligatorio")]
        [Display(Name = "Año:")]
        public Int32 AnyoExpediente { get; set; }

        [Column("NumeroExpediente")]
        [Required(ErrorMessage = "El número de Expediente es obligatorio")]
        [Display(Name = "Núm. Exp.:")]
        public string? NumeroExpediente { get; set; }

        //********************************************************************************************************

        [Column("DNI", TypeName = "nvarchar(50)")]
        [MaxLength(50), MinLength(0)]
        [Display(Name = "DNI:")]
        public string? DNI { get; set; }

        [Column("Nombre", TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "El nombre del Cliente es obligatorio")]
        [MaxLength(100), MinLength(1)]
        [Display(Name = "Nombre:")]
        public string? Nombre { get; set; }

        [Column("Apellidos", TypeName = "nvarchar(100)")]
        [MaxLength(100), MinLength(0)]
        [Display(Name = "Apellidos:")]
        public string? Apellidos { get; set; }

        [Column("Descripcion", TypeName = "nvarchar(200)")]
        [MaxLength(200), MinLength(0)]
        [Display(Name = "Descripción:")]
        public string? Descripcion { get; set; }

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
        [Display(Name = "Población:")]
        public string? Poblacion { get; set; }

        [Column("Provincia", TypeName = "nvarchar(100)")]
        [MaxLength(100), MinLength(0)]
        [Display(Name = "Provincia:")]
        public string? Provincia { get; set; }

        [Column("Nacionalidad", TypeName = "nvarchar(100)")]
        [MaxLength(100), MinLength(0)]
        [Display(Name = "Nacionalidad:")]
        public string? Nacionalidad { get; set; }

        [Column("Pais", TypeName = "nvarchar(100)")]
        [MaxLength(100), MinLength(0)]
        [Display(Name = "País:")]
        public string? Pais { get; set; }

        [Display(Name = "País:")]
        [MaxLength(100), MinLength(0)]
        public string? Bandera_img_Path { get; set; }

        [Column("Bandera_img", TypeName = "image")]
        [Display(Name = "País:")]
        public byte[]? Bandera_img { get; set; }

        //public byte[] Bandera_img_Backup { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Fecha Alta:")]
        public DateTime FechaAlta { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Fecha Cierre:")]
        public DateTime? FechaCierre { get; set; }

        [Column("Telefono", TypeName = "nvarchar(20)")]
        [MaxLength(20), MinLength(0)]
        [Display(Name = "Teléfono:")]
        public string? Telefono { get; set; }

        [Column("Movil", TypeName = "nvarchar(20)")]
        [MaxLength(20), MinLength(0)]
        [Display(Name = "Móvil:")]
        public string? Movil { get; set; }

        [Column("Fax", TypeName = "nvarchar(20)")]
        [MaxLength(20), MinLength(0)]
        [Display(Name = "Fax:")]
        public string? Fax { get; set; }

        [Column("Email", TypeName = "nvarchar(100)")]
        [MaxLength(100), MinLength(0)]
        [Display(Name = "email:")]
        public string? Email { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        [DataType(DataType.Currency)]
        [Display(Name = "Importe:")]
        public decimal Importe { get; set; }

        [Column("ImporteBase", TypeName = "decimal(18, 4)")]
        [Display(Name = "Importe Base:")]
        public decimal ImporteBase { get; set; }

        [Column("ImporteIVA", TypeName = "decimal(18, 4)")]
        [Display(Name = "Importe IVA Facturación:")]
        public decimal ImporteIVA { get; set; }

        [Column("ImporteRET", TypeName = "decimal(18, 4)")]
        [Display(Name = "Importe RET:")]
        public decimal ImporteRET { get; set; }

        [Column("ImporteTotal", TypeName = "decimal(18,4)")]
        [Display(Name = "Importe Total:")]
        public decimal ImporteTotal { get; set; }

        [Display(Name = "Usuario:")]
        [StringLength(256, MinimumLength = 6)]
        public string? UserAccess { get; set; }

        //******* RELACIÓN CON: Departamento   ********************
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

        //******* RELACIÓN CON: Cliente   ********************
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
