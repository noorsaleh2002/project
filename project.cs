using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace part2_umlProject
{
     [Serializable]
    class Listing
    {
        string nameList, description;
        double price;
        int numbrOfItem;
        static int listIdCounter=0;
        int listId;
        public Listing()
            {}
        public Listing(string nameList, string description, double price, int numbrOfItem,int ID)
        {
            this.NameList = nameList;
            this.Description = description;
            this.Price = price;
            this.NumbrOfItem = numbrOfItem;
            this.listId=ID;
        }
        public Listing CreatList()
        {
            this.listId=listIdCounter;
            Console.Write("Enter List name: ");
            string name = Console.ReadLine();
            Console.Write("Enter List description: ");
            string description = Console.ReadLine();
            Console.Write("Enter the price of item : ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter number of items in your Listing: ");
            int numberOfItem = Convert.ToInt32(Console.ReadLine());
            Listing L = new Listing(name, description, price, numberOfItem,listId);
            listIdCounter++;
            return L;

        }
        public void print()
        {
            Console.WriteLine("ID: {0}",listId);
            Console.WriteLine(NameList);
            Console.WriteLine(Description);
            Console.WriteLine(Price);   
            Console.WriteLine(NumbrOfItem);
        }
        public int ListId { get => listId; set => listId = value; }
        public string NameList { get => nameList; set => nameList = value; }
        public string Description { get => description; set => description = value; }
        public double Price { get => price; set => price = value; }
        public int NumbrOfItem { get => numbrOfItem; set => numbrOfItem = value; }
   
    
    }
     [Serializable]
    class Payment
    {
        string cardNumber, pinCode, billingAdress;

        public Payment(string cardNumber, string pinCode, string billingAdress)
        {
            this.cardNumber = cardNumber;
            this.pinCode = pinCode;
            this.billingAdress = billingAdress;
        }

        public string CardNumber { get => cardNumber; set => cardNumber = value; }
        public string PinCode { get => pinCode; set => pinCode = value; }
        public string BillingAdress { get => billingAdress; set => billingAdress = value; }
    }
    [Serializable]
    class Customer
    {
        string id, name, shippingAdress, phoneNumber, passWord, paymentInfo;
        Listing[] myItems; 
        public Customer(string id, string name, string shippingAdress, string phoneNumber, string passWord, string paymentInfo)
        {
            this.Id = id;
            this.Name = name;
            this.ShippingAdress = shippingAdress;
            this.PhoneNumber = phoneNumber;
            this.PassWord = passWord;
            this.PaymentInfo = paymentInfo;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string ShippingAdress { get => shippingAdress; set => shippingAdress = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public string PaymentInfo { get => paymentInfo; set => paymentInfo = value; }
    }
    [Serializable]
    class Seller
    {
        string name, address, emai,phoneNumber,storeName,password;
        List <Listing> listItime=new List<Listing>();
        int numberOfListing = 0;
        Listing L=new Listing();
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Emai { get => emai; set => emai = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string StoreName { get => storeName; set => storeName = value; }
        public string PassWrod { get=>password; set => password = value; }  
        public void SingUp()
        {
            Console.Write("Enter your name: ");
            Name=Console.ReadLine();
            Console.Write("Enter your address: ");
            Address=Console.ReadLine();
            Console.Write("Enter your Email:  ");
            Emai=Console.ReadLine();
            Console.Write("Enter your phone number :");
            PhoneNumber=Console.ReadLine();
            Console.Write("Enter your store name: ");
            StoreName=Console.ReadLine();
            Console.Write("Enter your password: ");
            PassWrod=Console.ReadLine();
            
        }
        public  void AddingListing()
        {

            
           listItime.Add (L.CreatList());
            numberOfListing++;
            
        }
        public void DeleteListing(int ID)
        {
            int j=0;
            foreach(Listing i in listItime)
            {
                if (i.ListId==ID)
                {
                    listItime.RemoveAt(j);    
                }
                j++;
            }
                
        }
        public void print()
        {
            foreach( Listing i in listItime)
            {
                i.print();
            }    
        }
        public void ChangeListInfo(int ID)
        {
            //sreach for list
            //change info
        }
        public void ViewLists()
        {
            
        }
        public void ChangeAccountInfo()
        {
            //ask the seller what to change then change it using Proprties
        }

    }
   
   
    [Serializable]
    class System
    {
       /* List<Seller> sellerlist=new List<Seller>();
        Seller s;
        Customer c;
        FileStream fileStream ;
        BinaryFormatter formatter;
        int IDcounter = 0;*/
        
      
     
        public void Menue()
        {
                
                Console.WriteLine("1-Adding new listing:");
                Console.WriteLine("2-Delete exiting listing:");
                Console.WriteLine("3-Change info and price for existing listing(s):");
                Console.WriteLine("4-View all listings :");
                Console.WriteLine("5-View sold listings information:");
                Console.WriteLine("6-Change account information:");
                Console.WriteLine("7-log out:");
            Console.Write("What do you want to do ? ");
        }



        /*public void SaveSellersAccounts(Seller s)
        {
            FileStream fileStream = new FileStream("Sellers Accounts", FileMode.Open, FileAccess.Write);
            formatter= new BinaryFormatter();
            formatter.Serialize(fileStream, s);
            fileStream.Close();
        }*/
       
        
      


    }
    internal class Program
    {
        static void Main(string[] args)
        {

            System sys=new System();

            Console.Write("Hello there! Are you costomer or seller? ");
            //int ID=0;
            string user = Console.ReadLine();

            if (user == "seller")
            {
                Console.Write("Are you new here? or you want tolog in ?(log in /sign up)");
                string answer = Console.ReadLine();
                if (answer== "log in")
                  {
                    /*....*/
                    sys.Menue();
                 
                 int chose=Convert.ToInt32(Console.ReadLine());
                    if(chose==1)
                    {
                        
                    }
                }
                if(answer== "sign up")
                {
                    Seller s=new Seller();  
                    s.SingUp();
                    //save in file
                    sys.Menue();
                     int chose=Convert.ToInt32(Console.ReadLine());
                    if(chose==1)
                    {
                        bool flage=true;
                        while (flage) { 
                       s.AddingListing() ;
                        
                        Console.Write("Do you want to add more?(yes/no) ");
                        string more=Console.ReadLine();
                        if (more !="yes")
                                flage=false;    
                        s.print();
                    }

                    }
                    if(chose==2)
                    {
                        int ID;
                        Console.Write("Enter the ID of your list to be deleted: ");
                        ID=Convert.ToInt32(Console.ReadLine());
                      s.DeleteListing(ID);

                    }
                    
                    
                    


                }
                
                
              




            }
            if(user=="costomer")
            {

            }
           

        }
    }
}
