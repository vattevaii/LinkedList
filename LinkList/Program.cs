using System;

namespace LinkList
{
    class Program
    {
        static void Main(string[] args)
        {
            LIST list = null;
            bool b = new bool();
            do
            {
                b = true;
                Console.Clear();
                const string A = " 1 -- New List\n";
                const string B = " 2 -- Display List\n";
                const string E = " 3 -- Delete List\n";
                const string F = " 4 -- Go To A List\n";
                const string C = " 5 -- Exit\n";
                const string D = " Please Insert Valid Choice\n";
                Console.WriteLine(A+B+E+F+C);
                Console.Write("Your Choice : ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateList(ref list);
                        break;
                    case "2":
                        DisplayList(list);
                        break;
                    case "3":
                        DeleteList(ref list);
                        break;
                    case "4":
                        LoadNodes(ref list);
                        break;
                    case "5":
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
            int input = 0;
            bool tries = true;
            do
            {
                if (tries == false)
                    Console.WriteLine("Please Enter Valid Number\n");
                Console.Write(a);
                string s = Console.ReadLine();
                input = 0;
                tries = int.TryParse(s, out input);
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
                    ll = l.GetNext();
                    l = null;
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
        private static void CreateList(ref LIST ll)
        {
            int ind = new int();
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
            Console.WriteLine($"List {ind + 1} Created.");
        }


        /// <summary>
        /// Displaying All List
        /// Not Nodes
        /// </summary>
        /// <param name="ll"></param>
        private static void DisplayList(LIST ll)
        {
            LIST next = ll;
            if (next == null)
            {
                Console.WriteLine("NO Lists CREATED...");
            }
            else
            {
                while (next != null) 
                {
                    LIST.DisplayList(next);
                    next = next.GetNext();
                }
            }
        }      
        //End Of Class PROGRAM
    }
}
