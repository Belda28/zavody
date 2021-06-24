using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishing_competitions
{
    class fisherman
    {
        private string name;
        private string surName;
        private DateTime birthDate;
        private int fishingPlaceNumber;
        private int fishingNumber;
        private int maxSizeFish;
        private int numberFish;

        public string Name {
            get { return name; }
            set { name = value; }
        }
        public string SurName {
            get { return surName; }
            set { surName = value; }
        }

        public DateTime BirthDate {
            get { return birthDate; }
            set { birthDate = value; }
        }
        public int FishingPlaceNumber {
            get { return fishingPlaceNumber; }
            set { fishingPlaceNumber = value; }
        }
        public int FishingNumber
        {
            get { return fishingNumber; }
            set { fishingNumber = value; }
        }
        public int MaxSizeFish
        {
            get { return maxSizeFish; }
            set { maxSizeFish = value; }
        }
        public int NumberFish
        {
            get { return numberFish; }
            set { numberFish = value; }
        }

        public fisherman(string name, string surName, DateTime birthDate, int fishingPlaceNumber, int fishingNumber, int maxSizeFish, int numberFish) {
            this.name = name;
            this.surName = surName;
            this.birthDate = birthDate;
            this.fishingPlaceNumber = fishingPlaceNumber;
            this.fishingNumber = fishingNumber;
            this.maxSizeFish = maxSizeFish;
            this.numberFish = numberFish;
        }

    }
}
