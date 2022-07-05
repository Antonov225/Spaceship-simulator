using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class IronStorage : IVisitSpacePort, IAttributes{

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

        public IronStorage(double _capacity){
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

        public bool IncreaseCheck(double _ironToAdd){
            if(MaxCapacity - volume >= _ironToAdd){
                //Volume += _ironToAdd;
                return true;
            }
            else{
                //Volume = MaxCapacity;
                //Console.WriteLine("Not enough capacity to store this much iron.");
                //Console.WriteLine("Iron max capacity: " + MaxCapacity);
                return false;
            }
        }

        public bool DecreaseCheck(double _ironToRemove){
            if(volume - _ironToRemove >= 0){
                //Volume -= _ironToRemove;
                return true;
            }
            else{
                //Volume = 0;
                //Console.WriteLine("Not enough iron in storage");
                return false;
            }
        }

        //Methods from IVisitSpacePort

        public double BuyGetCost(double _buyIronHowMuch){
            double cost = 0.0;
            //Volume += _buyIronHowMuch;
            //if(!Increase(_buyIronHowMuch)){
            //    Console.WriteLine("Cannot buy.");
            //    return 0;
            //}
            //else{
                cost = _buyIronHowMuch * 2.0;
                return cost;
            //}
        }

        public double SellGetCost(double _sellIronHowMuch){
            double cost = 0.0;
            //Volume -= _sellIronHowMuch;
            //if(!Decrease(_sellIronHowMuch)){
            //    Console.WriteLine("Cannot sell.");
            //    return 0;
            //}
            //else{
                cost = _sellIronHowMuch * 1.5;
                return cost;
            //}
        }

        public double RefillGetCost(){
            double cost = 0;
            cost = MaxCapacity - Volume;
            //Volume = MaxCapacity;
            return cost * 2;
        }
    
    }  

}