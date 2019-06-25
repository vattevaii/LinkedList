using System;
using System.Collections.Generic;
using System.Text;

namespace LinkList
{
    class NormalNode : INode
    {
        private NormalNode next;
        private string info;

        public NormalNode()
        {
            info = "";
            next = null;
        }

        void INode.InsertNodes()
        {
            bool b;// = new bool();
            do
            {
                const string C = " Please Insert Valid Choice\n";
                b = true;
                Console.Clear();
                Option.InsertNormal();
                this.DisplayAll();
                Console.Write("Your Choice : ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        InsertFront();
                        break;
                    case "2":
                        InsertLast();
                        break;
                    case "3":
                        InsertAfter();
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

        private void InsertAfter()
        {
            Console.Write("Enter The Data You Want To Store : ");
            string ii;
            do { ii = Console.ReadLine();
            } while (ii == "");
            if (info == "")
            {
                Console.WriteLine("No Data present in the List..\n DATA NOT INSERTED");
                Console.ReadKey();
            }
            else
            {
                NormalNode newNode = new NormalNode
                {
                    info = ii
                };
                NormalNode current = this;
                Console.Write("\nAfter which Data You want to Store : ");
                String cmp = Console.ReadLine();
                while ((current != null) && (current.info.ToLower().Equals(cmp.ToLower()) == false))
                {
                    current = current.next;
                }
                if(current == null)
                {
                    Console.WriteLine($"{cmp} not found in Nodes..\n DATA NOT INSERTED");
                }
                else
                {
                    newNode.next = current.next;
                    current.next = newNode;
                }
            }
        }

        private void InsertLast()
        {
            Console.Write("Enter The Data You Want To Store : ");
            string ii;
            do
            {
                ii = Console.ReadLine();
            } while (ii == "");
            if (info == "")
            {
                info = ii;
            }
            else
            {
                NormalNode newNode = new NormalNode
                {
                    info = ii
                };
                NormalNode current = this;
                while(current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
            }
        }

        private void InsertFront()
        {
            Console.Write("Enter The Data You Want To Store : ");
            string ii;
            do
            {
                ii = Console.ReadLine();
            } while (ii == "");
            if (info == "")
            {
                info = ii;
            }
            else
            {
                NormalNode newNode = new NormalNode
                {
                    info = this.info,
                    next = this.next
                };
                this.info = ii;
                this.next = newNode;
            }
        }

        void INode.DeleteNodes()
        {
            bool b;// = new bool();
            do
            {
                const string C = " Please Insert Valid Choice\n";
                b = true;
                Console.Clear();
                Option.DeleteNormal();
                this.DisplayAll();
                Console.Write("Your Choice : ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DeleteFirst();
                        break;
                    case "2":
                        DeleteLast();
                        break;
                    case "3":
                        DeleteData();
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

        private void DeleteLast()
        {
            if (info == "")
            {
                Console.WriteLine("No Data Present To Delete..\n Deletition couldn't be performed");
                Console.ReadKey();
            }
            else
            {
                NormalNode current = this;
                NormalNode parent = null;
                while (current.next != null)
                {
                    parent = current;
                    current = current.next;
                }
                if(parent == null)
                {
                    this.DeleteFirst();
                }
                else
                {
                    parent.next = null;
                    //current = null;
                }
            }
        }

        private void DeleteFirst()
        {
            if (info == "")
            {
                Console.WriteLine("No Data Present To Delete..");
                Console.ReadKey();
            }
            else
            {
                NormalNode current = this.next;
                if(current == null)
                {
                    this.info = "";
                }
                else
                {
                    this.info = current.info;
                    this.next = current.next;
                    //current = null;
                }
            }
        }

        private void DeleteData()
        {
            if (info == "")
            {
                Console.WriteLine("No Data Present To Delete..\n Deletition couldn't be performed");
                Console.ReadKey();
            }
            else
            {
                NormalNode current = this;
                NormalNode parent = null;
                Console.Write("\nWhich Data You want to Delete : ");
                String cmp = Console.ReadLine();
                while ((current != null) && (current.info.ToLower().Equals(cmp.ToLower()) == false))
                {
                    parent = current;
                    current = current.next;
                }
                if(current == null)
                {
                    Console.WriteLine($"{cmp} Not Present..\n Deletition couldn't be performed");
                    Console.ReadKey();
                }
                else if(parent == null)
                {
                    this.DeleteFirst();
                }
                else
                {
                    parent.next = current.next;
                    //current = null;
                }
            }
        }

        void INode.DisplayNodes()
        {
            this.DisplayAll();
        }
        private void DisplayAll()
        {
            NormalNode current = this;
            Console.Write("Nodes :");
            if (info == "")
            {
                Console.WriteLine("   Empty Linear Node\n");
            }
            else
            {
                do
                {
                    Console.Write($"  {current.info}    ");
                    current = current.next;
                } while (current != null);
                Console.WriteLine("\n");
            }
        }
    }
}
