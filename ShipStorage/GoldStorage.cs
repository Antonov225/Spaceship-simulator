using System;
using System.Collections.Generic;
using System.Text;

namespace Project{
    class GoldStorage : IAttributes{

        //Place for Gold - main currency

        protected double volume, weight;
        public double MaxCapacity {set; get;}
        public double Volume
        {
            get { return volume; }

            set
            {
                volume = value;
                weight = value * 7.0; // assume density equal to 7000 kg/m^3 (arbitrary number)
            }
        }
        public double Weight
        {
            get { return weight; }

            set
            {
                weight = value;
                volume = value / 7.0; // assume density equal to 7000 kg/m^3 (arbitrary number)
            }
        }
        public GoldStorage(double _capacity){
            MaxCapacity = _capacity;
        }

        //Getters and Setters

        public double GetMaxCapacity(){
            return MaxCapacity;
        }

        public double GetVolume(){
            return volume;
        }

        public double GetWeight(){
            return weight;
        }

        public void SetVolume(double _volume){
            if(_volume <= MaxCapacity){
                Volume = _volume;
            }
            else{
                Volume = MaxCapacity;
            }
        }

        public void SetWeight(double _weight){
            if(_weight <= MaxCapacity){
                Weight = _weight;
            }
            else{
                Weight = MaxCapacity;
            }
        }

        //Increase and Decrease methods

        public bool IncreaseCheck(double _goldToAdd){
            if(MaxCapacity - volume >= _goldToAdd){
                //Volume += _goldToAdd;
                return true;
            }
            else{
                //Volume = MaxCapacity;
                //Console.WriteLine("Not enough capacity to store this much gold.");
                //Console.WriteLine("Gold max capacity: " + MaxCapacity);
                return false;
            }
        }

        public bool DecreaseCheck(double _goldToRemove){
            if(volume - _goldToRemove >= 0){
                //Volume -= _goldToRemove;
                return true;
            }
            else{
                //Volume = 0;
                //Console.WriteLine("Not enough gold in storage");
                return false;
            }
        }
    }
}