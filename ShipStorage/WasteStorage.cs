using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class WasteStorage : IVisitSpacePort, IAttributes{
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

        //Getters and Setters

        public double GetVolume(){
            return volume;
        }

        public double GetWeight(){
            return weight;
        }

        public void SetVolume(double _volume){
            Volume = _volume;
        }

        public void SetWeight(double _weight){
            Weight = _weight;
        }

        //Increase and Decrease methods

        public void Increase(double _wasteToAdd){
            Volume += _wasteToAdd;
        }

        public bool Decrease(double _wasteToRemove){
            if(volume - _wasteToRemove >= 0){
                Volume -= _wasteToRemove;
                return true;
            }
            else{
                Console.WriteLine("Not enough waste in storage");
                return false;
            }
        }

        //Methods from IVisitSpacePort

        public double BuyGetCost(double _buyWasteHowMuch){
            Console.WriteLine("Illegal operation! Ignoring.");
            return 0;
        }

        public double SellGetCost(double _sellWasteHowMuch){
            double cost = 0.0;
            //Volume -= _sellWasteHowMuch;
            //if(!Decrease(_sellWasteHowMuch)){
            //    Console.WriteLine("Cannot sell.");
            //    return 0;
            //}
            //else{
                cost = _sellWasteHowMuch * 2.0;
                return cost;
            //}
        }

        public double RefillGetCost(){
            double cost = Volume * 3.5;
            //Volume = 0;
            return cost;
        }

    }

}
