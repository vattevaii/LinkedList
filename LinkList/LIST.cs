using System;
using System.Collections.Generic;
using System.Text;

namespace LinkList
{
    public class LIST
    {
        public int index;
        private LIST next;
        private string type;
        private INode head = null;


        public LIST(int i = 0, LIST nxt = null)
        {
            index = i;
            next = nxt;
            type = "";
        }
        // New List
        public static void PutAnotherList(LIST index, int i)
        {
            LIST newList = new LIST(i);
            index.next = newList;
        }
        public static LIST GetMaxList(LIST ll)
        {
            LIST current = ll;
            while (current.next != null)
            {
                current = current.next;
            }
            return current;
        }


        public LIST GetNext()
        {
            return this.next;
        }

        public static void DisplayList(LIST ll)
        {
            Console.WriteLine($"List Number {ll.index + 1}\n");
        }

        public void DeleteNext(ref LIST deleted)
        {
            this.next = deleted.next;
            deleted = null;
        }

        public void LoadList()
        {
            bool b = new bool();
            if (type == "")
            {
                do
                {
                    const string C = " Please Insert Valid Choice\n";
                    b = true;
                    Console.Clear();
                    Option.OptionList();
                    Console.Write("Which List Do you Want To make\n?"); 
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            {
                                type = "Normal";
                                head = new NormalNode();
                                break;
                            }
                        case "2":
                            {
                                type = "Circular";
                                head = new CircularNode();
                                break;
                            }
                        case "3":
                            {
                                type = "TwoWay";
                                head = new TwoWayNode();
                                break;
                            }
                        case "4":
                            break;
                        default:
                            b = false;
                            Console.WriteLine(C);
                            break;
                    }
                } while (!b);
            }
            if (type != "")
            {
                do
                {
                    const string C = " Please Insert Valid Choice\n";
                    b = true;
                    Console.Clear();
                    Console.WriteLine($"List {index + 1} Loaded.  Type : {type} LinkedList\n");
                    Option.OptionsCommon();
                    Console.Write("Your Choice : ");
                    string choice = Console.ReadLine();
                    Console.WriteLine("\n");
                    switch (choice)
                    {
                        case "1":
                            head.InsertNodes();
                            break;
                        case "2":
                            head.DeleteNodes();
                            break;
                        case "3":
                            head.DisplayNodes();
                            break;
                        case "4":
                            b = false;
                            break;
                        default:
                            Console.WriteLine(C);
                            Console.ReadKey();
                            break;
                    }
                } while (b); 
            }
        }

    }
}
