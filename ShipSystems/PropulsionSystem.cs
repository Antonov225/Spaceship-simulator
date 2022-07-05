using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class PropulsionSystem{
        private EnergyStorage tank;
        private WasteStorage waste;
        public PropulsionSystem(EnergyStorage _tank, WasteStorage _waste){
            tank = _tank;
            waste = _waste;
        }

        public double GetVelocity(double shipWeight){
            return (shipWeight + tank.Weight) * 0.00005;
        }

        public bool CheckEnergyBeforeTravel(double travelTime){     //TODO!!!
            //if (travelTime* 1 < tank.Weight){
            //    return true;
            //}
            //else
            //    return false;
            if(tank.DecreaseCheck(5 * travelTime)){
                return true;
            }
            else{
                return false;
            }
        }

        public void Travel(double travelTime){
            waste.Volume += 0.8 * travelTime;
            tank.Volume -= 5 * travelTime;
        }

        public void PrintPropulsionStats(){
            Console.WriteLine("Energy: " + tank.GetVolume() + " / " + tank.GetMaxCapacity());
        }

    }

}