using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class UpgradeSystemDefense : IVisitSpacePort, IAttributes{

        protected double volume, weight;
        private double defense;
        
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

        //Main constructor

        public UpgradeSystemDefense(double _defense){
            defense = _defense;
        }

        //Getters and Setters

        public double GetVolume(){
            return volume;
        }

        public void SetVolume(double _volume){
            volume = _volume;
        }

        public double GetWeight(){
            return weight;
        }

        public void SetWeight(double _weight){
            weight = _weight;
        }

        public double GetDefense(){
            return defense;
        }

        public void SetDefense(double _defense){
            defense = _defense;
        }

        //Upgrade and downgrade mechanic

        public void Upgrade(double _defensePointsUpgrade){
            defense += _defensePointsUpgrade;
        }

        public void Downgrade(double _defensePointsDowngrade){
            if(defense - _defensePointsDowngrade < 0){
                    Console.WriteLine("Cannot downgrade below zero points");
                }
                else{
                    defense -= _defensePointsDowngrade;
                }
        }

        //Methods from IVisitSpacePort

        public double BuyGetCost(double _buyDefenseUpgrade){
            double cost = 0.0;
            cost = _buyDefenseUpgrade * 7.0;
            //defense += _buyDefenseUpgrade;
            return cost;
        }

        public double SellGetCost(double _sellDefenseUpgrade){
            double cost = 0.0;
            cost = _sellDefenseUpgrade * 6.0;
            //defense -= _sellDefenseUpgrade;
            return cost;
        }

        public double RefillGetCost(){
            //Nothing to do here
            return 0;
        }
    
    }  

}