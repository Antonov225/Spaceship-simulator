using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class FoodStorage : IVisitSpacePort, IAttributes{

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
        public FoodStorage(double capacity){
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

        public bool IncreaseCheck(double _foodToAdd){
            if(MaxCapacity - volume >= _foodToAdd){
                //Volume += _foodToAdd;
                return true;
            }
            else{
                //Volume = MaxCapacity;
                //Console.WriteLine("Not enough capacity to store this much food.");
                //Console.WriteLine("Food max capacity: " + MaxCapacity);
                return false;
            }
        }

        public bool DecreaseCheck(double _foodToRemove){
            if(volume - _foodToRemove >= 0){
                //Volume -= _foodToRemove;
                return true;
            }
            else{
                //Volume = 0;
                //Console.WriteLine("Not enough food in storage");
                return false;
            }
        }

        //Methods from IVisitSpacePort

        public double BuyGetCost(double _buyFoodHowMuch){
            double cost = 0.0;
            //Volume += _buyFoodyHowMuch;
            //if(!Increase(_buyFoodHowMuch)){
            //    Console.WriteLine("Cannot buy.");
            //    return 0;
            //}
            //else{
                cost = _buyFoodHowMuch * 2.5;
                return cost;
            //}
        }

        public double SellGetCost(double _sellFoodHowMuch){
            double cost = 0.0;
            //Volume -= _sellFoodHowMuch;
            //if(!Decrease(_sellFoodHowMuch)){
            //    Console.WriteLine("Cannot sell.");
            //    return 0;
            //}
            //else{
                cost = _sellFoodHowMuch * 2.25;
                return cost;
            //}
        }

        public double RefillGetCost(){
            double cost = 0;
            cost = MaxCapacity - Volume;
            //Volume = MaxCapacity;
            return cost * 2.5;
        }

    }
}