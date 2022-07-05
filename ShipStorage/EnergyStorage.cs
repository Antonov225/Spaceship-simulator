using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class EnergyStorage : IVisitSpacePort, IAttributes{
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
        
        public EnergyStorage(double _capacity){
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

        public bool IncreaseCheck(double _energyToAdd){
            if(MaxCapacity - volume >= _energyToAdd){
                //Volume += _energyToAdd;
                return true;
            }
            else{
                //Console.WriteLine("Not enough capacity to store this much energy.");
                //Console.WriteLine("Energy max capacity: " + MaxCapacity);
                return false;
            }
        }

        public bool DecreaseCheck(double _energyToRemove){
            if(volume - _energyToRemove >= 0){
                //Volume -= _energyToRemove;
                return true;
            }
            else{
                //Console.WriteLine("Not enough energy in storage");
                return false;
            }
        }

        //Methods from IVisitSpacePort

        public double BuyGetCost(double _buyEnergyHowMuch){
            double cost = 0.0;
            //Volume += _buyEnergyHowMuch;
            //if(!IncreaseCheck(_buyEnergyHowMuch)){
            //    Console.WriteLine("Cannot buy.");
            //    return 0;
            //}
            //else{
                cost = _buyEnergyHowMuch * 1.5;
                return cost;
            //}
        }

        public double SellGetCost(double _sellSiliconHowMuch){
            double cost = 0.0;
            //Volume -= _sellSiliconHowMuch;
            //if(!DecreaseCheck(_sellSiliconHowMuch)){
            //    Console.WriteLine("Cannot sell.");
            //    return 0;
            //}
            //else{
                cost = _sellSiliconHowMuch * 1.25;
                return cost;
            //}
        }

        public double RefillGetCost(){
            double cost = 0;
            cost = MaxCapacity - Volume;
            //Volume = MaxCapacity;
            return cost * 1.5;  
        }

    }

}
