using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Runtime.Serialization;
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
                Console.WriteLine(m);
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
    class Item
    {
        string itemName;
        int itemId;
        int numberOfItems;
        double tprice, pprice;
        public Item() { }
        public Item(int itemId, string itemName, int numberOfItems, double price)
        {
            this.ItemId = itemId;
            this.NumberOfItems = numberOfItems;
            this.ItemName = itemName;
            this.Price = price * numberOfItems;
            this.PPrice = price;

        }
        public void Print()
        {
            Console.WriteLine("Item Name: {0} ", ItemName);
            Console.WriteLine("Item ID : {0}", ItemId);
            Console.WriteLine("Number of seleced itesm: {0}", NumberOfItems);
            Console.WriteLine("Item total price: {0}", Price);
        }

        public int ItemId { get => itemId; set => itemId = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public int NumberOfItems { get => numberOfItems; set => numberOfItems = value; }
        public double Price { get => tprice; set => tprice = value; }
        public double PPrice { get => pprice; set => pprice = value; }
    }
    [Serializable]
    class Customer
    {
        string id, name, shippingAdress, passWord, email;
        int phoneNumber;
        Payment payment;
        List<Item> chart = new List<Item>();
        public Customer() { }
        public Customer(string id, string name, string shippingAdress, int phoneNumber, string passWord, string email)
        {
            this.Email = email;
            this.Id = id;
            this.Name = name;
            this.ShippingAdress = shippingAdress;

            string testPhonenumber = phoneNumber.ToString();

            if (testPhonenumber.Length == 10 && (testPhonenumber.StartsWith("079") || testPhonenumber.StartsWith("077") || testPhonenumber.StartsWith("078")))

                this.PhoneNumber = Convert.ToInt32(testPhonenumber);
            else
            {
                Console.WriteLine("Wrong phoneNumber ");
                PhoneNumber = 0;

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


                string testPhonenumber = Console.ReadLine();

                if (testPhonenumber.Length == 10 && (testPhonenumber.StartsWith("079") || testPhonenumber.StartsWith("077") || testPhonenumber.StartsWith("078")))

                    this.PhoneNumber = Convert.ToInt32(testPhonenumber);
                else
                {
                    Console.WriteLine("Wrong phoneNumber ");
                    PhoneNumber = 0;

                }
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
                Console.WriteLine(m);


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

        public List<Item> Getchart()
        {
            return chart;

        }


        public void PrintChartItimes()
        {
            for (int i = 0; i < chart.Count; i++)
            {
                Console.WriteLine("Item number {0}:", i + 1);
                chart[i].Print();
            }
        }


        public string GetshippingAdress()
        {
            return shippingAdress;
        }
        public void ClearChart()
        {
            chart.Clear();
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
            string testPhonenumber = Convert.ToString(phoneNumber);
            if (testPhonenumber.Length == 10 && (testPhonenumber.StartsWith("079") || testPhonenumber.StartsWith("077") || testPhonenumber.StartsWith("078")))
                this.PhoneNumber = phoneNumber;
            else
            {
                Console.WriteLine("Wrong phoneNumber ");
                PhoneNumber = 0;

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
                Console.Write("Enter your Email:  ");
                Emai = Console.ReadLine();
                Console.Write("Enter your password: ");
                PassWrod = Console.ReadLine();
                Console.Write("Enter your name: ");
                Name = Console.ReadLine();
                Console.Write("Enter your address: ");
                Address = Console.ReadLine();
                Console.Write("Enter your phone number :");

                string testPhonenumber = Console.ReadLine();

                if (testPhonenumber.Length == 10 && (testPhonenumber.StartsWith("079") || testPhonenumber.StartsWith("077") || testPhonenumber.StartsWith("078")))

                    this.PhoneNumber = Convert.ToInt32(testPhonenumber);
                else
                {
                    Console.WriteLine("Wrong phoneNumber ");
                    PhoneNumber = 0;

                }
                Console.Write("Enter your store name: ");
                StoreName = Console.ReadLine();
            }
            catch (InvalidDataException e)
            {
                string m = e.Message;
                Console.WriteLine(m);
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
                            Console.WriteLine(m);
                        }
                    }

                }
            }
            else { Console.WriteLine("NO List have the given id"); }

        }

        public void AddCustomer(Customer c)
        {

            customers.Add(c);
        }

        public void ViewSoldListings()
        {
            //the list will add to it at customer class when list id match sellers list id
            Console.WriteLine("Customers who buy from your stor:.. ");
            if (customers.Count > 0)
            {
                foreach (Customer c in customers)
                {
                    Console.WriteLine("*************************************************");
                    Console.WriteLine("Customer name: {0}\n Customer email{1}\n Customer shipping address: {2} ", c.Name, c.Email, c.ShippingAdress);
                    Console.WriteLine(" purchase price: {0}", c.GetChartPrice());
                    Console.WriteLine("*************************************************");

                }
            }
            else { Console.WriteLine("There is no buy from your shop...."); }
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

        List<Customer> customers;
        List<Seller> sellers;
        public string Enter;
        public List<Seller> ReturnSellerFromFile()
        {
            List<Seller> S = new List<Seller>();
            FileStream fileStream = new FileStream("Sellers_Accounts.txt", FileMode.OpenOrCreate, FileAccess.Read);
            if (fileStream.Length > 0)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                while (fileStream.Position < fileStream.Length)
                {

                    S.Add((Seller)formatter.Deserialize(fileStream));

                }
                fileStream.Close();
                return S;
            }
            else
            {
                fileStream.Close();
                return null;
            }

        }
        public List<Customer> RetuenCustomersFromFile()
        {

            List<Customer> c = new List<Customer>();
            FileStream fileStream = new FileStream("Customers_Accounts.txt", FileMode.OpenOrCreate, FileAccess.Read);
            if (fileStream.Length > 0)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                while (fileStream.Position < fileStream.Length)
                {

                    c.Add((Customer)formatter.Deserialize(fileStream));

                }
                fileStream.Close();
                return c;
            }
            else
            {
                fileStream.Close();
                return null;
            }

        }
        public System()
        {
            this.sellers = ReturnSellerFromFile();
            this.customers = RetuenCustomersFromFile();

        }
        public void AddSeller(Seller s)
        {
            if (sellers != null)
                sellers.Add(s);
            else
            {
                sellers = new List<Seller>();
                sellers.Add(s);
            }
        }
        public void AddCustomer(Customer c)
        {
            if (customers != null)
                customers.Add(c);
            else
            {
                customers = new List<Customer>();
                customers.Add(c);
            }
        }
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

        public void SaveSellersAccounts()
        {
            FileStream fileStream = new FileStream("Sellers_Accounts.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            foreach (Seller s in sellers)
            {
                formatter.Serialize(fileStream, s);
            }
            fileStream.Close();
        }
        public void SaveBuyersAccounts()
        {
            FileStream fileStream = new FileStream("Customers_Accounts.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            foreach (Customer c in customers)
            {
                formatter.Serialize(fileStream, c);
            }
            fileStream.Close();
        }
        public void PrintSellersItem(string sellerEmail)
        {
            bool found = false;
            if (sellers != null)
            {
                foreach (Seller s in sellers)
                {
                    if (s.Emai != sellerEmail)
                    {
                        s.print();
                        found = true;
                    }
                }
            }
            if (!found)
                Console.WriteLine("There is no other sellers except you :)");
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
                        //SaveSellersLists(s);
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

                            PrintSellersItem(s.Emai);

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
                        if (Enter == "sign up")
                        {
                            AddSeller(s);

                            SaveSellersAccounts();
                        }
                        if (Enter == "log in")
                        {
                            SaveSellersAccounts();
                        }
                    }
                }
                catch (InvalidDataException e)
                {
                    string m = e.Message;
                    Console.WriteLine(m);
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

                    foreach (Seller se in sellers)
                    {
                        se.AvailableListing();

                    }

                }

                if (chose == 2)
                {//View a chosen listing information 

                    foreach (Seller se in sellers)
                    {
                        se.AvailableListing();
                    }
                    //then choose from the avalabil
                    int listID;
                    Console.Write("Enter the List ID for more information: ");
                    listID = Convert.ToInt32(Console.ReadLine());

                    //or from the above for loop make  a function that returen the list of avalabile list.
                    for (int i = 0; i < sellers.Count; i++)
                    {
                        if (sellers[i] != null)
                        {
                            List<Listing> l = sellers[i].GetlistItime();
                            foreach (Listing l2 in l)
                            {
                                if (l2.ListId == listID)
                                {
                                    l2.print();
                                    sellers[i].PrintSellerInfo();

                                }


                            }

                        }
                    }

                }
                if (chose == 3)
                {// Add a listing to their cart
                 //View all available listings:

                    foreach (Seller se in sellers)
                    {
                        se.AvailableListing();
                    }
                addmoreone:
                    {
                        //1-ask the buyer about the id of the listing to be put in thier chart ==> I made List in customer class of type Listing
                        int listID;
                        Console.Write("Enter the List ID to be added to the chart: ");
                        listID = Convert.ToInt32(Console.ReadLine());


                        //after putting it in the chart invoke funtion AddCustomers in seller class then less by one the number of item of the listing

                        bool found = false;
                        List<Item> mychart = c.Getchart();
                        if (mychart != null)
                        {
                            for (int i = 0; i < mychart.Count; i++)
                            {
                                if (mychart[i].ItemId == listID)
                                    found = true;
                            }

                        }
                        for (int i = 0; i < sellers.Count; i++)
                        {
                            if (sellers[i] != null)
                            {
                                List<Listing> l = sellers[i].GetlistItime();
                                foreach (Listing l2 in l)
                                {
                                    if (l2.ListId == listID && !found)
                                    {
                                        int numberOfItems;
                                        Console.Write("How many item you want to add to your chart? one: ");
                                        numberOfItems = Convert.ToInt32(Console.ReadLine());
                                        if (numberOfItems <= l2.NumbrOfItem)

                                        {
                                            Item item = new Item(l2.ListId, l2.NameList, numberOfItems, l2.Price);
                                            l2.NumbrOfItem = l2.NumbrOfItem - numberOfItems;


                                            c.Getchart().Add(item);

                                            //.AddCustomer(c);
                                            sellers[i].AddCustomer(c);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Can't added the item successfully..");
                                        }
                                    }
                                    else if (l2.ListId == listID && found)
                                    {
                                        int numberOfItems;
                                        Console.Write("How many item you want to add to your chart? tow: ");
                                        numberOfItems = Convert.ToInt32(Console.ReadLine());
                                        if (numberOfItems <= l2.NumbrOfItem)

                                        {
                                            for (int j = 0; j < mychart.Count; j++)
                                            {
                                                if (mychart[j].ItemId == listID)
                                                {
                                                    l2.NumbrOfItem = l2.NumbrOfItem - numberOfItems;
                                                    mychart[j].NumberOfItems = numberOfItems + mychart[j].NumberOfItems;
                                                    mychart[j].Price = mychart[j].NumberOfItems * mychart[j].PPrice;
                                                }

                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Can't added the item successfully..");
                                        }
                                    }


                                }

                            }
                        }

                    }
                    //finaly ask if he finish adding before completing the purchas...
                    Console.Write("Do you want to add more items to your chart? (y/n): ");
                    char x;
                    x = Convert.ToChar(Console.ReadLine());
                    if (x == 'y')
                    {
                        goto addmoreone;
                    }

                }

                if (chose == 4)

                {
                    List<Item> myitems = c.Getchart();
                    if (myitems.Count != 0)
                    {

                        //View/Edit added listings to their cart
                        //Make funtion to print the List of Listing (chart)
                        c.PrintChartItimes();
                    //ask the customer if he want to delete item by giving the id from the List(chart)

                    deletmoreone:
                        {
                            char x;
                            int ditem;
                            Console.WriteLine("Do you want to delete items form your chart?(y/n): ");
                            x = Convert.ToChar(Console.ReadLine());
                            Seller seller;
                            if (x == 'y')
                            {
                                int itemID;
                                Console.Write("Enter the Itim ID to deleted: ");
                                itemID = Convert.ToInt32(Console.ReadLine());
                                List<Item> items = c.Getchart();


                                for (int i = 0; i < items.Count; i++)
                                {
                                    Item item = items[i];
                                    if (item.ItemId == itemID)
                                    {


                                        Console.Write("How many item do you want to delete? ");
                                        ditem = Convert.ToInt32(Console.ReadLine());
                                        if (item.NumberOfItems == 0) Console.WriteLine("You have deleted all your item already..");
                                        else if (item.NumberOfItems >= 1)
                                        {
                                            if (ditem < item.NumberOfItems)
                                            {
                                                item.NumberOfItems -= ditem;
                                                item.Price = item.NumberOfItems * item.PPrice;
                                                for (int j = 0; j < sellers.Count; j++)
                                                {
                                                    seller = sellers[j];
                                                    List<Listing> l = seller.GetlistItime();
                                                    for (int k = 0; k < l.Count; k++)
                                                    {
                                                        if (l[k].ListId == itemID)
                                                        {
                                                            l[k].NumbrOfItem = l[k].NumbrOfItem + ditem;


                                                        }
                                                    }

                                                }



                                            }
                                            else if (ditem > item.NumberOfItems) Console.WriteLine("You have less items than you enter....Error");
                                            else c.Getchart().Remove(item);

                                        }


                                    }
                                    else { Console.WriteLine("There is no id like that in your chart..."); }


                                }


                                goto deletmoreone;
                            }
                        }
                    }
                    else { Console.WriteLine("You don't have nothing in your chart"); }

                }
                if (chose == 5)
                { //Checkout listings
                    //The buyer after viewing their cart, they can proceed to checkout their item
                    c.PrintChartItimes();
                    Console.WriteLine("***************************************************************");
                    Console.WriteLine("1-default shipping address\n2- enter a new shipping address");
                    Console.Write("choice (1 or 2)");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    string address;
                    if (choice == 1)
                    {
                        address = c.GetshippingAdress();
                    }
                    else
                    {
                        Console.Write("Enter the new shipping address: ");
                        address = Console.ReadLine();

                    }
                    //enter information payment
                    Console.Write("Enter the cardnumber :");
                    string cardnum = Console.ReadLine();
                    Console.Write("Enter the pin code :");
                    string pin = Console.ReadLine();
                    Console.Write("Enter the billing address :");
                    string billing = Console.ReadLine();
                    if (c.Payment.CardNumber == cardnum && c.Payment.PinCode == pin && c.Payment.BillingAdress == billing)
                    {
                        Console.WriteLine("successful process purchase.");
                        c.ClearChart();



                    }
                    else
                    {
                        Console.WriteLine("Invalid process purchase.");
                    }


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
                    string x;
                    Console.Write("Enter any word to search it...");
                    x = Console.ReadLine();
                    int maches = 0;
                    foreach (Seller s in sellers)
                    {
                        if (s.Name == x) maches++;
                        List<Listing> l = s.GetlistItime();
                        foreach (Listing l2 in l)
                        {
                            if (l2.NameList == x) maches++;
                            if (l2.Description.Contains(x)) maches++;
                        }
                    }
                    Console.WriteLine("Number of maches are: {0}", maches);
                }
                if (chose == 8)
                {//log out
                    logout = true;

                    if (Enter == "sign up")
                    {
                        AddCustomer(c);
                        SaveBuyersAccounts();
                        SaveSellersAccounts();
                    }
                    if (Enter == "log in")
                    {
                        SaveBuyersAccounts();
                        SaveSellersAccounts();
                    }


                }

            }

        }////Done lololollleeeesh 

        public Seller ReturnSeller(string email, string password)
        {
            if (sellers != null)
            {
                foreach (Seller s in sellers)
                {
                    if (s.Emai == email && s.PassWrod == password)
                        return s;
                }
            }
            return null;
        }
        public Customer ReturnCustomer(string email, string password)
        {

            if (customers != null)
            {
                foreach (Customer c in customers)
                {
                    if (c.Email == email && c.PassWord == password)
                        return c;
                }
            }
            return null;


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
                Console.Write("Hello there! Are you customer or seller or close app (close)? ");

                string user = Console.ReadLine();

                NewMethod();
                if (user == "seller")
                {
                    Console.Write("Are you new here? or you want tolog in ?(log in /sign up)");
                    string answer = Console.ReadLine();
                    sys.Enter = answer;


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
                            //sys.SaveSellersAccounts(s);
                            NewMethod();
                            sys.SellerInterAction(s);
                            //الحفظ بالملف عند الlogout رقم 7
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

                        sys.Enter = answer;

                        //sys.SaveSellersAccounts(s); بديش هسا يحفظهم لحالهم لما يخلص بحفظه كله
                        NewMethod();

                        sys.SellerInterAction(s);

                        goto log_out;
                    }
                }

                if (user == "customer")
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
                            // sys.SaveBuyersAccounts(c);
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
                        //sys.SaveBuyersAccounts();
                        NewMethod();
                        sys.BuyerInterAction(c);

                        goto log_out;
                    }


                }
                if (user == "close")
                    Environment.Exit(0);

            }
        }

        private static void NewMethod()
        {
            Console.Clear();
        }




    }
}
