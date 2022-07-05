using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class UpgradeSystemAttack : IVisitSpacePort, IAttributes{

        protected double volume, weight;
        private double attack;
        
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

        public UpgradeSystemAttack(double _attack){
            attack = _attack;
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

        public double GetAttack(){
            return attack;
        }

        public void SetAttack(double _attack){
            attack = _attack;
        }

        //Upgrade and downgrade mechanic

        public void Upgrade(double _attackPointsUpgrade){
            attack += _attackPointsUpgrade;
        }

        public void Downgrade(double _attackPointsDowngrade){
                if(attack - _attackPointsDowngrade < 0){
                    Console.WriteLine("Cannot downgrade below zero points");
                }
                else{
                    attack -= _attackPointsDowngrade;
                }
        }

        //Methods from IVisitSpacePort

        public double BuyGetCost(double _buyAttackUpgrade){
            double cost = 0.0;
            cost = _buyAttackUpgrade * 5.0;
            //attack += _buyAttackUpgrade;
            return cost;
        }

        public double SellGetCost(double _sellAttackUpgrade){
            double cost = 0.0;
            cost = _sellAttackUpgrade * 4.0;
            //attack -= _sellAttackUpgrade;
            return cost;
        }

        public double RefillGetCost(){
            //Nothing to do here
            return 0;
        }

    }  

}