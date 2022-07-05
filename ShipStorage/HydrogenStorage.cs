using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class HydrogenStorage : IVisitSpacePort, IAttributes{

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

        public HydrogenStorage(double _capacity){
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

        public bool IncreaseCheck(double _hydrogenToAdd){
            if(MaxCapacity - volume >= _hydrogenToAdd){
                //Volume += _hydrogenToAdd;
                return true;
            }
            else{
                //Volume = MaxCapacity;
                //Console.WriteLine("Not enough capacity to store this much hydrogen.");
                //Console.WriteLine("Hydrogen max capacity: " + MaxCapacity);
                return false;
            }
        }

        public bool DecreaseCheck(double _hydrogenToRemove){
            if(volume - _hydrogenToRemove >= 0){
                //Volume -= _hydrogenToRemove;
                return true;
            }
            else{
                //Volume = 0;
                //Console.WriteLine("Not enough hydrogen in storage");
                return false;
            }
        }

        //Methods from IVisitSpacePort

        public double BuyGetCost(double _buyHydrogenHowMuch){
            double cost = 0.0;
            //Volume += _buyHydrogenHowMuch;
            //if(!Increase(_buyHydrogenHowMuch)){
            //    Console.WriteLine("Cannot buy.");
            //    return 0;
            //}
            //else{
                cost = _buyHydrogenHowMuch * 1.50;
                return cost;
            //}
        }

        public double SellGetCost(double _sellHydrogenHowMuch){
            double cost = 0.0;
            //Volume -= _sellHydrogenHowMuch;
            //if(!Decrease(_sellHydrogenHowMuch)){
            //    Console.WriteLine("Cannot sell.");
            //    return 0;
            //}
            //else{
                cost = _sellHydrogenHowMuch * 1.25;
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