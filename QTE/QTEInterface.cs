using System;
using System.Collections.Generic;
using System.Threading;

namespace Project
{
    public class QTEInterface
    {
        //For WriteAt
        protected static int origRow;
        protected static int origCol;

        private const string emptyLine = "                                                                                ";
        private const string qteInfo = "Wciśnij klawisz: ";
        
        //Source: https://docs.microsoft.com/pl-pl/dotnet/api/system.console.setcursorposition?view=netframework-4.8
        protected static void WriteAt(string s, int x, int y){
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public static void PrintQTE(ConsoleKey keyToPress){
            Console.Clear();
            WriteAt(emptyLine, 30, 12);
            WriteAt(qteInfo, 30, 12);
            WriteAt(emptyLine, 37, 13);
            WriteAt(keyToPress.ToString(), 37, 13);
            //To set the cursor under the letter
            WriteAt(" ", 36, 14);
        }

        public static void ClearQTE(){
            WriteAt(emptyLine, 30, 12);
            WriteAt(emptyLine, 30, 13);
            WriteAt(emptyLine, 30, 14);
        }

        public static bool RandomBoolPercentage(int _percentage, int _maxVal){
            Random rnd = new Random();
            var random = new Random();
            int number = random.Next(0, _maxVal);

            if(number >= 0 && number <= _percentage){
                return true;
            }
            else{
                return false;
            }
        }

    }
}