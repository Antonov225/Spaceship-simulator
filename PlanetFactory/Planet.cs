using System;

namespace Project{
    abstract class Planet{

        private string name {set; get;}
        private bool hasSpacePort {set; get;}

        private double Hydrogen {set; get;}
        private double Food {set; get;}
        private double Oxygen {set; get;}
        private double Iron {set; get;}
        private double Silicon {set; get;}
        private double Gold {set; get;}

        public Planet(){
            name = "unknown";
            hasSpacePort = false;
        }

        public Planet(string _name, bool _hasSpacePort){
            name = _name;
            hasSpacePort = _hasSpacePort;

        }

        public virtual string PrintInfo(){
            return "Name: " + name + ". Has Space Port: " + hasSpacePort;
        }

        //Virtual getters and setters

        public virtual double GetHydrogen(){
            return Hydrogen;
        }
        public virtual double GetFood(){
            return Food;
        }
        public virtual double GetOxygen(){
            return Oxygen;
        }
        public virtual double GetIron(){
            return Iron;
        }
        public virtual double GetSilicon(){
            return Silicon;
        }
        public virtual double GetGold(){
            return Gold;
        }

        public virtual string GetName(){
            return name;
        }

        public virtual bool SpacePortPresent(){
            return hasSpacePort;
        }

        //Setters
        public virtual void SetHydrogen(double _hydrogen){
            Hydrogen = _hydrogen;
        }
        public virtual void SetFood(double _food){
            Food = _food;
        }
        public virtual void SetOxygen(double _oxygen){
            Oxygen = _oxygen;
        }
        public virtual void SetIron(double _iron){
            Iron = _iron;
        }
        public virtual void SetSilicon(double _silicon){
            Silicon = _silicon;
        }
        public virtual void SetGold(double _gold){
            Gold = _gold;
        }

        //Decreasers

        public virtual bool DecreaseHydrogen(double _hydrogenDecreaseAmount){
            if(Hydrogen >= _hydrogenDecreaseAmount){
                Hydrogen -= _hydrogenDecreaseAmount;
                return true;
            }
            else{
                return false;
            }
        }

        public virtual bool DecreaseFood(double _foodDecreaseAmount){
            if(Food >= _foodDecreaseAmount){
                Food -= _foodDecreaseAmount;
                return true;
            }
            else{
                return false;
            }
        }
        public virtual bool DecreaseOxygen(double _oxygenDecreaseAmount){
            if(Oxygen >= _oxygenDecreaseAmount){
                Oxygen -= _oxygenDecreaseAmount;
                return true;
            }
            else{
                return false;
            }
        }
        public virtual bool DecreaseIron(double _ironDecreaseAmount){
            if(Iron >= _ironDecreaseAmount){
                Iron -= _ironDecreaseAmount;
                return true;
            }
            else{
                return false;
            }
        }
        public virtual bool DecreaseSilicon(double _siliconDecreaseAmount){
            if(Silicon >= _siliconDecreaseAmount){
                Silicon -= _siliconDecreaseAmount;
                return true;
            }
            else{
                return false;
            }
        }
        public virtual bool DecreaseGold(double _goldDecreaseAmount){
            if(Gold >= _goldDecreaseAmount){
                Gold -= _goldDecreaseAmount;
                return true;
            }
            else{
                return false;
            }
        }

    }

}