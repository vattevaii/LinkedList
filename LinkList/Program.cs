using System;

namespace LinkList
{
    class Program
    {
        static void Main()
        {
            LIST list = null;
            bool b;
            do
            {
                b = true;
                Console.Clear();
                const string A = " 1 -- New List\n";
                const string B = " 2 -- Display List\n";
                const string E = " 3 -- Delete List\n";
                const string F = " 4 -- Go To A List\n";
                const string M = " 5 -- Merge Two Lists\n";
                const string C = " 6 -- Exit\n";
                const string D = " Please Insert Valid Choice\n";
                // TODO   Merge 2 Similar types of List  in main 
                Console.WriteLine(A+B+E+F+M+C);
                Console.Write("Your Choice : ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        int dex = CreateList(ref list);
                        Console.WriteLine($"List {dex} Created.");
                        break;
                    case "2":
                        int count = 0;
                        DisplayList(list, "",ref count);
                        if(count != 0)System.Console.WriteLine();
                        count = 0;
                        DisplayList(list, "Normal",ref count);
                        if(count != 0)System.Console.WriteLine();
                        count = 0;
                        DisplayList(list, "Circular", ref count);
                        if(count != 0)System.Console.WriteLine();
                        count = 0;
                        DisplayList(list, "TwoWay", ref count);
                        break;
                    case "3":
                        DeleteList(ref list);
                        break;
                    case "4":
                        LoadNodes(ref list);
                        break;
                    case "5":
                        MergeLists(ref list);
                        break;
                    case "6":
                        b = false;
                        break;
                    default:
                        Console.WriteLine(D);
                        break;
                }
                Console.ReadKey();
            } while (b);

        }

        /// <summary>
        /// Valid Input indicates a number which is not less than 1
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private static int ValidInput(string a)
        {
            int input;
            bool tries = true;
            do
            {
                if (tries == false)
                    Console.WriteLine("Please Enter Valid Number\n");
                Console.Write(a);
                string s = Console.ReadLine();

                if (!int.TryParse(s, out input))
                {
                    tries = false;
                }
                else
                {
                    tries = true;
                }
                input--;
                //input of less than 0
                if (input < 0)
                {
                    Console.WriteLine("Invalid List");
                    tries = false;
                }
            } while (tries == false);
            return input;
        }
        /// <summary>
        /// Load a single List
        /// upto line 118
        /// </summary>
        /// <param name="list"></param>
        private static void LoadNodes(ref LIST list)
        {
            //No Lists
            if(list == null)
            {
                Console.WriteLine("Please Create A List Before Loading Them\n");
            }

            else
            {
                //Get valid Input
                const string A = "Which List do You Want to Load\n?";
                int input = ValidInput(A);
                
                LIST l = list;
                while ((l != null) && (l.index != input))
                {
                    l = l.GetNext();
                }
                // Not found
                if (l == null)
                {
                    Console.WriteLine($"List {input + 1} not found in the Created Lists");
                }
                //While statement run or not.. ie Node with input found
                else
                {
                    l.LoadList();
                } 
            }
        }

        /// <summary>
        /// Deletion Of A List
        /// upto Line 164
        /// </summary>
        /// <param name="ll"></param>
        private static void DeleteList(ref LIST ll)
        {
            // List is Empty
            if (ll == null)
            {
                Console.WriteLine("Create A List First");
            }
            //not Empty
            else
            {
            //Get valid Input
                const string A = "Which List Do you Want to Delete\n?";
                int input = ValidInput(A);

                //To Delete
                LIST l = ll;
                //Parent of the element to delete
                LIST p = null;

                while ((l != null) && (l.index != input))
                {
                    p = l;
                    l = l.GetNext();
                }
                // Not found
                if (l == null)
                {
                    Console.WriteLine($"List {input + 1} not found in the Created Lists");
                }
                //While statement not run.. ie First List Delete
                //First List = Second List
                else if (p == null)
                {
                    Console.WriteLine("Type : " + l.Type);
                    ll = l.GetNext();
                    //l = null;
                    Console.WriteLine($"List {input + 1} was deleted..");
                }
                //Delete Parent->next
                else
                {
                    p.DeleteNext(ref l);
                    Console.WriteLine($"List {input + 1} was deleted..");
                }
            }
        }


        /// <summary>
        /// Creation Of List ...
        /// NOTE : No data inserted
        /// </summary>
        /// <param name="ll"></param>
        public static int CreateList(ref LIST ll)
        {
            int ind; // = new int();
            if(ll == null)
            {
                ll = new LIST();
                ind = ll.index;
            }
            else
            {
                LIST index = LIST.GetMaxList(ll);
                ind = index.index + 1;
                LIST.PutAnotherList(index, ind);
            }
            return (ind+1);
        }


        /// <summary>
        /// Displaying List according to given type
        /// Not Nodes
        /// </summary>
        /// <param name="ll"></param>
        public static void DisplayList(LIST ll, string type, ref int count)
        {
            LIST next = ll;
            if (next == null)
            {
                if(type == "")
                    Console.WriteLine("NO Lists CREATED...");
            }
            else
            {
                while (next != null)
                {
                    LIST.DisplayList(next, type, ref count);
                    next = next.GetNext();
                } 
            }
        }

        /// <summary>
        /// Merging Two Similar Lists
        /// </summary>
        /// <param name="list"></param>
        private static void MergeLists(ref LIST list)
        {
            // List is Empty
            if (list == null)
            {
                Console.WriteLine("Create A List First");
                return;
            }
            int count1 = 0, count2 = 0, count3 = 0;
            DisplayList(list, "Normal", ref count1);
            DisplayList(list, "Circular", ref count2);
            DisplayList(list, "TwoWay", ref count3);
            if (count1 > 1)
            {
                Console.WriteLine(" Merge Two Normal LinkedList\n?(Y/N)");
                string opt = Console.ReadLine();
                if (opt.ToLower() == "y")
                {
                    LIST.MergeLists(ref list, "Normal");
                    return;
                }
            }
            if (count2 > 1)
            {
                Console.WriteLine(" Merge Two Circular LinkedList\n?(Y/N)");
                string opt = Console.ReadLine();
                if (opt.ToLower() == "y")
                {
                    LIST.MergeLists(ref list, "Circular");
                    return;
                }
            }
            if(count3 > 1)
            {
                Console.WriteLine(" Merge Two TwoWay LinkedList\n?(Y/N)");
                string opt = Console.ReadLine();
                if (opt.ToLower() == "y")
                {
                    LIST.MergeLists(ref list, "TwoWay");
                    return;
                }
            }
            System.Console.Write("Insufficient number of lists.\nOr,YOU DID NOT CHOOSE TO MERGE");
        }
//End Of Class PROGRAM

    }
}
