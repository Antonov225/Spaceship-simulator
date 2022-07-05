using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class SiliconStorage : IVisitSpacePort, IAttributes{

        //Place for silicon acquired from planets

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

        public SiliconStorage(double _capacity){
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

        public bool IncreaseCheck(double _siliconToAdd){
            if(MaxCapacity - volume >= _siliconToAdd){
                //Volume += _siliconToAdd;
                return true;
            }
            else{
                //Volume = MaxCapacity;
                //Console.WriteLine("Not enough capacity to store this much silicon.");
                //Console.WriteLine("Silicon max capacity: " + MaxCapacity);
                return false;
            }
        }

        public bool DecreaseCheck(double _siliconToRemove){
            if(volume - _siliconToRemove >= 0){
                //Volume -= _siliconToRemove;
                return true;
            }
            else{
                //Volume = 0;
                //Console.WriteLine("Not enough silicon in storage");
                return false;
            }
        }

        //Methods from IVisitSpacePort

        public double BuyGetCost(double _buySiliconHowMuch){
            double cost = 0.0;
            //Volume += _buySiliconHowMuch;
            //if(!Increase(_buySiliconHowMuch)){
            //    Console.WriteLine("Cannot buy.");
            //    return 0;
            //}
            //else{
                cost = _buySiliconHowMuch * 3.0;
                return cost;
            //}
        }

        public double SellGetCost(double _sellSiliconHowMuch){
            double cost = 0.0;
            //Volume -= _sellSiliconHowMuch;
            //if(!Decrease(_sellSiliconHowMuch)){
            //    Console.WriteLine("Cannot sell.");
            //    return 0;
            //}
            //else{
                cost = _sellSiliconHowMuch * 2.0;
                return cost;
            //}
        }
        
        public double RefillGetCost(){
            double cost = 0;
            cost = MaxCapacity - Volume;
            //Volume = MaxCapacity;
            return cost * 3.0;
        }
        
    }  

}