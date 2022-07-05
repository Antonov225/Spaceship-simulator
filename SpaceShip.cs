using System;
using System.Collections.Generic;
using System.Text;

namespace Project{

    class Spaceship{

        static void DisplayShopMenu(){
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine(" -1-   Energy                ");
            Console.WriteLine(" -2-   Food                  ");
            Console.WriteLine(" -3-   Hydrogen              ");
            Console.WriteLine(" -4-   Iron                  ");
            Console.WriteLine(" -5-   Oxygen                ");
            Console.WriteLine(" -6-   Silicon               ");
            Console.WriteLine(" -7-   Never mind, return    ");
            Console.WriteLine();
            Console.ResetColor();
        }

        //Actual SpaceShip Simulation

        public static void Simulation(){

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@" ______     ______   ______     ______     ______     ______     __  __     __     ______      ");
            Console.WriteLine(@"/\  ___\   /\  == \ /\  __ \   /\  ___\   /\  ___\   /\  ___\   /\ \_\ \   /\ \   /\  == \     ");
            Console.WriteLine(@"\ \___  \  \ \  _-/ \ \  __ \  \ \ \____  \ \  __\   \ \___  \  \ \  __ \  \ \ \  \ \  _-/     ");
            Console.WriteLine(@" \/\_____\  \ \_\    \ \_\ \_\  \ \_____\  \ \_____\  \/\_____\  \ \_\ \_\  \ \_\  \ \_\       ");
            Console.WriteLine(@"  \/_____/   \/_/     \/_/\/_/   \/_____/   \/_____/   \/_____/   \/_/\/_/   \/_/   \/_/       ");
            Console.WriteLine(@"");
            Console.WriteLine(@" ______     __     __    __     __  __     __         ______     ______   ______     ______    ");
            Console.WriteLine(@"/\  ___\   /\ \   /\ \_./  \   /\ \/\ \   /\ \       /\  __ \   /\__  _\ /\  __ \   /\  == \   ");
            Console.WriteLine(@"\ \___  \  \ \ \  \ \ \-./\ \  \ \ \_\ \  \ \ \____  \ \  __ \  \/_/\ \/ \ \ \/\ \  \ \  __<   ");
            Console.WriteLine(@" \/\_____\  \ \_\  \ \_\ \ \_\  \ \_____\  \ \_____\  \ \_\ \_\    \ \_\  \ \_____\  \ \_\ \_\ ");
            Console.WriteLine(@"  \/_____/   \/_/   \/_/  \/_/   \/_____/   \/_____/   \/_/\/_/     \/_/   \/_____/   \/_/ /_/ ");
            Console.WriteLine(@"");
            Console.ResetColor();

            //Build cargo
            WasteStorage waste = new WasteStorage();
            waste.Volume = 0.0;
            
            FoodStorage food = new FoodStorage(2000.0);
            food.Volume = 1000.0;
            
            OxygenContainer oxygen = new OxygenContainer(20000.0);
            oxygen.Volume = 15000.0;

            HydrogenStorage hydrogen = new HydrogenStorage(5000.0);
            hydrogen.Volume = 500.0;

            IronStorage iron = new IronStorage(5000.0);
            iron.Volume = 500.0;

            SiliconStorage silicon = new SiliconStorage(5000.0);
            silicon.Volume = 500.0;

            GoldStorage gold = new GoldStorage(50000.0);
            gold.Volume = 45000.0;

            //Generate a starting planet
            Factory1 myFactory1 = new Factory1();
            PlanetGenerator myGenerator = new PlanetGenerator(myFactory1);    

            GalaxyMap galaxyMap = new GalaxyMap();
            galaxyMap.AddFirstPlanetToMap(myGenerator.GeneratePlanet());

            //Set default attack and defense values
            UpgradeSystemAttack attack = new UpgradeSystemAttack(1000.0);
            UpgradeSystemDefense defense = new UpgradeSystemDefense(2000.0);

            //Build ship main computer
            ShipMainComputer computer = new ShipMainComputer(oxygen, food, waste, hydrogen, iron, silicon, gold, attack, defense, galaxyMap);

            //Build PropulsionSystem
            EnergyStorage energy = new EnergyStorage(5000.0);
            energy.Volume = energy.MaxCapacity;
            PropulsionSystem propulsion = new PropulsionSystem(energy, waste);

        
            //Items with attributes add to total weight
            List<IAttributes> cargo = new List<IAttributes>() {waste, food, oxygen, hydrogen, iron, silicon, gold, energy};
            double baseWeight = 2000.0;
            double totalWeight = baseWeight;

            foreach(IAttributes item in cargo) totalWeight += item.Weight;  //calculating totalWeight of all cargo + base ship weight
            
            //Items usable in SpacePort
            List<IVisitSpacePort> SpacePortUsableItems = new List<IVisitSpacePort> {waste, food, oxygen, hydrogen, iron, silicon, energy};


            //Print starting ship parametrs
            Console.WriteLine(@"Simulation started. All ship systems online. Printing intital ship parameters: ");
            Console.WriteLine();
            Console.WriteLine("Spaceship weight: " + totalWeight);
            computer.PrintShipStatistics();
            propulsion.PrintPropulsionStats();
            Console.WriteLine();
            computer.PrintShipCargo();
            Console.WriteLine();
            galaxyMap.PrintMap();
            Console.WriteLine();

            //Main manu loop
            while(true){
                
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("-----------------ACTIONS-----------------");
                Console.WriteLine(" -1-   Travel to planet                  "); //Done
                Console.WriteLine(" -2-   Scan for planets                  "); //Done
                Console.WriteLine(" -3-   Gather resource                   "); //Done
                Console.WriteLine(" -4-   Craft upgrade                     "); //Done
                Console.WriteLine(" -5-   Dismantle upgrade                 "); //Done
                Console.WriteLine("-----------------GET INFO----------------");
                Console.WriteLine(" -6-   Galaxy Map                        "); //Done
                Console.WriteLine(" -7-   Current planet info               "); //Done
                Console.WriteLine(" -8-   Print planet coordinates          "); //Done
                Console.WriteLine(" -9-   Cargo status                      "); //Done
                Console.WriteLine(" -10-  Ship statistics                   "); //Done
                Console.WriteLine("----------------SPACEPORT----------------");
                Console.WriteLine(" -11-  Buy                               "); //Done
                Console.WriteLine(" -12-  Sell                              "); //Done
                Console.WriteLine(" -13-  Refill                            "); //Done
                Console.WriteLine(" -14-  Buy Upgrade                       "); //Done
                Console.WriteLine("------------------OTHER------------------");
                Console.WriteLine(" -15-  Project info                      "); //Done
                Console.WriteLine(" -16-  End simulation                    "); //Done
                Console.WriteLine(" -17-  QTE Init [DEBUG]                  "); //Done
                Console.WriteLine("-----------------------------------------");
                Console.ResetColor();

                int choice;
                double amount;
                Console.WriteLine("Choose option: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch(choice){
                    case 1:
                            //TRAVEL TO PLANET
                            Console.WriteLine();
                            galaxyMap.PrintMap();
                            Console.WriteLine();
                            Console.WriteLine("Enter planet number you want to visit: ");
                            choice = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            //Check if travel is possible
                            totalWeight = baseWeight;
                            foreach(IAttributes item in cargo) totalWeight += item.Weight;
                            Console.WriteLine("Current ship weight: " + totalWeight);

                            //Calculate travel time
                            double time = galaxyMap.GetDistanceToPlanet(choice) / propulsion.GetVelocity(totalWeight);

                            //Check energy
                            if(!propulsion.CheckEnergyBeforeTravel(time)){
                                Console.WriteLine("Not enough energy to travel " + Math.Round(galaxyMap.GetDistanceToPlanet(choice)));
                                Console.WriteLine("Available fuel: " + energy.Volume);
                                Console.WriteLine("Required travel time: " + time.ToString(".#") + " hours");
                            }
                            //Check supplies
                            else if(!computer.CheckSuppliesBeforeTravel(time)){
                                Console.WriteLine("Not enough supplies to travel " + Math.Round(galaxyMap.GetDistanceToPlanet(choice)));
                                Console.WriteLine("Available food: " + food.Volume);
                                Console.WriteLine("Available oxygen: " + oxygen.Volume);
                                Console.WriteLine("Required travel time: " + time.ToString(".#") + " hours");
                            }
                            //If ok, travel to planet
                            else{
                                Console.WriteLine("Travel destination accepted. Distance: " + Math.Round(galaxyMap.GetDistanceToPlanet(choice)));
                                Console.WriteLine("Travelling to planet " + galaxyMap.GetName(choice));
                                galaxyMap.SetCurrentPlanet(choice);
                                propulsion.Travel(time);
                                computer.Run(time);

                                //20% chance to get attacked while travelling
                                if(QTEInterface.RandomBoolPercentage(20, 100)){
                                    Console.WriteLine("You are under attack!");
                                    SpaceFightInit();
                                }

                                Console.WriteLine("Arrived at planet " + galaxyMap.GetName(choice));

                                //For comparison, calculate total weight again
                                totalWeight = baseWeight;
                                foreach(IAttributes item in cargo) totalWeight += item.Weight;
                                Console.WriteLine("Current ship weight: " + totalWeight.ToString("."));

                                Console.WriteLine();
                                computer.PrintShipCargo();
                                galaxyMap.RecalculateTravelDistances(); //Important!
                                //AlreadyScanned = false;

                                Console.WriteLine("Current ship energy: " + Math.Round(energy.GetVolume()));
                            }

                            break;
                    case 2:
                            Random rnd = new Random();
                            var random = new Random();
                            int number = random.Next(1, 3);

                            Console.WriteLine("Scanning for nearby planets...");
                            Console.WriteLine("Plantes found: " + number + ". Added to Galaxy Map.");

                            for(int i = 0; i < number; i++){
                                galaxyMap.AddToMap(myGenerator.GeneratePlanet());
                            }
                            break;
                    case 3:
                            galaxyMap.PrintCurrentPlanetResources();
                            Console.WriteLine("Select resource to gather: ");
                            
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine();
                            Console.WriteLine(" -1-   Food                  ");
                            Console.WriteLine(" -2-   Hydrogen              ");
                            Console.WriteLine(" -3-   Iron                  ");
                            Console.WriteLine(" -4-   Oxygen                ");
                            Console.WriteLine(" -5-   Silicon               ");
                            Console.WriteLine(" -6-   Gold                  ");
                            Console.WriteLine(" -7-   Never mind, return    ");
                            Console.WriteLine();
                            Console.ResetColor();

                            Console.WriteLine("Enter number: ");
                            choice = Convert.ToInt32(Console.ReadLine());
                            
                            switch(choice){
                                case 1:
                                        Console.WriteLine("How much: ");
                                        amount = Convert.ToInt32(Console.ReadLine());

                                        if(!food.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much food.");
                                                Console.WriteLine("Food in cargo: " + food.GetVolume() + "/" + food.GetMaxCapacity());
                                            }
                                        else if(!galaxyMap.DecreaseFood(galaxyMap.GetCurrentPlanetIndex(), amount)){
                                            Console.WriteLine("Not enough food on current planet");
                                            Console.WriteLine("Food on current planet: " + galaxyMap.GetFood(galaxyMap.GetCurrentPlanetIndex()));
                                        }
                                        else{
                                            food.Volume += amount;
                                            Console.WriteLine("Successfully gathered " + amount + " of food from current planet");
                                        }
                                        break;
                                case 2:
                                        Console.WriteLine("How much: ");
                                        amount = Convert.ToInt32(Console.ReadLine());

                                        if(!hydrogen.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much hydrogen.");
                                                Console.WriteLine("Hydrogen in cargo: " + hydrogen.GetVolume() + "/" + hydrogen.GetMaxCapacity());
                                            }
                                        else if(!galaxyMap.DecreaseHydrogen(galaxyMap.GetCurrentPlanetIndex(), amount)){
                                            Console.WriteLine("Not enough hydrogen on current planet");
                                            Console.WriteLine("Hydrogen on current planet: " + galaxyMap.GetHydrogen(galaxyMap.GetCurrentPlanetIndex()));
                                        }
                                        else{
                                            hydrogen.Volume += amount;
                                            Console.WriteLine("Successfully gathered " + amount + " of hydrogen from current planet");
                                        }
                                        break;
                                case 3:
                                        Console.WriteLine("How much: ");
                                        amount = Convert.ToInt32(Console.ReadLine());

                                        if(!iron.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much iron.");
                                                Console.WriteLine("Iron in cargo: " + iron.GetVolume() + "/" + iron.GetMaxCapacity());
                                            }
                                        else if(!galaxyMap.DecreaseIron(galaxyMap.GetCurrentPlanetIndex(), amount)){
                                            Console.WriteLine("Not enough iron on current planet");
                                            Console.WriteLine("Iron on current planet: " + galaxyMap.GetIron(galaxyMap.GetCurrentPlanetIndex()));
                                        }
                                        else{
                                            iron.Volume += amount;
                                            Console.WriteLine("Successfully gathered " + amount + " of iron from current planet");
                                        }
                                        break;

                                case 4:
                                        Console.WriteLine("How much: ");
                                        amount = Convert.ToInt32(Console.ReadLine());

                                        if(!oxygen.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much oxygen.");
                                                Console.WriteLine("Oxygen in cargo: " + oxygen.GetVolume() + "/" + oxygen.GetMaxCapacity());
                                            }
                                        else if(!galaxyMap.DecreaseOxygen(galaxyMap.GetCurrentPlanetIndex(), amount)){
                                            Console.WriteLine("Not enough oxygen on current planet");
                                            Console.WriteLine("Oxygen on current planet: " + galaxyMap.GetOxygen(galaxyMap.GetCurrentPlanetIndex()));
                                        }
                                        else{
                                            oxygen.Volume += amount;
                                            Console.WriteLine("Successfully gathered " + amount + " of oxygen from current planet");
                                        }
                                        break;

                                case 5:
                                        Console.WriteLine("How much: ");
                                        amount = Convert.ToInt32(Console.ReadLine());

                                        if(!silicon.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much silicon.");
                                                Console.WriteLine("Silicon in cargo: " + silicon.GetVolume() + "/" + silicon.GetMaxCapacity());
                                            }
                                        else if(!galaxyMap.DecreaseSilicon(galaxyMap.GetCurrentPlanetIndex(), amount)){
                                            Console.WriteLine("Not enough silicon on current planet");
                                            Console.WriteLine("Silicon on current planet: " + galaxyMap.GetSilicon(galaxyMap.GetCurrentPlanetIndex()));
                                        }
                                        else{
                                            silicon.Volume += amount;
                                            Console.WriteLine("Successfully gathered " + amount + " of silicon from current planet");
                                        }
                                        break;

                                case 6:
                                        Console.WriteLine("How much: ");
                                        amount = Convert.ToInt32(Console.ReadLine());

                                        if(!gold.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much gold.");
                                                Console.WriteLine("Gold in cargo: " + gold.GetVolume() + "/" + gold.GetMaxCapacity());
                                            }
                                        else if(!galaxyMap.DecreaseGold(galaxyMap.GetCurrentPlanetIndex(), amount)){
                                            Console.WriteLine("Not enough gold on current planet");
                                            Console.WriteLine("Gold on current planet: " + galaxyMap.GetGold(galaxyMap.GetCurrentPlanetIndex()));
                                        }
                                        else{
                                            gold.Volume += amount;
                                            Console.WriteLine("Successfully gathered " + amount + " of gold from current planet");
                                        }
                                        break;

                                case 7:
                                        //Current menu exit
                                        break;
                            }
                            break;
                    case 4:
                            Console.WriteLine("What would you like to upgrade?");
                            computer.PrintShipStatistics();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine();
                            Console.WriteLine(" -1-   Attack  (uses oxygen, food and silicon)   ");
                            Console.WriteLine(" -2-   Defense (uses oxygen, food and iron)      ");
                            Console.WriteLine(" -3-   Never mind, return                        ");
                            Console.WriteLine();
                            Console.ResetColor();

                            Console.WriteLine("Enter number: ");
                            choice = Convert.ToInt32(Console.ReadLine());

                            switch(choice){
                                    case 1:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());

                                            if(!computer.CraftAttackUpgrade(amount)){
                                                Console.WriteLine("Not enough oxygen, food or silicon to craft this upgrade");
                                            }
                                            else{
                                                Console.WriteLine("Successfully crafted desired attack upgrade");
                                            }
                                            break;
                                    case 2:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());

                                            if(!computer.CraftDefenseUpgrade(amount)){
                                                Console.WriteLine("Not enough oxygen, food or iron to craft this upgrade");
                                            }
                                            else{
                                                Console.WriteLine("Successfully crafted desired defense upgrade");
                                            }
                                            break;
                                    case 3:
                                            //Current menu exit
                                            break; 
                                }
                            break;
                    case 5:
                            Console.WriteLine("What would you like to downgrade?");
                            computer.PrintShipStatistics();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine();
                            Console.WriteLine(" -1-   Attack  (uses oxygen and food, recovers silicon)   ");
                            Console.WriteLine(" -2-   Defense (uses oxygen and food, recovers iron)      ");
                            Console.WriteLine(" -3-   Never mind, return                                 ");
                            Console.WriteLine();
                            Console.ResetColor();

                            Console.WriteLine("Enter number: ");
                            choice = Convert.ToInt32(Console.ReadLine());

                            switch(choice){
                                    case 1:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());

                                            if(!computer.DismantleAttackUpgrade(amount)){
                                                Console.WriteLine("Not enough oxygen or food perform this downgrade");
                                            }
                                            else{
                                                Console.WriteLine("Successfully downgraded attack and recovered silicon");
                                            }
                                            break;
                                    case 2:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());

                                            if(!computer.DismantleDefenseUpgrade(amount)){
                                                Console.WriteLine("Not enough oxygen or food to craft this upgrade");
                                            }
                                            else{
                                                Console.WriteLine("Successfully downgraded defense and recovered iron");
                                            }
                                            break;
                                    case 3:
                                            //Current menu exit
                                            break; 
                                }
                            break;
                    case 6:
                            Console.WriteLine();
                            galaxyMap.PrintMap();
                            break;
                    case 7:
                            Console.WriteLine();
                            galaxyMap.PrintCurrentPlanet();
                            break;
                    case 8:
                            Console.WriteLine();
                            galaxyMap.PrintCoordinatesList();
                            break;
                    case 9:
                            Console.WriteLine();
                            computer.PrintShipCargo();
                            break;
                    case 10:
                            Console.WriteLine();

                            totalWeight = baseWeight;
                            foreach(IAttributes item in cargo) totalWeight += item.Weight;
                            Console.WriteLine("Current ship weight: " + totalWeight);

                            computer.PrintShipStatistics();
                            propulsion.PrintPropulsionStats();
                            break;
                    case 11:
                            if(!galaxyMap.CurrentPlanetHasSpacePort()){
                                Console.WriteLine("There is no Space Port on current planet");
                                break;
                            }
                            else{
                                Console.WriteLine("Welcome to Space Port at " + galaxyMap.GetName(galaxyMap.GetCurrentPlanetIndex()));
                                Console.WriteLine("What would you like to buy?");

                                DisplayShopMenu();

                                Console.WriteLine("Enter number: ");
                                choice = Convert.ToInt32(Console.ReadLine());

                                switch(choice){
                                    case 1:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());
                                            if(!energy.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much energy.");
                                                Console.WriteLine("Energy in cargo: " + energy.GetVolume() + "/" + energy.GetMaxCapacity());
                                                //Console.WriteLine("Energy max capacity: " + energy.GetMaxCapacity());
                                            }
                                            else if(energy.BuyGetCost(amount) > gold.GetVolume()){
                                                Console.WriteLine("Not enough gold to buy this much energy");
                                                Console.WriteLine("Required gold: " + energy.BuyGetCost(amount) + " Gold in cargo: " + gold.GetVolume());
                                            }
                                            else{
                                                energy.Volume += amount;
                                                gold.Volume -= energy.BuyGetCost(amount);
                                                Console.WriteLine("Successfully bought " + amount + " of energy for " + energy.BuyGetCost(amount) + " Gold");
                                            }
                                            break;
                                    case 2:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());
                                            if(!food.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much food.");
                                                Console.WriteLine("Food in cargo: " + food.GetVolume() + "/" + food.GetMaxCapacity());
                                                //Console.WriteLine("Food max capacity: " + food.GetMaxCapacity());
                                            }
                                            else if(food.BuyGetCost(amount) > gold.GetVolume()){
                                                Console.WriteLine("Not enough gold to buy this much food");
                                                Console.WriteLine("Required gold: " + food.BuyGetCost(amount) + " Gold in cargo: " + gold.GetVolume());
                                            }
                                            else{
                                                food.Volume += amount;
                                                gold.Volume -= food.BuyGetCost(amount);
                                                Console.WriteLine("Successfully bought " + amount + " of food for " + food.BuyGetCost(amount) + " Gold");
                                            }
                                            break;
                                    case 3:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());
                                            if(!hydrogen.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much hydrogen.");
                                                Console.WriteLine("Hydrogen in cargo: " + hydrogen.GetVolume() + "/" + hydrogen.GetMaxCapacity());
                                                //Console.WriteLine("Hydrogen max capacity: " + hydrogen.GetMaxCapacity());
                                            }
                                            else if(hydrogen.BuyGetCost(amount) > gold.GetVolume()){
                                                Console.WriteLine("Not enough gold to buy this much hydrogen");
                                                Console.WriteLine("Required gold: " + hydrogen.BuyGetCost(amount) + " Gold in cargo: " + gold.GetVolume());
                                            }
                                            else{
                                                hydrogen.Volume += amount;
                                                gold.Volume -= hydrogen.BuyGetCost(amount);
                                                Console.WriteLine("Successfully bought " + amount + " of hydrogen for " + hydrogen.BuyGetCost(amount) + " Gold");
                                            }
                                            break;
                                    case 4:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());
                                            if(!iron.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much iron.");
                                                Console.WriteLine("Iron in cargo: " + iron.GetVolume() + "/" + iron.GetMaxCapacity());
                                                //Console.WriteLine("Iron max capacity: " + iron.GetMaxCapacity());
                                            }
                                            else if(iron.BuyGetCost(amount) > gold.GetVolume()){
                                                Console.WriteLine("Not enough gold to buy this much hydrogen");
                                                Console.WriteLine("Required gold: " + iron.BuyGetCost(amount) + " Gold in cargo: " + gold.GetVolume());
                                            }
                                            else{
                                                iron.Volume += amount;
                                                gold.Volume -= iron.BuyGetCost(amount);
                                                Console.WriteLine("Successfully bought " + amount + " of iron for " + iron.BuyGetCost(amount) + " Gold");
                                            }
                                            break;
                                    case 5:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());
                                            if(!oxygen.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much oxygen.");
                                                Console.WriteLine("Oxygen in cargo: " + oxygen.GetVolume() + "/" + oxygen.GetMaxCapacity());
                                                //Console.WriteLine("Oxygen max capacity: " + oxygen.GetMaxCapacity());
                                            }
                                            else if(oxygen.BuyGetCost(amount) > gold.GetVolume()){
                                                Console.WriteLine("Not enough gold to buy this much oxygen");
                                                Console.WriteLine("Required gold: " + oxygen.BuyGetCost(amount) + " Gold in cargo: " + gold.GetVolume());
                                            }
                                            else{
                                                oxygen.Volume += amount;
                                                gold.Volume -= oxygen.BuyGetCost(amount);
                                                Console.WriteLine("Successfully bought " + amount + " of oxygen for " + oxygen.BuyGetCost(amount) + " Gold");
                                            }
                                            break;
                                    case 6:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());
                                            if(!silicon.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much silicon.");
                                                Console.WriteLine("Silicon in cargo: " + silicon.GetVolume() + "/" + silicon.GetMaxCapacity());
                                                //Console.WriteLine("Silicon max capacity: " + silicon.GetMaxCapacity());
                                            }
                                            else if(silicon.BuyGetCost(amount) > gold.GetVolume()){
                                                Console.WriteLine("Not enough gold to buy this much silicon");
                                                Console.WriteLine("Required gold: " + silicon.BuyGetCost(amount) + " Gold in cargo: " + gold.GetVolume());
                                            }
                                            else{
                                                silicon.Volume += amount;
                                                gold.Volume -= silicon.BuyGetCost(amount);
                                                Console.WriteLine("Successfully bought " + amount + " of silicon for " + silicon.BuyGetCost(amount) + " Gold");
                                            }
                                            break;
                                    case 7:
                                            //Current menu exit
                                            break;
                                }
                            }
                            break;
                    case 12:
                            if(!galaxyMap.CurrentPlanetHasSpacePort()){
                                Console.WriteLine("There is no Space Port on current planet");
                                break;
                            }
                            else{
                                Console.WriteLine("Welcome to Space Port at " + galaxyMap.GetName(galaxyMap.GetCurrentPlanetIndex()));
                                Console.WriteLine("What would you like to sell?");

                                DisplayShopMenu();

                                Console.WriteLine("Enter number: ");
                                choice = Convert.ToInt32(Console.ReadLine());

                                switch(choice){
                                    case 1:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());
                                            if(!energy.DecreaseCheck(amount)){
                                                Console.WriteLine("Not enough energy in storage");
                                                Console.WriteLine("Energy in cargo: " + energy.GetVolume());
                                            }
                                            else if(!gold.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much gold.");
                                                Console.WriteLine("Gold in cargo: " + gold.GetVolume() + "/" + gold.GetMaxCapacity());
                                                //Console.WriteLine("Gold max capacity: " + gold.GetMaxCapacity());
                                                Console.WriteLine("Price for selling: " + energy.SellGetCost(amount));
                                            }
                                            else{
                                                energy.Volume -= amount;
                                                gold.Volume += energy.SellGetCost(amount);
                                                Console.WriteLine("Successfully sold " + amount + " of energy for " + energy.SellGetCost(amount) + " Gold");
                                            }
                                            break;
                                    case 2:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());
                                            if(!food.DecreaseCheck(amount)){
                                                Console.WriteLine("Not enough food in storage");
                                                Console.WriteLine("Food in cargo: " + food.GetVolume());
                                            }
                                            else if(!gold.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much gold.");
                                                Console.WriteLine("Gold in cargo: " + gold.GetVolume() + "/" + gold.GetMaxCapacity());
                                                //Console.WriteLine("Gold max capacity: " + gold.GetMaxCapacity());
                                                Console.WriteLine("Price for selling: " + food.SellGetCost(amount));
                                            }
                                            else{
                                                food.Volume -= amount;
                                                gold.Volume += food.SellGetCost(amount);
                                                Console.WriteLine("Successfully sold " + amount + " of food for " + food.SellGetCost(amount) + " Gold");
                                            }
                                            break;
                                    case 3:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());
                                            if(!hydrogen.DecreaseCheck(amount)){
                                                Console.WriteLine("Not enough hydrogen in storage");
                                                Console.WriteLine("Hydrogen in cargo: " + hydrogen.GetVolume());
                                            }
                                            else if(!gold.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much gold.");
                                                Console.WriteLine("Gold in cargo: " + gold.GetVolume()  + "/" + gold.GetMaxCapacity());
                                                //Console.WriteLine("Gold max capacity: " + gold.GetMaxCapacity());
                                                Console.WriteLine("Price for selling: " + hydrogen.SellGetCost(amount));
                                            }
                                            else{
                                                hydrogen.Volume -= amount;
                                                gold.Volume += hydrogen.SellGetCost(amount);
                                                Console.WriteLine("Successfully sold " + amount + " of hydrogen for " + hydrogen.SellGetCost(amount) + " Gold");
                                            }
                                            break;
                                    case 4:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());
                                            if(!iron.DecreaseCheck(amount)){
                                                Console.WriteLine("Not enough iron in storage");
                                                Console.WriteLine("Iron in cargo: " + iron.GetVolume());
                                            }
                                            else if(!gold.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much gold.");
                                                Console.WriteLine("Gold in cargo: " + gold.GetVolume() + "/" + gold.GetMaxCapacity());
                                                //Console.WriteLine("Gold max capacity: " + gold.GetMaxCapacity());
                                                Console.WriteLine("Price for selling: " + iron.SellGetCost(amount));
                                            }
                                            else{
                                                iron.Volume -= amount;
                                                gold.Volume += iron.SellGetCost(amount);
                                                Console.WriteLine("Successfully sold " + amount + " of iron for " + iron.SellGetCost(amount) + " Gold");
                                            }
                                            break;
                                    case 5:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());
                                            if(!oxygen.DecreaseCheck(amount)){
                                                Console.WriteLine("Not enough oxygen in storage");
                                                Console.WriteLine("Oxygen in cargo: " + oxygen.GetVolume());
                                            }
                                            else if(!gold.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much gold.");
                                                Console.WriteLine("Gold in cargo: " + gold.GetVolume() + "/" + gold.GetMaxCapacity());
                                                //Console.WriteLine("Gold max capacity: " + gold.GetMaxCapacity());
                                                Console.WriteLine("Price for selling: " + oxygen.SellGetCost(amount));
                                            }
                                            else{
                                                oxygen.Volume -= amount;
                                                gold.Volume += oxygen.SellGetCost(amount);
                                                Console.WriteLine("Successfully sold " + amount + " of oxygen for " + oxygen.SellGetCost(amount) + " Gold");
                                            }
                                            break;
                                    case 6:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());
                                            if(!silicon.DecreaseCheck(amount)){
                                                Console.WriteLine("Not enough silicon in storage");
                                                Console.WriteLine("Silicon in cargo: " + silicon.GetVolume());
                                            }
                                            else if(!gold.IncreaseCheck(amount)){
                                                Console.WriteLine("Not enough capacity to store this much gold.");
                                                Console.WriteLine("Gold in cargo: " + gold.GetVolume() + "/" + gold.GetMaxCapacity());
                                                //Console.WriteLine("Gold max capacity: " + gold.GetMaxCapacity());
                                                Console.WriteLine("Price for selling: " + silicon.SellGetCost(amount));
                                            }
                                            else{
                                                silicon.Volume -= amount;
                                                gold.Volume += silicon.SellGetCost(amount);
                                                Console.WriteLine("Successfully sold " + amount + " of silicon for " + silicon.SellGetCost(amount) + " Gold");
                                            }
                                            break;
                                    case 7:
                                            //Current menu exit
                                            break;
                                }
                            }
                            break;
                    case 13:
                            if(!galaxyMap.CurrentPlanetHasSpacePort()){
                                Console.WriteLine("There is no Space Port on current planet");
                                break;
                            }
                            else{
                                Console.WriteLine("Welcome to Space Port at " + galaxyMap.GetName(galaxyMap.GetCurrentPlanetIndex()));
                                Console.WriteLine("What would you like to refill?");
                                
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine();
                                Console.WriteLine(" -1-   Energy                ");
                                Console.WriteLine(" -2-   Food                  ");
                                Console.WriteLine(" -3-   Hydrogen              ");
                                Console.WriteLine(" -4-   Iron                  ");
                                Console.WriteLine(" -5-   Oxygen                ");
                                Console.WriteLine(" -6-   Silicon               ");
                                Console.WriteLine(" -7-   Waste (dispose)       ");
                                Console.WriteLine(" -8-   Never mind, return    ");
                                Console.WriteLine();
                                Console.ResetColor();

                                Console.WriteLine("Enter number: ");
                                choice = Convert.ToInt32(Console.ReadLine());

                                switch(choice){
                                    case 1:
                                            if(energy.RefillGetCost() > gold.GetVolume()){
                                                Console.WriteLine("Not enough gold to buy this much energy");
                                                Console.WriteLine("Required gold: " + energy.RefillGetCost() + " Gold in cargo: " + gold.GetVolume());
                                            }
                                            else{
                                                Console.WriteLine("Successfully refilled energy for " + energy.RefillGetCost() + " Gold");
                                                gold.Volume -= energy.RefillGetCost();
                                                energy.Volume = energy.GetMaxCapacity();
                                            }
                                            break;
                                    case 2:
                                            if(food.RefillGetCost() > gold.GetVolume()){
                                                Console.WriteLine("Not enough gold to buy this much food");
                                                Console.WriteLine("Required gold: " + food.RefillGetCost() + " Gold in cargo: " + gold.GetVolume());
                                            }
                                            else{
                                                Console.WriteLine("Successfully refilled food for " + food.RefillGetCost() + " Gold");
                                                gold.Volume -= food.RefillGetCost();
                                                food.Volume = food.GetMaxCapacity();
                                            }
                                            break;
                                    case 3:
                                            if(hydrogen.RefillGetCost() > gold.GetVolume()){
                                                Console.WriteLine("Not enough gold to buy this much hydrogen");
                                                Console.WriteLine("Required gold: " + hydrogen.RefillGetCost() + " Gold in cargo: " + gold.GetVolume());
                                            }
                                            else{
                                                Console.WriteLine("Successfully refilled hydrogen for " + hydrogen.RefillGetCost() + " Gold");
                                                gold.Volume -= hydrogen.RefillGetCost();
                                                hydrogen.Volume = hydrogen.GetMaxCapacity();
                                            }
                                            break;
                                    case 4:
                                            if(iron.RefillGetCost() > gold.GetVolume()){
                                                Console.WriteLine("Not enough gold to buy this much iron");
                                                Console.WriteLine("Required gold: " + iron.RefillGetCost() + " Gold in cargo: " + gold.GetVolume());
                                            }
                                            else{
                                                Console.WriteLine("Successfully refilled iron for " + iron.RefillGetCost() + " Gold");
                                                gold.Volume -= iron.RefillGetCost();
                                                iron.Volume = iron.GetMaxCapacity();
                                            }
                                            break;
                                    case 5:
                                            if(oxygen.RefillGetCost() > gold.GetVolume()){
                                                Console.WriteLine("Not enough gold to buy this much oxygen");
                                                Console.WriteLine("Required gold: " + oxygen.RefillGetCost() + " Gold in cargo: " + gold.GetVolume());
                                            }
                                            else{
                                                Console.WriteLine("Successfully refilled oxygen for " + oxygen.RefillGetCost() + " Gold");
                                                gold.Volume -= oxygen.RefillGetCost();
                                                oxygen.Volume = oxygen.GetMaxCapacity();
                                            }
                                            break;
                                    case 6:
                                            if(silicon.RefillGetCost() > gold.GetVolume()){
                                                Console.WriteLine("Not enough gold to buy this much silicon");
                                                Console.WriteLine("Required gold: " + silicon.RefillGetCost() + " Gold in cargo: " + gold.GetVolume());
                                            }
                                            else{
                                                Console.WriteLine("Successfully refilled silicon for " + silicon.RefillGetCost() + " Gold");
                                                gold.Volume -= silicon.RefillGetCost();
                                                silicon.Volume = silicon.GetMaxCapacity();
                                            }
                                            break;
                                    case 7:
                                            if(waste.RefillGetCost() > gold.GetVolume()){
                                                Console.WriteLine("Not enough gold to dispose all waste");
                                                Console.WriteLine("Required gold: " + waste.RefillGetCost() + " Gold in cargo: " + gold.GetVolume());
                                            }
                                            else{
                                                Console.WriteLine("Successfully disposed all waste for " + waste.RefillGetCost() + " Gold");
                                                gold.Volume -= waste.RefillGetCost();
                                                waste.Volume = 0;
                                            }
                                            break;
                                    case 8:
                                           //Current menu exit
                                            break; 
                                }
                                break;  
                            }
                    case 14:
                            if(!galaxyMap.CurrentPlanetHasSpacePort()){
                                Console.WriteLine("There is no Space Port on current planet");
                                break;
                            }
                            else{
                                Console.WriteLine("Welcome to Space Port at " + galaxyMap.GetName(galaxyMap.GetCurrentPlanetIndex()));
                                Console.WriteLine("What would you like to upgrade?");
                                computer.PrintShipStatistics();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine();
                                Console.WriteLine(" -1-   Attack                ");
                                Console.WriteLine(" -2-   Defense               ");
                                Console.WriteLine(" -3-   Never mind, return    ");
                                Console.WriteLine();
                                Console.ResetColor();

                                Console.WriteLine("Enter number: ");
                                choice = Convert.ToInt32(Console.ReadLine());

                                switch(choice){
                                    case 1:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());

                                            if(attack.BuyGetCost(amount) > gold.GetVolume()){
                                                Console.WriteLine("Not enough gold to upgrade attack this much");
                                                Console.WriteLine("Required gold: " + attack.BuyGetCost(amount) + " Gold in cargo: " + gold.GetVolume());
                                            }
                                            else{
                                                attack.Upgrade(amount);
                                                gold.Volume -= attack.BuyGetCost(amount);
                                                Console.WriteLine("Successfully upgraded attack by " + amount + " points");
                                            }
                                            break;
                                    case 2:
                                            Console.WriteLine("How much: ");
                                            amount = Convert.ToInt32(Console.ReadLine());

                                            if(defense.BuyGetCost(amount) > gold.GetVolume()){
                                                Console.WriteLine("Not enough gold to upgrade defense this much");
                                                Console.WriteLine("Required gold: " + defense.BuyGetCost(amount) + " Gold in cargo: " + gold.GetVolume());
                                            }
                                            else{
                                                defense.Upgrade(amount);
                                                gold.Volume -= defense.BuyGetCost(amount);
                                                Console.WriteLine("Successfully upgraded defense by " + amount + " points");
                                            }
                                            break;
                                    case 3:
                                            //Current menu exit
                                            break; 
                                }
                                break;
                            }
                    case 15:
                            Console.WriteLine();
                            Console.WriteLine("Created by Antoni K. (402131), 06.2022");
                            break;
                    case 16:
                            Console.WriteLine("Ending simulation");
                            Environment.Exit(0);
                            break;
                    case 17:
                            SpaceFightInit();
                            break;
                }

            }

            void SpaceFightInit(){
                float _maxTime = (float)(defense.GetDefense());
                int _repeatCount = (Convert.ToInt32(20000/attack.GetAttack()));

                if (QTEHandler.RunQTE(_maxTime, _repeatCount)){
                    //Win scenario
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Your enemy has been destroyed. You won!");
                    Console.WriteLine("You recovered some materials and cargo from your enemy's shipwreck");

                    Random rand = new Random();
                    var randnum = new Random();

                    //Increase energy randomly
                    double increaseVal = randnum.Next(500, 1000);
                    if(energy.IncreaseCheck(increaseVal)){
                        Console.WriteLine("Recovered energy: " + increaseVal);
                        energy.Volume = energy.Volume + increaseVal;
                    }
                    else{
                        Console.WriteLine("Energy refilled");
                        energy.Volume = energy.GetMaxCapacity();
                    }

                    //Increase food randomly
                    increaseVal = randnum.Next(500, 1000);
                    if(food.IncreaseCheck(increaseVal)){
                        Console.WriteLine("Recovered food: " + increaseVal);
                        food.Volume = food.Volume + increaseVal;
                    }
                    else{
                        Console.WriteLine("Food refilled");
                        food.Volume = food.GetMaxCapacity();
                    }

                    //Increase gold randomly
                    increaseVal = randnum.Next(500, 1000);
                    if(gold.IncreaseCheck(increaseVal)){
                        Console.WriteLine("Recovered gold: " + increaseVal);
                        gold.Volume = gold.Volume + increaseVal;
                    }
                    else{
                        Console.WriteLine("Gold refilled");
                        gold.Volume = gold.GetMaxCapacity();
                    }

                    //Increase hydrogen randomly
                    increaseVal = randnum.Next(500, 1000);
                    if(hydrogen.IncreaseCheck(increaseVal)){
                        Console.WriteLine("Recovered hydrogen: " + increaseVal);
                        hydrogen.Volume = hydrogen.Volume + increaseVal;
                    }
                    else{
                        Console.WriteLine("Hydrogen refilled");
                        hydrogen.Volume = hydrogen.GetMaxCapacity();
                    }

                    //Increase iron randomly
                    increaseVal = randnum.Next(500, 1000);
                    if(iron.IncreaseCheck(increaseVal)){
                        Console.WriteLine("Recovered iron: " + increaseVal);
                        iron.Volume = iron.Volume + increaseVal;
                    }
                    else{
                        Console.WriteLine("Iron refilled");
                        iron.Volume = iron.GetMaxCapacity();
                    }

                    //Increase silicon randomly
                    increaseVal = randnum.Next(500, 1000);
                    if(silicon.IncreaseCheck(increaseVal)){
                        Console.WriteLine("Recovered silicon: " + increaseVal);
                        silicon.Volume = silicon.Volume + increaseVal;
                    }
                    else{
                        Console.WriteLine("Silicon refilled");
                        silicon.Volume = silicon.GetMaxCapacity();
                    }

                }
                else{
                    //Lose scenario
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("You lost the battle");
                    
                    if(QTEInterface.RandomBoolPercentage(50, 100)){ //50% chance for escape
                        Console.WriteLine("but managed to escape.");
                        Console.WriteLine("You arrived at your destination, but your enemy took most of your cargo and heavily damaged your ship.");
                        Console.WriteLine();
                        attack.SetAttack(attack.GetAttack() * 0.2);
                        defense.SetDefense(defense.GetDefense() * 0.2);
                        energy.Volume = energy.Volume * 0.5;
                        food.Volume = food.Volume * 0.2;
                        gold.Volume = 0.0;
                        hydrogen.Volume = hydrogen.Volume * 0.5;
                        iron.Volume = iron.Volume * 0.2;
                        silicon.Volume = silicon.Volume * 0.5;
                        Console.WriteLine("Defense and attack reduced by 80%");
                        Console.WriteLine("Energy supply reduced by 50%");
                        Console.WriteLine("Food supply reduced by 80%");
                        Console.WriteLine("All gold lost");
                        Console.WriteLine("Hydrogen supply reduced by 50%");
                        Console.WriteLine("Iron supply reduced by 80%");
                        Console.WriteLine("Silicon supply reduced by 50%");
                        Console.WriteLine();

                    }
                    else{
                        Console.WriteLine("and your ship got destroyed");
                        Console.WriteLine("End of simulation.");
                        Environment.Exit(0);
                    }
                }
            }

        }

    }

}