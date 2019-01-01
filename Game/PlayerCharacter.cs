using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class PlayerCharacter /*: INotifyPropertyChanged*/
    {
        private int _healt = 100;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }


        }
        public string NickName { get; set; }
        public int Health

        {
            get
            {
                return _healt;
            }
            set
            {
                _healt = value;
            }

        }

        public bool IsNoob { get; set; }
        public List<string> Weapons { get; set; }
        //public event EventHandler<EventArgs> PlayerSlept;
        //public event PropertyChangedEventHandler PropertyChanged;

        public PlayerCharacter()
        {
            FirstName = GeneratedRandomFirstName();
            IsNoob = true;
            CreateStartingWeapons();

        }
        public void TakeDamage(int damage)
        {
            Health = Math.Max(1, Health -= damage);

        }
        public void Sleep()
        {
            int healtIncrease = CalculateHealtIncrease();
            Health = Health + healtIncrease;

        }

        private int CalculateHealtIncrease()
        {
            var rnd = new Random();
            return rnd.Next(1, 101);
        }

        private void CreateStartingWeapons()
        {
            Weapons = new List<string>()
           {
               "Long Bow",
               "Short Bow",
               "Short Sword",

           };
        }

        private string GeneratedRandomFirstName()
        {
            return "Sasa";
        }

    }
}
