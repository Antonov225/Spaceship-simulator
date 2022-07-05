using System;

namespace Project{
    abstract class PlanetRandomizer{

        public abstract Planet Generator();

    }

    class Factory1 : PlanetRandomizer{

        //Planet name generator
        public static string GenerateName(int len){ 

            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string name = "";
            name += consonants[r.Next(consonants.Length)].ToUpper();
            name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a letter has been added. It's 2 right now because first two letters have been manually added already
            
            while (b < len){
                name += consonants[r.Next(consonants.Length)];
                b++;
                name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return name;
        }

        public override Planet Generator(){

            //Randomizing planet type
            Random rnd = new Random();
            int randomizer = rnd.Next(1, 60);


            if(randomizer > 0 && randomizer < 10){

                var random = new Random();
                var randomBool = random.Next(2) == 1;   //Generate true/false randomly

                return new GasPlanet(GenerateName(random.Next(4, 8)), randomBool, random.Next(500, 1000), 0, random.Next(5000, 10000), 0, 0, 0);
            }
            else if(randomizer >= 10 && randomizer < 20){

                var random = new Random();
                var randomBool = random.Next(2) == 1;

                return new LavaPlanet(GenerateName(random.Next(4, 8)), randomBool, 0, 0, 0, random.Next(1000, 2000), random.Next(100, 500), random.Next(50, 75));
            }
            else if(randomizer >= 20 && randomizer < 30){

                var random = new Random();
                var randomBool = random.Next(2) == 1;

                //Terrestial planet has the most resources
                return new TerrestialPlanet(GenerateName(random.Next(4, 8)), randomBool, random.Next(10000, 20000), random.Next(2000, 5000),
                random.Next(10000, 50000), random.Next(10000, 20000), random.Next(5000, 20000), random.Next(25, 150));
            }
            else if (randomizer >= 30 && randomizer < 40){

                var random = new Random();
                var randomBool = random.Next(2) == 1;

                return new OceanPlanet(GenerateName(random.Next(4, 8)), randomBool, random.Next(20000, 50000), random.Next(1000, 3000), random.Next(50000, 100000), 0, 0, 0);
            }
            else if(randomizer >= 40 && randomizer < 50){

                var random = new Random();
                var randomBool = random.Next(2) == 1;

                return new IronPlanet(GenerateName(random.Next(4, 8)), randomBool, 0, 0, 0, random.Next(20000, 50000), 0, random.Next(100, 250));
            }
            else{

                var random = new Random();
                var randomBool = random.Next(2) == 1;

                return new DesertPlanet(GenerateName(random.Next(4, 8)), randomBool, random.Next(1000, 2000), 0, random.Next(1000, 5000), random.Next(100, 250), random.Next(10000, 25000), random.Next(50, 150));
            }

        }
        
    }

}