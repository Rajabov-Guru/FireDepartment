using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDepartment.Model
{
    //Расчет
    public class Guard
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Senior { get; set; }
        [Required]
        public int Id_Complect { get; set; }
        public virtual Travel Travel { get; set; }
        public Guard() 
        {

        }
    }
}
