using System;

namespace Project{

    class PlanetGenerator{

        
        PlanetRandomizer myRandomizer {get; set;}
        
        public PlanetGenerator(PlanetRandomizer _myRandomizer) {
            myRandomizer = _myRandomizer;
        }

        /*
        public string PrintPlanet(){
            
            Planet myPlanet = myRandomizer.Generator();
            return myPlanet.PrintInfo();
        }

        */

        public Planet GeneratePlanet(){
            Planet myPlanet = myRandomizer.Generator();
            
            //Console.WriteLine(myPlanet.PrintInfo());
            return myPlanet;
        }

    }

}