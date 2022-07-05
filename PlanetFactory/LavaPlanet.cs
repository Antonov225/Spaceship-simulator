using System;

namespace Project{
    class LavaPlanet : Planet{

        //Resources existing on the planet

        private double Hydrogen {set; get;}
        private double Food {set; get;}
        private double Oxygen {set; get;}
        private double Iron {set; get;}
        private double Silicon {set; get;}
        private double Gold {set; get;}

        public LavaPlanet() : base(){
            Hydrogen = 0;
            Food = 0;
            Oxygen = 0;
            Iron = 0;
            Silicon = 0;
            Gold = 0;
        }

        public LavaPlanet(string _name, bool _hasSpacePort, double _hydrogen, double _food, double _oxygen, double _iron, double _silicon, double _gold) : base(_name, _hasSpacePort){
            Hydrogen = _hydrogen;
            Food = _food;
            Oxygen = _oxygen;
            Iron = _iron;
            Silicon = _silicon;
            Gold = _gold;
        }

        public override string PrintInfo()
        {
            return "Planet type: Lava Planet. " + base.PrintInfo() + ". Available resources: Hydrogen: " + Hydrogen + " Food: " + Food + " Oxygen: " + Oxygen + 
            " Iron: " + Iron + " Silicon: " + Silicon + " Gold: " + Gold;
        }
        
        //Getters
        public override double GetHydrogen(){
            return Hydrogen;
        }
        public override double GetFood(){
            return Food;
        }
        public override double GetOxygen(){
            return Oxygen;
        }
        public override double GetIron(){
            return Iron;
        }
        public override double GetSilicon(){
            return Silicon;
        }
        public override double GetGold(){
            return Gold;
        }

        //Setters
        public override void SetHydrogen(double _hydrogen){
            Hydrogen = _hydrogen;
        }
        public override void SetFood(double _food){
            Food = _food;
        }
        public override void SetOxygen(double _oxygen){
            Oxygen = _oxygen;
        }
        public override void SetIron(double _iron){
            Iron = _iron;
        }
        public override void SetSilicon(double _silicon){
            Silicon = _silicon;
        }
        public override void SetGold(double _gold){
            Gold = _gold;
        }

        //Decreasers

        public override bool DecreaseHydrogen(double _hydrogenDecreaseAmount){
            if(Hydrogen >= _hydrogenDecreaseAmount){
                Hydrogen -= _hydrogenDecreaseAmount;
                return true;
            }
            else{
                return false;
            }
        }

        public override bool DecreaseFood(double _foodDecreaseAmount){
            if(Food >= _foodDecreaseAmount){
                Food -= _foodDecreaseAmount;
                return true;
            }
            else{
                return false;
            }
        }
        public override bool DecreaseOxygen(double _oxygenDecreaseAmount){
            if(Oxygen >= _oxygenDecreaseAmount){
                Oxygen -= _oxygenDecreaseAmount;
                return true;
            }
            else{
                return false;
            }
        }
        public override bool DecreaseIron(double _ironDecreaseAmount){
            if(Iron >= _ironDecreaseAmount){
                Iron -= _ironDecreaseAmount;
                return true;
            }
            else{
                return false;
            }
        }
        public override bool DecreaseSilicon(double _siliconDecreaseAmount){
            if(Silicon >= _siliconDecreaseAmount){
                Silicon -= _siliconDecreaseAmount;
                return true;
            }
            else{
                return false;
            }
        }
        public override bool DecreaseGold(double _goldDecreaseAmount){
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