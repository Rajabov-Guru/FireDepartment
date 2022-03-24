using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDepartment.Model
{
    //Акт о пожаре
    public class Act
    {
        [Key]
        public int ID { get; set; }

        //причина
        [Required]
        public string Cause { get; set; }

        //условия
        [Required]
        public string Terms { get; set; }

        //спасено людей
        [Required]
        public int RescuedHumans { get; set; }
        //спасено техники
        [Required]
        public int RescuedTechnicks { get; set; }
        //спасено скота
        [Required]
        public int RescuedBeasts { get; set; }
        //спасено мат. ценностей
        [Required]
        public int RescuedMaterialValues { get; set; }

        //Уничтожено зданий
        [Required]
        public int DestoyedBuildings { get; set; }

        //Уничтожено жилых квартир
        [Required]
        public int DestoyedFlats { get; set; }

        //Уничтожено с.х культур
        [Required]
        public int DestoyedAgricultural { get; set; }

        //Уничтожено скота
        [Required]
        public int DestoyedBeasts { get; set; }

        //Уничтожено техники
        [Required]
        public int DestoyedTechnicks { get; set; }

        //Уничтожено поэтажной площади
        [Required]
        public int DestoyedFloorArea { get; set; }


        //Повреждено зданий
        [Required]
        public int DamagedBuildings { get; set; }

        //Повреждено жилых квартир
        [Required]
        public int DamagedFlats { get; set; }

        //Повреждено с.х культур
        [Required]
        public int DamagedAgricultural { get; set; }

        //Повреждено скота
        [Required]
        public int DamagedBeasts { get; set; }

        //Повреждено техники
        [Required]
        public int DamagedTechnicks { get; set; }

        //Повреждено поэтажной площади
        [Required]
        public int DamagedFloorArea { get; set; }

        

        //Травмированы работники
        [Required]
        public int InjuredEmployees { get; set; }

        //Травмированы детей
        [Required]
        public int InjuredChildren { get; set; }

        //Травмированы
        [Required]
        public int Injured { get; set; }

        //Погибло работники
        [Required]
        public int ParishedEmployees { get; set; }

        //Погибло детей
        [Required]
        public int ParishedChildren { get; set; }

        //Погибло
        [Required]
        public int Parished { get; set; }


        //Водоснабжение
        [Required]
        public bool WaterSupply { get; set; }

        //Огнетушащие средства
        [Required]
        public string FireEquipment { get; set; }

        //Наличие пожарной автоматики
        [Required]
        public bool AvailabilityOfFireAutomatic { get; set; }

        //Обстановка
        [Required]
        public string Situation { get; set; }

        //Дата и время локализации
        [Required]
        public DateTime Localization { get; set; }

        //Дата и время ликвидации
        [Required]
        public DateTime Liquidation { get; set; }

        //Дата и время обнаружения
        [Required]
        public DateTime Detection { get; set; }

        //Принадлежность
        [Required]
        public string Belonging { get; set; }




        
        public virtual ICollection<Travel> Travels { get; set; }

        public Act() 
        {

        }


    }
}
