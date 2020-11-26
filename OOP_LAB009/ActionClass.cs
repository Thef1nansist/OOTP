using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB009
{
    class Game
    {
        public event EventHandler ToDamage;
        public event EventHandler ToHealh;
        public event EventHandler MegaDamage;

        
        private int damage = 10;
        private int onehealth = 10;
        private int megadamage = 50;
        
        

        public string PlayerOne { get; set; }
        public string PlayerTwo { get; set; }

        public int FunctionOne(char but)
        {
           
            
            var args = new EventArgs();
        link:
            if (but == 'd')
            {
                ToDamage?.Invoke(damage, args);
            }
            else if (but == 'm')
                MegaDamage?.Invoke(megadamage, args);
            else if (but == 'h') {
                
                ToHealh?.Invoke(onehealth, args); 
            }
            else
            {
                Random random = new Random();
                int ran = random.Next(1, 5);
                switch (ran)
                {
                    case 1:
                        ToDamage?.Invoke(damage + 5, args);
                        break;
                    case 2:
                        ToDamage?.Invoke(damage - 10, args);
                        break;
                    case 3:
                        ToHealh?.Invoke(onehealth + 10, args);
                        break;
                    case 4:
                        MegaDamage?.Invoke(megadamage + 40, args);
                        break;
                    case 5:
                        ToHealh?.Invoke(onehealth - 50, args);
                        break;
                    default:
                        break;
                }
            }
            

            return 0;
        }

   
        //public void TaceTime(DateTime now)
        //{
        //    if (now.Hour <= 8)
        //    {
        //        GoToSleep?.Invoke();
        //    }
        //    else
        //    {
        //        var args = new EventArgs();
        //        DoWork?.Invoke(this, args );
        //    }
        //}
    }
}
