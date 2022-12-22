using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
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
            Console.WriteLine("List name : {0}",NameList);
            Console.WriteLine("ID: {0}",listId);  
            Console.WriteLine("About the list {0}",Description);
            Console.WriteLine("price for each item : {0}",Price);   
            Console.WriteLine("Number of item in the listing : {0}",NumbrOfItem);
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
        string id, name, shippingAdress, phoneNumber, passWord;
        Payment payment;
        //Listing[] myItems; 
        public Customer() { }
        public Customer(string id, string name, string shippingAdress, string phoneNumber, string passWord)
        {
            this.Id = id;
            this.Name = name;
            this.ShippingAdress = shippingAdress;
            this.PhoneNumber = phoneNumber;
            this.PassWord = passWord;
           
        }
        public void SingUp()
        {
            
            Console.Write("Enter your name: ");
            Name=Console.ReadLine();
            Console.Write("Enter your  shipping address: ");
            ShippingAdress=Console.ReadLine();
            Console.Write("Enter your phone:   ");
            PhoneNumber=Console.ReadLine();
            
            Console.Write("Enter your password: ");
            PassWord=Console.ReadLine();
            Console.WriteLine("Enter your payment information: ");
            
            string cardNumber, pinCode, billingAdress;
            Console.Write("Enter your card number: ");
            cardNumber=Console.ReadLine();
             Console.Write("Enter your card pin code: ");
            pinCode=Console.ReadLine();
             Console.Write("Enter your card billiding address: ");
            billingAdress=Console.ReadLine();
            payment=new Payment(cardNumber, pinCode, billingAdress);

            
        }

        
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string ShippingAdress { get => shippingAdress; set => shippingAdress = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public Payment Payment{ get => payment; set => payment = value; }
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
            if (listItime.Capacity != 0) { 
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
            else
            {
                Console.Write("There is no lists yet do you want to add Listing?(y/n)")
                char answer=Convert.ToChar(Console.ReadLine());
                /*
                 add go to add listing funciton if you have time....
                 
                 */
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
            if(listItime.Capacity != 0) {
                for(int i=0; i<listItime.Capacity; i++) {
                    if (listItime[i].ListId==ID) {
                        //change info
                        Console.WriteLine("What do you want to chang?")
                        Console.WriteLine("1-The name\n2-The descreption\n3-The price\n4-The number of items");
                        Console.Write("Enter your choise:");
                        int answer=Convert.ToInt32(Console.ReadLine());
                        switch (answer) { 
                           case 1:{ Console.Write("Enter new List Name: ");
                            listItime[i].NameList=Console.ReadLine();break;}
                            case 2: { Console.Write("Enter the new decreption: ");   
                                    listItime[i].Description=Console.ReadLine();break;}
                            case 3: {Console.Write("Enter the new price: ");
                                    listItime[i].Price=Convert.ToDouble(Console.ReadLine());break;}
                            case 4: { Console.Write("Enter new number of item: ");
                                    listItime[i].NumbrOfItem=Convert.ToInt32(Console.ReadLine()); break;}
                                     
                        }

                    }
                    //save the update in file
                }
             else { Console.WriteLine("NO List have the given id");}
            
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
        List<Customer> customerlist=new List<Customer>();
        Seller s;
        Customer c;
        FileStream fileStream ;
        BinaryFormatter formatter;
        int IDcounter = 0;*/
        public void Menueseller()
        {   Console.WriteLine("1-Adding new listing:");
                Console.WriteLine("2-Delete exiting listing:");
                Console.WriteLine("3-Change info and price for existing listing(s):");
                Console.WriteLine("4-View all listings :");
                Console.WriteLine("5-View sold listings information:");
                Console.WriteLine("6-Change account information:");
                Console.WriteLine("7-log out:");
            Console.Write("What do you want to do ? ");
        }
        public void MenueBuyer()
        {
                Console.WriteLine("1. View all available listings");
                Console.WriteLine("2.View a chosen listing information (i.e., price, seller information");
                Console.WriteLine("3.Add a listing to their cart");
                Console.WriteLine("4. View/Edit added listings to their cart");
                Console.WriteLine("5. Checkout listings");
                Console.WriteLine("6. Change account information (i.e., password)");
                Console.WriteLine("7. [optional] search for a listing");
                Console.WriteLine("8.log out");
                Console.Write("What do you want to do ? ");
         }
        public void SaveSellersAccounts(Seller s)
        {
            FileStream fileStream = new FileStream("SellersAccounts.data", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter formatter= new BinaryFormatter();
            formatter.Serialize(fileStream, s);
            fileStream.Close();
        }
        public Seller LoadSellersItem()
            {
                FileStream fileStream = new FileStream("SellersAccounts.data", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryFormatter formatter= new BinaryFormatter();
                Seller[] s=new Seller[fileStream.Length];
                for(fileStream.Position<fileStream.Length)
                    s[fileStream.Position++] = formatter.Deserialize(fileStream);
                return s;
            }
        public void SaveBuyersAccounts(Customer c)
        {
            FileStream fileStream = new FileStream("Customers Accounts.data", FileMode.Open, FileAccess.Write);
            BinaryFormatter formatter= new BinaryFormatter();
            formatter.Serialize(fileStream, c);
            fileStream.Close();
        }
        public  void SellerInterAction(Seller s)
        {        
            bool logout=false;  
             while (!logout) { 
                       
                Menueseller();
                int chose=Convert.ToInt32(Console.ReadLine());
                if (chose == 1) { //Adding new listing:
                        
                  bool flage=true;
                  while (flage) { 
                     s.AddingListing() ;
                     Console.Write("Do you want to add more?(yes/no) ");
                     string more=Console.ReadLine();
                     if (more !="yes")
                     flage=false;    
                        
                                  }

                 }
                if(chose==2){//Deleting exist listing 
                  
                  Console.Write("Enter the ID of your list to be deleted: ");
                  int id=Convert.ToInt32(Console.ReadLine());
                  s.DeleteListing(id);
    
                 }
                if (chose==3) {// Change info and price for existing listing(s
                    Console.Write("Enter the ID of your list to be updated: ");
                  int id=Convert.ToInt32(Console.ReadLine());
                    s.ChangeListInfo(id);
                            
                   }  
                if (chose==4) {//View all listings 
                    Console.Write("Do you want to veiw your listing or other sellers listing...? (Enter 1 or 2) :   ");
                    int answer=Convert.ToInt32(Console.ReadLine()) ;
                    if (answer)
                        {
                            //veiw just  seller listing..
                            s.print();

                        }
                    else { 
                           //veiw other listing from load the seller account from file so must emplement load function first....
                           Seller [] s = LoadSellersItem();
                            for (int i=0;i<s.Length;i++)
                            {
                                s[i].print();
                            }
                        }
                   }
                if (chose == 5)
                {
                        //. View sold listings information 
                        //The solution in array save all the list id by load all the customer and compare if id in arry== customer
                        

                }
                if(chose == 6) { //Change account information
                        Console.WriteLine("What do you want to change? ..");
                        //string name, address, emai,phoneNumber,storeName,password;
                        Console.WriteLine("1-Name\n2-Address\n3-Email\n4-Phone number\n5-Store name\n6-Pass word";
                        int answer=Convert.ToInt32(Console.ReadLine());
                        switch(answer)
                        {
                            case 1: { Console.Write("Enter new name: ");s.Name=Console.ReadLine();break;}
                            case 2: {  Console.Write("Enter new address: ");s.Address=Console.ReadLine();break;}
                            case 3: {  Console.Write("Enter new email: ");s.Emai=Console.ReadLine();break;}
                            case 4: {  Console.Write("Enter new phone number: ");s.PhoneNumber=Console.ReadLine();break;}
                            case 5: {  Console.Write("Enter new store name: ");s.StoreName=Console.ReadLine();break;}
                            case 6: {  Console.Write("Enter new password: ");s.PassWrod=Console.ReadLine();break;}
                        }
                        //save update
                }
                if (chose == 7)
                {
                        //log out ,,,,use (go to )
                        logout=true;
                }
                
             }
                     
        }
        public void BuyerInterAction()
        {
           
        }//not implement yet.....
        public Seller ReturnSeller(string email,string password)
        {
             FileStream fileStream = new FileStream("Sellers Accounts.data", FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter= new BinaryFormatter();
            Seller s;
            while (fileStream.Position<fileStream.Length)
            {
                s=(Seller)formatter.Deserialize(fileStream);
                if(s.Emai==email && s.PassWrod==password) return s;
                    
            }
            return null;
            fileStream.Close();
        }
       
    }
    internal class Program
    {
       
        static void Main(string[] args)
        {

            System sys=new System();

            Console.Write("Hello there! Are you costomer or seller? ");
            
            string user = Console.ReadLine();

            if (user == "seller")
            {
                Console.Write("Are you new here? or you want tolog in ?(log in /sign up)");
                string answer = Console.ReadLine();

                if (answer== "log in")
                  {
                    string email,password;
                    Console.Write("Enter your email: ");
                    email = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    password = Console.ReadLine();
                    Seller s =sys.ReturnSeller(email,password);
                    if (s!=null)
                        sys.SellerInterAction(s); 
                   else 
                        Console.WriteLine("Error there is no account like this pleas try again ...");
                    //go to Home page or to log in page....
                 }
                if(answer== "sign up")
                { 
                    Seller s=new Seller();  
                    s.SingUp();
                    sys.SaveSellersAccounts(s);
                    sys.SellerInterAction(s);     
                }
            }

            if(user=="costomer")
            {
                Console.Write("Are you new here? or you want tolog in ?(log in /sign up)");
                string answer = Console.ReadLine();
                if (answer== "log in")
                {
                    /*....*/
                    sys.MenueBuyer();
                 
                
                }
                if(answer== "sign up")
                {
                    Customer c=new Customer();  
                    c.SingUp();
                    sys.SaveBuyersAccounts(c);
                    sys.BuyerInterAction();
                }
           

            }


         }
    }
 }
