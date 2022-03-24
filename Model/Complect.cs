using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDepartment.Model
{
    //Комплект
    public class Complect
    {
        [Key]
        public int ID { get; set; }

        public string EquipmentList { get; set; }
        public Complect() 
        {

        }
        
    }
}
