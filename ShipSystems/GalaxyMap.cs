using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Linq;

namespace Project
{
    class GalaxyMap{

        List<Planet> mainMap = new List<Planet>();

        //Planet 3D coordinate system
        List<double> x = new List<double>();
        List<double> y = new List<double>();
        List<double> z = new List<double>();

        List<double> travelDistances = new List<double>();
        private int CurrentPlanetIndex;

        //Galaxy Map expand functions

        //Starting planet generation
        public void AddFirstPlanetToMap(Planet _planet){
            Random rnd = new Random();
            var random = new Random();

            if(mainMap.Count() == 0){           //Generate first planet with coordinates
                mainMap.Add(_planet);
                x.Add(random.Next(10, 1000));
                y.Add(random.Next(10, 1000));
                z.Add(random.Next(10, 1000));
                CurrentPlanetIndex = 0;         //Set the planet as current
                travelDistances.Add(0.0);       //Set distance to current planet as 0
            }
            else{
                Console.WriteLine("Starting planet already exists");
            }
        }

        //Map expansion
        //Second and subsequent planets coordinates are based on last planet coordinates
        public void AddToMap(Planet _planet){
            Random rnd = new Random();
            var random = new Random();

            mainMap.Add(_planet);
            x.Add( x[x.Count() - 1] + random.Next(10, 1000) );
            y.Add( y[y.Count() - 1] + random.Next(10, 1000) );
            z.Add( y[y.Count() - 1] + random.Next(10, 1000) );

            travelDistances.Add(Math.Sqrt(Math.Pow((x[x.Count() - 1] - x[CurrentPlanetIndex]), 2) +
                                          Math.Pow((y[y.Count() - 1] - y[CurrentPlanetIndex]), 2) +
                                          Math.Pow((z[z.Count() - 1] - z[CurrentPlanetIndex]), 2)));
        }

        
        public void RecalculateTravelDistances(){

            for(int i = 0; i < mainMap.Count(); i++){

                if(i == CurrentPlanetIndex){
                    travelDistances[i] = 0.0;
                }
                else{
                    travelDistances[i] = Math.Sqrt(Math.Pow((x[i] - x[CurrentPlanetIndex]), 2) +
                                                   Math.Pow((y[i] - y[CurrentPlanetIndex]), 2) +
                                                   Math.Pow((z[i] - z[CurrentPlanetIndex]), 2));
                }
            }
        }
        

        public void SetCurrentPlanet(int _index){
            if(_index < mainMap.Count() && _index >= 0){
                CurrentPlanetIndex = _index;
                travelDistances[_index] = 0;
            }
            else{
                Console.WriteLine("No such index in map");
            } 
        }

        public void PrintTravelDistances(){
            int i = 0;
            Console.WriteLine("Travel distances: ");

            while(i != travelDistances.Count()){
                Console.WriteLine(i + ". " + Math.Round(travelDistances[i]));
                i++;
            }
        }

        public void PrintCoordinatesList(){
            int i = 0;
            Console.WriteLine("Planet coordinates: ");

            while(i != mainMap.Count()){
                Console.WriteLine(i + ". x:" + x[i] + " y:" + y[i] + " z:" + z[i]);
                i++;
            }
        }

        public void PrintMap(){
            int i = 0;
            Console.WriteLine("Galaxy Map: ");
            Console.Write("[Current planet marked ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("GREEN");
            Console.ResetColor();
            Console.Write("]:\n");

            while(i != mainMap.Count()){
                if(i == CurrentPlanetIndex){
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(i + ". Distance: " + Math.Round(travelDistances[i]) + ". " + mainMap[i].PrintInfo());
                    Console.ResetColor();
                    i++;
                }
                else{
                    Console.WriteLine(i + ". Distance: " + Math.Round(travelDistances[i]) + ". " + mainMap[i].PrintInfo());
                    i++;
                }
            }
        }

        public void PrintCurrentPlanet(){
            int i = 0;
            Console.WriteLine("Current planet: ");

            while(i != mainMap.Count()){
                if(i == CurrentPlanetIndex){
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(i + ". Distance: " + travelDistances[i] + ". " + mainMap[i].PrintInfo());
                    Console.ResetColor();
                    i++;
                }
                else{
                    i++;
                }
            }
        }

        public void PrintCurrentPlanetResources(){
            Console.WriteLine("Resources on current planet: ");
            Console.WriteLine("Food: " + GetFood(CurrentPlanetIndex));
            Console.WriteLine("Hydrogen: " + GetHydrogen(CurrentPlanetIndex));
            Console.WriteLine("Iron: " + GetIron(CurrentPlanetIndex));
            Console.WriteLine("Oxygen: " + GetOxygen(CurrentPlanetIndex));
            Console.WriteLine("Silicon: " + GetSilicon(CurrentPlanetIndex));
            Console.WriteLine("Gold: " + GetGold(CurrentPlanetIndex));
            Console.WriteLine();
        }

        public int GetCurrentPlanetIndex(){
            return CurrentPlanetIndex;
        }

        public double GetDistanceToPlanet(int _index){
            return travelDistances[_index];
        }
        
        //Getters by map index

        public double GetHydrogen(int _index){
            return mainMap[_index].GetHydrogen();
        }
        public double GetFood(int _index){
            return mainMap[_index].GetFood();
        }
        public double GetOxygen(int _index){
            return mainMap[_index].GetOxygen();
        }
        public double GetIron(int _index){
            return mainMap[_index].GetIron();
        }
        public double GetSilicon(int _index){
            return mainMap[_index].GetSilicon();
        }
        public double GetGold(int _index){
            return mainMap[_index].GetGold();
        }

        public string GetName(int _index){
            return mainMap[_index].GetName();
        }

        public bool CurrentPlanetHasSpacePort(){
            return mainMap[CurrentPlanetIndex].SpacePortPresent();
        }

        //Setters by map index
        public void SetHydrogen(int _index, double _value){
            mainMap[_index].SetHydrogen(_value);
        }
        public void SetFood(int _index, double _value){
            mainMap[_index].SetFood(_value);
        }
        public void SetOxygen(int _index, double _value){
            mainMap[_index].SetOxygen(_value);
        }
        public void SetIron(int _index, double _value){
            mainMap[_index].SetIron(_value);
        }
        public void SetSilicon(int _index, double _value){
            mainMap[_index].SetSilicon(_value);
        }
        public void SetGold(int _index, double _value){
            mainMap[_index].SetGold(_value);
        }
        
        //Planet modifiers by map index
 
        public bool DecreaseHydrogen(int _index, double _value){
            //Planet tempPlanet = mainMap[_index];
            //tempPlanet.DecreaseHydrogen(_value);
            //mainMap[_index] = tempPlanet;
            return mainMap[_index].DecreaseHydrogen(_value);
        }
        public bool DecreaseFood(int _index, double _value){
            //Planet tempPlanet = mainMap[_index];
            //tempPlanet.DecreaseFood(_value);
            //mainMap[_index] = tempPlanet;
            return mainMap[_index].DecreaseFood(_value);
        }
        public bool DecreaseOxygen(int _index, double _value){
            //Planet tempPlanet = mainMap[_index];
            //tempPlanet.DecreaseOxygen(_value);
            //mainMap[_index] = tempPlanet;
            return mainMap[_index].DecreaseOxygen(_value);
        }
        public bool DecreaseIron(int _index, double _value){
            //Planet tempPlanet = mainMap[_index];
            //tempPlanet.DecreaseIron(_value);
            //mainMap[_index] = tempPlanet;
            return mainMap[_index].DecreaseIron(_value);
        }
        public bool DecreaseSilicon(int _index, double _value){
            //Planet tempPlanet = mainMap[_index];
            //tempPlanet.DecreaseSilicon(_value);
            //mainMap[_index] = tempPlanet;
            return mainMap[_index].DecreaseSilicon(_value);
        }
        public bool DecreaseGold(int _index, double _value){
            //Planet tempPlanet = mainMap[_index];
            //tempPlanet.DecreaseGold(_value);
            //mainMap[_index] = tempPlanet;
            return mainMap[_index].DecreaseGold(_value);
        }
      
    }
}