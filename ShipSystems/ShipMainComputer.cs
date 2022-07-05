using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class ShipMainComputer{

        //Ship resources

        //private List<OxygenContainer> oxygenBottles = new List<OxygenContainer>();
        private OxygenContainer oxygenContainer;
        private FoodStorage foodContainer;
        private WasteStorage waste;
        
        //Planet resources
        
        private HydrogenStorage hydrogenStorage;
        private IronStorage ironStorage;
        private SiliconStorage siliconStorage;

        //Upgrade systems

        private UpgradeSystemAttack attack;
        private UpgradeSystemDefense defense;

        //Special resources

        private GoldStorage goldStorage; //Main currency
        private GalaxyMap planetMap;

        //Main constructor

        public ShipMainComputer(OxygenContainer _oxygenContainer, FoodStorage food_container, WasteStorage _waste, HydrogenStorage _hydrogen, IronStorage _iron, 
                SiliconStorage _silicon, GoldStorage _gold, UpgradeSystemAttack _attack, UpgradeSystemDefense _defense, GalaxyMap _planetMap){
            oxygenContainer = _oxygenContainer;
            foodContainer = food_container;
            waste = _waste;
            hydrogenStorage = _hydrogen;
            ironStorage = _iron;
            siliconStorage = _silicon;
            goldStorage = _gold;
            attack = _attack;
            defense = _defense;
            planetMap = _planetMap;
        }

        //Upgrade and downgrade methods TODO

        public bool CraftAttackUpgrade(double _attackPointsUpgrade){
            if(oxygenContainer.DecreaseCheck(2.5 * _attackPointsUpgrade) &&
               foodContainer.DecreaseCheck(1.5 * _attackPointsUpgrade) &&
               siliconStorage.DecreaseCheck(2.0 * _attackPointsUpgrade)){

                    oxygenContainer.Volume -= 2.5 * _attackPointsUpgrade;
                    foodContainer.Volume -= 1.5 * _attackPointsUpgrade;
                    siliconStorage.Volume -= 2.0 * _attackPointsUpgrade;

                    attack.Upgrade(_attackPointsUpgrade);
                    return true;
            }
            else{
                    return false;
            }
        }

        public bool CraftDefenseUpgrade(double _defensePointsUpgrade){
            if(oxygenContainer.DecreaseCheck(2.5 * _defensePointsUpgrade) &&
               foodContainer.DecreaseCheck(1.5 * _defensePointsUpgrade) &&
               ironStorage.DecreaseCheck(3.0 * _defensePointsUpgrade)){

                    oxygenContainer.Volume -= 2.5 * _defensePointsUpgrade;
                    foodContainer.Volume -= 1.5 * _defensePointsUpgrade;
                    ironStorage.Volume -= 3.0 * _defensePointsUpgrade;

                    defense.Upgrade(_defensePointsUpgrade);
                    return true;
            }
            else{
                return false;
            }
            
        }

        public bool DismantleAttackUpgrade(double _attackPointsDowngrade){
            if(oxygenContainer.DecreaseCheck(1.5 * _attackPointsDowngrade) &&
               foodContainer.DecreaseCheck(1.25 * _attackPointsDowngrade) &&
               siliconStorage.IncreaseCheck(1.8 * _attackPointsDowngrade)){

                    oxygenContainer.Volume -= 1.5 * _attackPointsDowngrade;
                    foodContainer.Volume -= 1.25 * _attackPointsDowngrade;
                    siliconStorage.Volume += 1.8 * _attackPointsDowngrade;

                    attack.Downgrade(_attackPointsDowngrade);
                    return true;
            }
            else{
                return false;
            }
        }

        public bool DismantleDefenseUpgrade(double _defensePointsDowngrade){
            if(oxygenContainer.DecreaseCheck(1.5 * _defensePointsDowngrade) &&
               foodContainer.DecreaseCheck(1.25 * _defensePointsDowngrade) &&
               ironStorage.IncreaseCheck(2.5 * _defensePointsDowngrade)){

                    oxygenContainer.Volume -= 1.5 * _defensePointsDowngrade;
                    foodContainer.Volume -= 1.25 * _defensePointsDowngrade;
                    ironStorage.Volume += 2.5 * _defensePointsDowngrade;

                    defense.Downgrade(_defensePointsDowngrade);
                    return true;
            }
            else{
                return false;
            }
        }

        //Travel methods

        public bool CheckSuppliesBeforeTravel(double travelTime){   ///TODO!!!
            //if((oxygenContainer.Weight > travelTime * 1) && (foodContainer.Weight > travelTime * 4)){
            //    return true;
            //}
            //else
            //    return false;
            if(oxygenContainer.DecreaseCheck(travelTime * 4) && foodContainer.DecreaseCheck(travelTime * 4)){
                return true;
            }
            else{
                return false;
            }
        }

        public void Run(double travelTime){
            oxygenContainer.Volume -= travelTime * 4;
            foodContainer.Volume -= travelTime * 4;
            waste.Volume +=  travelTime * 2;
            //oxygenContainer.Decrease(travelTime * 40);
            //foodContainer.Decrease(travelTime * 40);
            //waste.Increase(travelTime * 20);
        }

        //Other methods

        public void PrintShipStatistics(){
            Console.WriteLine("Attack: " + attack.GetAttack() + " Defense: " + defense.GetDefense());
        }

        public void PrintShipCargo(){
            Console.WriteLine("Current cargo by Volume: ");
            Console.WriteLine("Oxygen: " + Math.Round(oxygenContainer.GetVolume()) + " / " + oxygenContainer.GetMaxCapacity());
            Console.WriteLine("Food: " + Math.Round(foodContainer.GetVolume()) + " / " + foodContainer.GetMaxCapacity());
            Console.WriteLine("Hydrogen: " + Math.Round(hydrogenStorage.GetVolume()) + " / " + hydrogenStorage.GetMaxCapacity());
            Console.WriteLine("Iron: " + Math.Round(ironStorage.GetVolume()) + " / " + ironStorage.GetMaxCapacity());
            Console.WriteLine("Silicon: " + Math.Round(siliconStorage.GetVolume()) + " / " + siliconStorage.GetMaxCapacity());
            Console.WriteLine("Gold: " + Math.Round(goldStorage.GetVolume()) + " / " + goldStorage.GetMaxCapacity());
            Console.WriteLine("Waste: " + Math.Round(waste.GetVolume()));
        }

    }

}