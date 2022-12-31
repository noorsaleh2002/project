using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace part2_umlProject
{

    [Serializable]
    class Listing
    {
        string nameList, description;
        double price;
        int numbrOfItem;
        static int listIdCounter = 0;
        int listId;
        public Listing()
        { }
        public Listing(string nameList, string description, double price, int numbrOfItem, int ID)
        {
            this.NameList = nameList;
            this.Description = description;
            this.Price = price;
            this.NumbrOfItem = numbrOfItem;
            this.listId = ID;
        }
       
        public Listing CreatList()
        {
            try
            {
                this.listId = listIdCounter;
                Console.Write("Enter List name: ");
                string name = Console.ReadLine();
                Console.Write("Enter List description: ");
                string description = Console.ReadLine();
                Console.Write("Enter the price of item : ");
                double price = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter number of items in your Listing: ");
                int numberOfItem = Convert.ToInt32(Console.ReadLine());
                Listing L = new Listing(name, description, price, numberOfItem, listId);
                listIdCounter++;
                return L;
               
            }
            catch (InvalidDataException e)
            {
                string m = e.Message;
                return null;
            }
            
        }
    
        public void print()
        {
            Console.WriteLine("*********************");
            Console.WriteLine("ID: {0}", listId);
            Console.WriteLine("List name : {0}", NameList);
            Console.WriteLine("About the list {0}", Description);
            Console.WriteLine("price for each item : {0}", Price);
            Console.WriteLine("Number of item in the listing : {0}", NumbrOfItem);
            Console.WriteLine("*********************");
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
        string id, name, shippingAdress, passWord, email;
        int phoneNumber;
        Payment payment;
        List<Listing> chart = new List<Listing>();
        public Customer() { }
        public Customer(string id, string name, string shippingAdress, int phoneNumber, string passWord, string email)
        {
            this.Email = email;
            this.Id = id;
            this.Name = name;
            this.ShippingAdress = shippingAdress;
            this.PhoneNumber = phoneNumber;
            string phoneNumber1 = phoneNumber.ToString();
            if (phoneNumber1.Length == 10 && phoneNumber1[0] == '0' && phoneNumber1[1] == '7' && (phoneNumber1[2] == '7' || phoneNumber1[2] == '8' || phoneNumber1[2] == '9'))
                this.phoneNumber = phoneNumber;
            else
            {

                Console.Write("Wrong phoneNumber ");
                this.phoneNumber = 0;
            }

        }
        public void SingUp()
        {
            try
            {
                Console.Write("Enter your email: ");
                Email = Console.ReadLine();
                Console.Write("Enter your password: ");
                PassWord = Console.ReadLine();
                Console.Write("Enter your name: ");
                Name = Console.ReadLine();
                Console.Write("Enter your  shipping address: ");
                ShippingAdress = Console.ReadLine();
                Console.Write("Enter your phone:   ");
                PhoneNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your payment information: ");

                string cardNumber, pinCode, billingAdress;
                Console.Write("Enter your card number: ");
                cardNumber = Console.ReadLine();
                Console.Write("Enter your card pin code: ");
                pinCode = Console.ReadLine();
                Console.Write("Enter your card billiding address: ");
                billingAdress = Console.ReadLine();
                payment = new Payment(cardNumber, pinCode, billingAdress);

            }
            catch (InvalidDataException e)
            {
                string m = e.Message;
            }
        }

        public double GetChartPrice()
        {
            double totalPrice = 0;
            for (int i = 0; i < chart.Count; i++)
            {
                totalPrice += chart[i].Price;
            }
            return totalPrice;
        }

        public List<Listing> Getchart()
        {
            return chart;
        }


        public void PrintChartItimes()
        {
            for (int i = 0; i < chart.Count; i++)
            {
                Console.WriteLine("Item number {0}:", i + 1);
                chart[i].print();
            }
        }



        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string ShippingAdress { get => shippingAdress; set => shippingAdress = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public Payment Payment { get => payment; set => payment = value; }
        public string Email { get => email; set => email = value; }
    }
    [Serializable]
    class Seller
    {
        string name, address, emai, storeName, password;
        int phoneNumber, numberOfListing = 0;
        List<Listing> listItime = new List<Listing>();
        List<Customer> customers = new List<Customer>();
        Listing L = new Listing();

        public Seller(string name, string address, string emai, string storeName, string password, int phoneNumber)
        {
            this.name = name;
            this.address = address;
            this.emai = emai;
            this.storeName = storeName;
            this.password = password;
            string phoneNumber1 = phoneNumber.ToString();
            if (phoneNumber1.Length == 10 && phoneNumber1[0] == '0' && phoneNumber1[1] == '7' && (phoneNumber1[2] == '7' || phoneNumber1[2] == '8' || phoneNumber1[2] == '9'))
                this.phoneNumber = phoneNumber;
            else
            {

                Console.Write("Wrong phoneNumber ");
                this.phoneNumber = 0;
            }

        }
        public Seller() { }


        public List<Listing> GetlistItime()
        {
            return listItime;
        }

        public void PrintSellerInfo()
        {
            Console.WriteLine("Seller name: {0}\n Seller Store Name: {1}", Name, StoreName);
        }

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Emai { get => emai; set => emai = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string StoreName { get => storeName; set => storeName = value; }
        public string PassWrod { get => password; set => password = value; }
        public int NumberOfListing { get => numberOfListing; set => numberOfListing = value; }

        public void SingUp()
        {
            try
            {
                Console.Write("Enter your name: ");
                Name = Console.ReadLine();
                Console.Write("Enter your address: ");
                Address = Console.ReadLine();
                Console.Write("Enter your Email:  ");
                Emai = Console.ReadLine();
                Console.Write("Enter your phone number :");
                PhoneNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter your store name: ");
                StoreName = Console.ReadLine();
                Console.Write("Enter your password: ");
                PassWrod = Console.ReadLine();
            }
            catch (InvalidDataException e)
            {
                string m = e.Message;
            }
        }
        public void AddingListing()
        {
            listItime.Add(L.CreatList());
            numberOfListing++;
        }
        public void DeleteListing(int ID)
        {
            listItime.RemoveAll(listItime => listItime.ListId == ID);
        }
        public void print()
        {
            foreach (Listing i in listItime)
            {
                i.print();
            }
        }
        public void ChangeListInfo(int ID)
        {
            //sreach for list
            if (listItime.Count != 0)
            {
                for (int i = 0; i < listItime.Count; i++)
                {
                    if (listItime[i].ListId == ID)
                    {
                        //change info
                        Console.WriteLine("What do you want to chang?");
                        Console.WriteLine("1-The name\n2-The descreption\n3-The price\n4-The number of items");
                        Console.Write("Enter your choise:");
                        try
                        {
                            int answer = Convert.ToInt32(Console.ReadLine());
                        
                        switch (answer)
                        {
                            case 1:
                                {
                                    Console.Write("Enter new List Name: ");
                                    listItime[i].NameList = Console.ReadLine(); break;
                                }
                            case 2:
                                {
                                    Console.Write("Enter the new decreption: ");
                                    listItime[i].Description = Console.ReadLine(); break;
                                }
                            case 3:
                                {
                                    Console.Write("Enter the new price: ");
                                    listItime[i].Price = Convert.ToDouble(Console.ReadLine()); break;
                                }
                            case 4:
                                {
                                    Console.Write("Enter new number of item: ");
                                    listItime[i].NumbrOfItem = Convert.ToInt32(Console.ReadLine()); break;
                                }

                        }

                        }
                        catch (InvalidDataException e)
                        {
                            string m = e.Message;
                        }
                    }
                    //save the update in file
                }
            }
            else { Console.WriteLine("NO List have the given id"); }

        }

        public void ViewSoldListings()
        {
            //the list will add to it at customer class when list id match sellers list id
            Console.WriteLine("Customers who buy from your stor:.. ");
            foreach (Customer c in customers)
            {
                Console.WriteLine("*****");
                Console.WriteLine("Customer name: {0}\n Customer email{1}\n Customer shipping address: {2} ", c.Name, c.Email, c.ShippingAdress);
                Console.WriteLine(" purchase price: {0}", c.GetChartPrice());


            }
        }


        public void AddCustomers(Customer c)
        {
            //add customer to List (customers)
            //after cheaking ID for list seller if match
        }
        public void AvailableListing()
        {
            foreach (Listing L in listItime)
            {
                if (L.NumbrOfItem > 0)
                    L.print();

            }
        }


    }

    [Serializable]
    class System
    {
        public void Menueseller()
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
        public void MenueBuyer()
        {
            Console.WriteLine("1. View all available listings");
            Console.WriteLine("2.View a chosen listing information (i.e., price, seller information");
            Console.WriteLine("3.Add a listing to their cart");
            Console.WriteLine("4. View/Edit added listings to their cart");
            Console.WriteLine("5. Checkout listings");
            Console.WriteLine("6. Change account information (i.e., password)");
            Console.WriteLine("7. search for a listing");//[optional]
            Console.WriteLine("8.log out");
            Console.Write("What do you want to do ? ");
        }
        public void SaveSellersAccounts(Seller s)
        {
            FileStream fileStream = new FileStream("Sellers_Accounts.txt", FileMode.Append, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, s);
            fileStream.Close();
        }
        public Seller[] LoadSellersItem()
        {
            FileStream fileStream = new FileStream("SellersAccounts.data", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter formatter = new BinaryFormatter();
            Seller[] s = new Seller[fileStream.Length];
            while (fileStream.Position < fileStream.Length)
                s[fileStream.Position++] = (Seller)formatter.Deserialize(fileStream);
            fileStream.Close();
            return s;
        }
       
        public void SaveBuyersAccounts(Customer c)
        {
            FileStream fileStream1 = new FileStream("Customers_Accounts.txt", FileMode.Append, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream1, c);
            fileStream1.Close();
        }
        public void SellerInterAction(Seller s)
        {

            bool logout = false;
            while (!logout)
            {
              
                Menueseller();
                try
                {
                    int chose = Convert.ToInt32(Console.ReadLine());
                    if (chose == 1)
                    { //Adding new listing:
                      // Seller[] s1 = LoadSellersItem();
                        bool flage = true;
                        while (flage)
                        {
                            s.AddingListing();
                            Console.Write("Do you want to add more?(yes/no) ");
                            string more = Console.ReadLine();
                            if (more != "yes")
                                flage = false;
                        }
                    }
                    if (chose == 2)
                    {//Deleting exist listing 
                        Console.Write("Enter the ID of your list to be deleted: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        s.DeleteListing(id);
                       
                    }
                    if (chose == 3)
                    {// Change info and price for existing listing(s
                        Console.Write("Enter the ID of your list to be updated: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        s.ChangeListInfo(id);
                    }
                    if (chose == 4)
                    {//View all listings 

                        Console.Write("Do you want to veiw your listing or other sellers listing...? (Enter 1 or 2) :   ");
                        int answer = Convert.ToInt32(Console.ReadLine());                 
                        if (answer == 1)
                        {
                            //veiw just  seller listing..
                            s.print();

                        }

                        else
                        {
                            //veiw other listing from load the seller account from file so must emplement load function first....
                             Seller[] s1 = LoadSellersItem();
                            for (int i = 0; i <s1.Length; i++)
                            {
                                s1[i].print();
                            }
                        }
                    }
                    if (chose == 5)
                    {
                        //. View sold listings information 
                        //The solution in array save all the list id by load all the customer and compare if id in arry== customer
                        s.ViewSoldListings();


                    }
                    if (chose == 6)
                    { //Change account information
                        Console.WriteLine("**************");
                        //string name, address, emai,phoneNumber,storeName,password;
                        Console.WriteLine("1-Name\n2-Address\n3-Email\n4-Phone number\n5-Store name\n6-Pass word");
                        Console.WriteLine("What do you want to change? ..");
                        int answer = Convert.ToInt32(Console.ReadLine());
                        switch (answer)
                        {
                            case 1: { Console.Write("Enter new name: "); s.Name = Console.ReadLine(); break; }
                            case 2: { Console.Write("Enter new address: "); s.Address = Console.ReadLine(); break; }
                            case 3: { Console.Write("Enter new email: "); s.Emai = Console.ReadLine(); break; }
                            case 4: { Console.Write("Enter new phone number: "); s.PhoneNumber = Convert.ToInt32(Console.ReadLine()); break; }
                            case 5: { Console.Write("Enter new store name: "); s.StoreName = Console.ReadLine(); break; }
                            case 6: { Console.Write("Enter new password: "); s.PassWrod = Console.ReadLine(); break; }
                        }
                        //save update
                    }
                    if (chose == 7)
                    {//log out
                        logout = true;
                    }
                }
                catch (InvalidDataException e)
                {
                    string m = e.Message;
                }


            }
       
}



         public void BuyerInterAction(Customer c)
         {
             bool logout = false;
             while (!logout)
             {

                 MenueBuyer();
                 int chose = Convert.ToInt32(Console.ReadLine());
                 if (chose == 1)
                 { //View all available listings:

                     Seller[] s = LoadSellersItem();
                     foreach (Seller seller in s)
                     {
                         seller.AvailableListing();
                     }
                 }

                 if (chose == 2)
                 {//View a chosen listing information 
                     Seller[] s = LoadSellersItem();
                     foreach (Seller seller in s)
                     {
                         seller.AvailableListing();
                     }
                     //then choose from the avalabil
                     int listID;
                     Console.Write("Enter the List ID for more information: ");
                     listID = Convert.ToInt32(Console.ReadLine());

                     //or from the above for loop make  a function that returen the list of avalabile list.
                     foreach (Seller seller in s)
                     {
                         List<Listing> listItim = seller.GetlistItime();
                         foreach (Listing list in listItim)
                         {
                             if (list.ListId == listID)
                                 seller.print();
                             seller.PrintSellerInfo();
                         }
                     }
                 }
                 if (chose == 3)
                 {// Add a listing to their cart
                 addmoreone:
                     {
                         //1-ask the buyer about the id of the listing to be put in thier chart ==> I made List in customer class of type Listing
                         int listID;
                         Console.Write("Enter the List ID for more information: ");
                         listID = Convert.ToInt32(Console.ReadLine());


                         //after putting it in the chart invoke funtion AddCustomers in seller class then less by one the number of item of the listing
                         Seller[] s = LoadSellersItem();
                         Customer c1 = new Customer();
                         foreach (Seller seller in s)
                         {
                             List<Listing> listItim = seller.GetlistItime();
                             foreach (Listing list in listItim)
                             {
                                 if (list.ListId == listID)
                                 {
                                     foreach (Listing L in seller.GetlistItime())
                                     {
                                         if (L.NumbrOfItem > 0)
                                         {
                                             c1.Getchart().Add(L.CreatList());
                                         }


                                     }
                                 }
                                 else
                                 {
                                     Console.WriteLine("Invalid listing ID. Please try again.");
                                 }
                             }
                         }
                     }
                     //finaly ask if he finish adding before completing the purchas...
                     Console.WriteLine("Do you want to add more items to your chart? (Y/N)");
                     char x;
                     x = Convert.ToChar(Console.ReadLine());
                     if (x == 'Y')
                     {
                         goto addmoreone;
                     }
                 }

                 if (chose == 4)
                 {//View/Edit added listings to their cart
                     //Make funtion to print the List of Listing (chart)
                     c.PrintChartItimes();
                 //ask the customer if he want to delete item by giving the id from the List(chart)
                 deletmoreone:
                     {
                         char x;
                         Console.WriteLine("Do you want to delete your chart?(y/n): ");
                         x = Convert.ToChar(Console.ReadLine());
                         if (x == 'y')
                         {
                             int listID;
                             Console.Write("Enter the List ID for more information: ");
                             listID = Convert.ToInt32(Console.ReadLine());
                             Seller[] s = LoadSellersItem();
                             Customer c1 = new Customer();
                             foreach (Seller seller in s)
                             {
                                 List<Listing> listItim = seller.GetlistItime();
                                 foreach (Listing list in listItim)
                                 {
                                     if (list.ListId == listID)
                                     {
                                         foreach (Listing L in seller.GetlistItime())
                                         {
                                             if (L.NumbrOfItem > 0)
                                             {
                                                 c1.Getchart().Remove(L);
                                             }
                                         }
                                     }

                                 }
                             }

                         }
                     }
                     goto deletmoreone;
                 }
                 if (chose == 5)
                 { //Checkout listings
                 }
                 if (chose == 6)
                 { //Change account information
                     Console.WriteLine("**************");
                     //string name, id,phoneNumber,ShippingAdress,password;
                     Console.WriteLine("1-Name\n2-ID\n3-Phone number\n6-ShippingAdress\n5-Pass word\n6-Email");
                     Console.WriteLine("What do you want to change? ..");
                     int answer = Convert.ToInt32(Console.ReadLine());
                     switch (answer)
                     {
                         case 1: { Console.Write("Enter new name: "); c.Name = Console.ReadLine(); break; }
                         case 2: { Console.Write("Enter new id: "); c.Id = Console.ReadLine(); break; }
                         case 3: { Console.Write("Enter new phone number: "); c.PhoneNumber = Convert.ToInt32(Console.ReadLine()); break; }
                         case 4: { Console.Write("Enter new ShippingAdress : "); c.ShippingAdress = Console.ReadLine(); break; }
                         case 5: { Console.Write("Enter new password: "); c.PassWord = Console.ReadLine(); break; }
                         case 6: { Console.Write("Enter new email: "); c.Email = Console.ReadLine(); break; }
                     }
                     //save update
                 }
                 if (chose == 7)
                 {//search for a listing
                 }
                 if (chose == 8)
                 {//log out
                     logout = true;
                 }

             }

         }//implement but not completed function yet.....

        public Seller ReturnSeller(string email, string password)
        {
            try
            {
                FileStream fileStream = new FileStream("SellersAccounts.txt", FileMode.Open, FileAccess.Read);//add catch...
                BinaryFormatter formatter = new BinaryFormatter();
                Seller s;
                while (fileStream.Position < fileStream.Length)
                {
                    s = (Seller)formatter.Deserialize(fileStream);
                    if (s.Emai == email && s.PassWrod == password)
                        return s;

                }
                fileStream.Close();
                return null;
            }
            catch (FileNotFoundException e)
            {
                string m = e.Message;
                return null;
            }
        }
        public Customer ReturnCustomer(string email, string password)
        {
            try
            {
                FileStream fileStream = new FileStream("CustomersAccounts.txt", FileMode.Open, FileAccess.Read);//add catch...
                BinaryFormatter formatter = new BinaryFormatter();
                Customer c;
                while (fileStream.Position < fileStream.Length)
                {
                    c = (Customer)formatter.Deserialize(fileStream);
                    if (c.Email == email && c.PassWord == password)
                        return c;

                }
                fileStream.Close();
                return null;
            }
            catch(FileNotFoundException e)
            {
                string m = e.Message;
                return null;
            }
        }

    }

    internal class Program
    {


        static void Main(string[] args)
        {

            System sys = new System();

        log_out:
            {

                NewMethod();
                Console.Write("Hello there! Are you costomer or seller? ");

                string user = Console.ReadLine();

                NewMethod();
                if (user == "seller")
                {
                    Console.Write("Are you new here? or you want tolog in ?(log in /sign up)");
                    string answer = Console.ReadLine();



                    NewMethod();


                    if (answer == "log in")
                    {
                        string email, password;
                        Console.Write("Enter your email: ");
                        email = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        password = Console.ReadLine();
                        Seller s = sys.ReturnSeller(email, password);
                        if (s != null)
                        {
                            sys.SaveSellersAccounts(s);
                            NewMethod();
                            sys.SellerInterAction(s);
                            goto log_out;
                        }

                        else
                        {
                            Console.WriteLine("Error there is no account like this pleas try again ...");
                            //go to Home page or to log in page....
                            goto log_out;
                        }
                    }
                    if (answer == "sign up")
                    {
                        Seller s = new Seller();
                        s.SingUp();
                        sys.SaveSellersAccounts(s);
                        NewMethod();
                        sys.SellerInterAction(s);
                        goto log_out;
                    }
                }

                if (user == "costomer")
                {
                    Console.Write("Are you new here? or you want tolog in ?(log in /sign up)");
                    string answer = Console.ReadLine();
                    NewMethod();
                    if (answer == "log in")
                    {
                        string email, password;
                        Console.Write("Enter your email: ");
                        email = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        password = Console.ReadLine();
                        Customer c = sys.ReturnCustomer(email, password);
                        if (c != null)
                        {
                            sys.SaveBuyersAccounts(c);
                            NewMethod();
                            sys.BuyerInterAction(c);
                            goto log_out;
                        }

                        else
                        {
                            Console.WriteLine("Error there is no account like this pleas try again ...");
                            goto log_out;
                        }


                    }


                    if (answer == "sign up")
                    {
                        Customer c = new Customer();
                        c.SingUp();
                        sys.SaveBuyersAccounts(c);
                        NewMethod();
                        sys.BuyerInterAction(c);
                        goto log_out;
                    }


                }

            }
        }

        private static void NewMethod()
        {
            Console.Clear();
        }

    }


}