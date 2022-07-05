using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class OxygenContainer : IVisitSpacePort, IAttributes{

        protected double volume, weight;
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
        
        public double MaxCapacity {set; get;}
        public OxygenContainer(double capacity){
            MaxCapacity = capacity;
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

        public bool IncreaseCheck(double _oxygenToAdd){
            if(MaxCapacity - volume >= _oxygenToAdd){
                //Volume += _oxygenToAdd;
                return true;
            }
            else{
                //Volume = MaxCapacity;
                //Console.WriteLine("Not enough capacity to store this much oxygen.");
                //Console.WriteLine("Oxygen max capacity: " + MaxCapacity);
                return false;
            }
        }

        public bool DecreaseCheck(double _oxygenToRemove){
            if(volume - _oxygenToRemove >= 0){
                //Volume -= _oxygenToRemove;
                return true;
            }
            else{
                //Volume = 0;
                //Console.WriteLine("Not enough oxygen in storage");
                return false;
            }
        }

        //Methods from IVisitSpacePort

        public double BuyGetCost(double _buyOxygenHowMuch){
            double cost = 0.0;
            //Volume += _buyOxygenHowMuch;
            //if(Increase(_buyOxygenHowMuch)){
            //    Console.WriteLine("Cannot buy.");
            //    return 0;
            //}
            //else{
                cost = _buyOxygenHowMuch * 1.50;
                return cost;
            //}
        }

        public double SellGetCost(double _sellOxygenHowMuch){
            double cost = 0.0;
            //Volume -= _sellOxygenHowMuch;
            //if(!Decrease(_sellOxygenHowMuch)){
            //    Console.WriteLine("Cannot sell.");
            //    return 0;
            //}
            //else{
                cost = _sellOxygenHowMuch * 1.25;
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