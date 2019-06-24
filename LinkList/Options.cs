using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkList
{
    public static class Option
    {
        private const string I = "Insert New Node";
        private const string D = "Delete Node";
        private const string Di = "Display Nodes for this List";
        private const string E = "Exit from List";
        private const string G = "Go Back";

        public static void OptionList() => Console.WriteLine(
             " 1  --  Normal List\n"
            +" 2  --  Circular List\n"
            +" 3  --  TwoWay List\n"
            +" 4  --  " + E + '\n'
            );
        public static void OptionsCommon() => Console.WriteLine(
              " 1  --  " + I + '\n'
            + " 2  --  " + D + '\n'
            + " 3  --  " + Di + '\n'
            + " 4  --  " + E + '\n'
            );
        public static void InsertTwoWay() => Console.WriteLine(
                                  "1  --  " + I + " (in the front of List)\n"
                                + "2  --  " + I + " (in the end of List)\n"
                                + "3  --  " + I + " After _____\n"
                                + "4  --  " + I + " Before _____\n"
                                + "5  --  " + G + " \n");
        public static void DeleteTwoWay() => Console.WriteLine(
                                  "1  --  " + D + " (first)\n"
                                + "2  --  " + D + " (last)\n"
                                + "3  --  " + D + " (known Data) \n"
                                + "4  --  " + G + " \n");
        public static void InsertCircular() => Console.WriteLine(
                                  "1  --  " + I + " \n"
                                + "2  --  " + I + " After _____\n"
                                + "3  --  " + G + " \n");
        public static void DeleteCircular() => Console.WriteLine(
                                  "1  --  " + D + " (any)\n"
                                + "2  --  " + D + " (known Data) \n"
                                + "3  --  " + G + " \n");
        public static void InsertNormal() => Console.WriteLine(
                                  "1  --  " + I + " (in the front of List)\n"
                                + "2  --  " + I + " (in the end of List)\n"
                                + "3  --  " + I + " After _____\n"
                                + "4  --  " + G + " \n");
        public static void DeleteNormal() => Console.WriteLine(
                                  "1  --  " + D + " (first)\n"
                                + "2  --  " + D + " (last)\n"
                                + "3  --  " + D + " (known Data) \n"
                                + "4  --  " + G + " \n");                            
    }
}
