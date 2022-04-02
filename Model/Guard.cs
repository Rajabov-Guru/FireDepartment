
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FireDepartment.Model
{
    //Расчет
    public class Guard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ComplectId { get; set; }


        [Required]
        //начальник караула
        public string Senior { get; set; }

        [ForeignKey("ComplectId")]
        public virtual Complect Complect { get; set; }

        public virtual ICollection<Travel> Travels { get; set; }

        public Guard() 
        {

        }
    }
}
