using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proceedings.Entities
{
    public class Departamento
    {
        public Departamento()
        {
            //this.UsersApps = new HashSet<Appli>();
            this.Expedientes = new HashSet<Expediente>();
        }

        [Key]
        [Column("DepartamentoId")]
        [Required(ErrorMessage = "El identificador de departamento es obligatorio.")]
        [Display(Name = "Dep. ID:")]
        public int DepartamentoId { get; set; }

        [Column("Departamento", TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "El nombre de departamento es obligatorio")]
        [MaxLength(100), MinLength(1)]
        [Display(Name = "Departamento:")]
        public string? TipoDepartamento { get; set; }

        public string? Descripcion { get; set; }

        public string? Responsable { get; set; }

        //******* RELACIÓN CON: UserApp   ************************
        //public virtual ICollection<UserApp> UsersApps { get; set; }

        //******* RELACIÓN CON: Expediente   ************************
        public virtual ICollection<Expediente> Expedientes { get; set; }

    }
}
