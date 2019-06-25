using System;
using System.Collections.Generic;
using System.Text;

namespace LinkList
{
    class CircularNode : INode
    {
        private CircularNode next;
        private string info;

        public CircularNode()
        {
            next = null;
            info = "";
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
            do
            {
                ii = Console.ReadLine();
            } while (ii == "");
            if (info == "")
            {
                Console.WriteLine("No Data present in the List..\n DATA NOT INSERTED");
                Console.ReadKey();
            }
            else
            {
                CircularNode newNode = new CircularNode
                {
                    info = ii
                };
                CircularNode current = this.next;
                Console.Write("\nAfter which Data You want to Store : ");
                String cmp = Console.ReadLine();
                bool CMP = new bool();
                while ((current != this) && (CMP = current.info.ToLower().Equals(cmp.ToLower()) == false))
                {
                    current = current.next;
                }
                if (current == this && CMP == false)
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
                next = this;
            }
            else
            {
                CircularNode newNode = new CircularNode
                {
                    info = ii
                };
                CircularNode current = this;
                while (current.next != this)
                {
                    current = current.next;
                }
                current.next = newNode;
                newNode.next = this;
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
                next = this;
            }
            else
            {
                CircularNode newNode = new CircularNode
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
                CircularNode current = this;
                CircularNode parent = null;
                while (current.next != this)
                {
                    parent = current;
                    current = current.next;
                }
                if (parent == null)
                {
                    this.DeleteFirst();
                }
                else
                {
                    parent.next = this;
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
                CircularNode current = this.next;
                if (current == this)
                {
                    this.info = "";
                    this.next = null;
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
                CircularNode current = this.next;
                CircularNode parent = this;
                Console.Write("\nWhich Data You want to Delete : ");
                String cmp = Console.ReadLine();
                while ((current != this) && (current.info.ToLower().Equals(cmp.ToLower()) == false))
                {
                    parent = current;
                    current = current.next;
                }
                if (current == this && (current.info.ToLower().Equals(cmp.ToLower()) == true))
                {
                    DeleteFirst();
                }
                else if(current == this)
                {
                    Console.WriteLine($"{cmp} Not Present..\n Deletition couldn't be performed");
                    Console.ReadKey();
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
            CircularNode current = this;
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
                } while (current != this);
                Console.WriteLine("\n");
            }
        }
    }
}
