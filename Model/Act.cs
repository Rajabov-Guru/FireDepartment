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
        public int Id { get; set; }

        //причина
        [Required]
        public string Cause { get; set; }

        //условия
        
        public string Terms { get; set; }

        //спасено людей
        
        public int RescuedHumans { get; set; }
        //спасено техники
        
        public int RescuedTechnicks { get; set; }
        //спасено скота
        
        public int RescuedBeasts { get; set; }
        //спасено мат. ценностей
        
        public double RescuedMaterialValues { get; set; }

        //Уничтожено зданий
       
        public int DestoyedBuildings { get; set; }

        //Уничтожено жилых квартир
        
        public int DestoyedFlats { get; set; }

        //Уничтожено с.х культур
        
        public int DestoyedAgricultural { get; set; }

        //Уничтожено скота
        
        public int DestoyedBeasts { get; set; }

        //Уничтожено техники
        
        public int DestoyedTechnicks { get; set; }

        //Уничтожено поэтажной площади
        
        public int DestoyedFloorArea { get; set; }


        //Повреждено зданий
        
        public int DamagedBuildings { get; set; }

        //Повреждено жилых квартир
        
        public int DamagedFlats { get; set; }

        //Повреждено с.х культур
        
        public int DamagedAgricultural { get; set; }

        //Повреждено скота
        
        public int DamagedBeasts { get; set; }

        //Повреждено техники
       
        public int DamagedTechnicks { get; set; }

        //Повреждено поэтажной площади
        
        public int DamagedFloorArea { get; set; }

        

        //Травмированы работники
        
        public int InjuredEmployees { get; set; }

        //Травмированы детей
        
        public int InjuredChildren { get; set; }

        //Травмированы
        
        public int Injured { get; set; }

        //Погибло работники
        
        public int ParishedEmployees { get; set; }

        //Погибло детей
        
        public int ParishedChildren { get; set; }

        //Погибло
        
        public int Parished { get; set; }


        //Водоснабжение
        
        public bool WaterSupply { get; set; }

        //Огнетушащие средства
        
        public string FireEquipment { get; set; }

        //Наличие пожарной автоматики
        
        public bool AvailabilityOfFireAutomatic { get; set; }

        //Обстановка
        
        public string Situation { get; set; }

        //Дата и время локализации
        
        public DateTime Localization { get; set; }

        //Дата и время ликвидации
        
        public DateTime Liquidation { get; set; }

        //Дата и время обнаружения
        
        public DateTime Detection { get; set; }

        //Принадлежность
        public string Belonging { get; set; }
        public virtual ICollection<Travel> Travels { get; set; }

        public Act() 
        {

        }


    }
}
