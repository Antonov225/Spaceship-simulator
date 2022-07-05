using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.Diagnostics;

namespace Project{

    public class QTEHandler{

        static Random rng = new Random();

        private static List<ConsoleKey> keys = new List<ConsoleKey>(){
                ConsoleKey.A,
                ConsoleKey.B,
                ConsoleKey.C,
                ConsoleKey.D,
                ConsoleKey.E,
                ConsoleKey.F,
                ConsoleKey.G,
                ConsoleKey.H,
                ConsoleKey.I,
                ConsoleKey.J,
                ConsoleKey.K,
                ConsoleKey.L,
                ConsoleKey.M,
                ConsoleKey.N,
                ConsoleKey.O,
                ConsoleKey.P,
                ConsoleKey.R,
                ConsoleKey.S,
                ConsoleKey.T,
                ConsoleKey.U,
                ConsoleKey.V,
                ConsoleKey.W,
                ConsoleKey.X,
                ConsoleKey.Y,
                ConsoleKey.Z
            };

        public static bool RunQTE(float maxTime, int repeatCount){
           
            Console.WriteLine();
            Console.WriteLine("Press displayed keys to fight!");
            Console.WriteLine("Difficulty level of this fight will depend on your ship statistics");
            Console.WriteLine("You have: " + (maxTime/1000) + " secends to press each key and " + repeatCount + " keys to press.");
            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();

            bool succeded = true;
            Stopwatch stopWatch = new Stopwatch();

            for (int i = 0; i < repeatCount; i++){

                ConsoleKey keyToPress = keys[rng.Next(keys.Count)]; //Select random key

                bool keyPressed = false;
                bool correctPress = false;

                QTEInterface.PrintQTE(keyToPress);
                stopWatch.Start();
                
                //This loop will work untill any key press or untill time ends
                while (stopWatch.ElapsedMilliseconds < maxTime){
                    
                    if (Console.KeyAvailable){ //Wait for key press
                    
                        ConsoleKey readedKey = Console.ReadKey().Key;
                        if (readedKey.Equals(keyToPress)){

                            keyPressed = true;
                            correctPress = true;
                            break;
                        }
                        else{
                            
                            keyPressed = true;
                            correctPress = false;
                            break;
                        }
                    }
                }
                if (keyPressed == false || correctPress == false){   //Check game result
                    succeded = false;
                }

                //Reset everything
                stopWatch.Stop();
                stopWatch.Reset();
                QTEInterface.ClearQTE();
            }
            return succeded;

        }
    }
}