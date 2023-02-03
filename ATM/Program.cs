using System;
using System.Security.Cryptography.X509Certificates;


namespace ATM_Machine
{
    public class cardholder
    {
        // Cardholder Attributes
        string FirstName;
        string LastName;
        string CardNumber;
        int Pin;
        double Balance;

        // Cardholder Constructor
        public cardholder(string FirstName, string LastName, string CardNumber, int Pin, double Balance)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.CardNumber = CardNumber;
            this.Pin = Pin;
            this.Balance = Balance;
        }

        // Set up "Getters"
        public string getFirstName()
        {
            return FirstName;
        }      
        public string getLastName()
        {
            return LastName;
        }
        public string getCardNumber()
        {
            return CardNumber;
        }
        public int getPin()
        {
            return Pin;
        }
        public double getBalance()
        {
            return Balance;
        }


        // Set up "Setters"
        public void setFirstName(string newFirstName)
        {
            FirstName = newFirstName;
        }
        public void setLastName(string newLastName)
        {
            LastName = newLastName;
        }
        public void setCardNum(string newCardNum)
        {
            CardNumber = newCardNum;
        }
        public void setPin(int newPin)
        {
            Pin = newPin;
        }
        public void setBalance(double newBalance)
        {
            Balance = newBalance;
        }


        public static void Main(string[] args)
        {

            // Options Screen
            void printOptions()
            {
                Console.WriteLine("Please choose one of the following options...");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");


            }

            // Handling Deposits
            void deposit(cardholder currentUser)
            {
                Console.WriteLine("How much would you like to deposit? ");

                // Add deposit to balance
                double deposit = Convert.ToDouble(Console.ReadLine());
                currentUser.setBalance(deposit + currentUser.getBalance());


                Console.WriteLine("Thank you for the deposit, your new balance is: $" + currentUser.getBalance());
            }

            // Handle Withdrawls
            void withdrawl(cardholder currentUser)
            {
                Console.WriteLine("How much would you like to withdrawl? ");
                double withdrawl = Convert.ToDouble(Console.ReadLine());
                if (withdrawl > currentUser.getBalance())
                {
                    Console.WriteLine("Insufficient Funds");
                }
                else
                {
                    currentUser.setBalance(currentUser.getBalance()- withdrawl);
                    Console.WriteLine("Thank you for the withdrawl, your new balance is: $" + currentUser.getBalance());
                }
            }

            // Show Balance
            void showBalance(cardholder currentUser)
            {
                Console.WriteLine("Your current Balance is: $" + currentUser.getBalance());
            }

            // Create list of diffrent users [ESSENTIALLY CREATED A DATABASE]
            List<cardholder> cardholders = new List<cardholder>();
            cardholders.Add(new cardholder("Jacob", "Thomas", "11111111111", 1234, 125.36));
            cardholders.Add(new cardholder("Jim", "Jacobs", "2222222222", 5678, 8869.41));
            cardholders.Add(new cardholder("Steve", "Ackberry", "3333333333", 9999, 46873.25));
            cardholders.Add(new cardholder("John", "Jeffries", "4444444444", 4321, 21.50));
            cardholders.Add(new cardholder("Hienz", "Ward", "5555555555", 8765, 752.66));





            // Prompt user
            Console.WriteLine("Welcome to Simple ATM");
            Console.WriteLine("Please insert your debt card number: ");
            // Initialize card number and user
            string debtCardNum = "";
            cardholder currentUser;
            
            // Request card number and make sure card number submitted is found or correct format
            while (true)
            {
                try
                {
                    debtCardNum= Convert.ToString(Console.ReadLine());

                    // Validate card number submitted
                    // using ".FirstorDefault()" essentially tries to find the input inside a list, if found then will return entire object
                    currentUser = cardholders.FirstOrDefault(a => a.CardNumber == debtCardNum);
                    if (currentUser != null) { break; }
                    else { Console.WriteLine("Card not recognized, please try again"); }
                }
                catch
                {
                    Console.WriteLine("Card not recognized, please try again");
                }
            }

            
            // Request and verify Pin
            Console.WriteLine("Please enter your pin: ");
            int pinNumberSubmitted = 0;
            
            while(true)
            {
                try
                {
                    // Grab the submitted pin and compare to the pin on register for the current user based on card number
                    pinNumberSubmitted = Convert.ToInt32(Console.ReadLine());
                    if(pinNumberSubmitted == currentUser.getPin()) { break; }
                    else { Console.WriteLine("Pin not recognized, please try again"); }
                }
                catch { Console.WriteLine("Pin not recognized, please try again"); }
            }


            // Welcome user after login
            Console.WriteLine("Welcome " + currentUser.getFirstName());
            int optionChoice = 0;
            do
            {
                printOptions();
                try
                {
                    optionChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch { }
                if (optionChoice == 1) { deposit(currentUser); }
                else if (optionChoice == 2) { withdrawl(currentUser); }
                else if (optionChoice == 3) { showBalance(currentUser); }
                else if (optionChoice == 4) { break; }
                else { optionChoice = 0; }

            }
            // added comment
            while (optionChoice != 4);
            Console.WriteLine("Thank you and have a nice day!");



        }
    }
}








/*namespace ATM
{
	class bankAccount
	{
		//Naming the attributes each bank account will have
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public double balance { get; set; }
        private double Balance 
		{ 
			get { return balance; }
			set { balance = value; }
		}
		
		// Create a constructor for the bank account attributes
        public bankAccount(string firstName, string lastName, double balance)
		{
			FirstName = firstName;
			LastName = lastName;
			Balance = balance;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the ATM");
			bankAccount person = new bankAccount("Jim", "Johnson", 1000.26);
			Console.WriteLine("First Name: " + person.FirstName);
			Console.WriteLine("Last Name: " + person.LastName);
            Console.WriteLine("Account Balance: $" + person.balance);


			// Update the person's FirstName
			Console.WriteLine("Enter new first name: ");
			person.FirstName = Console.ReadLine();		//ReadLine allows console to see what was typed

            // Update the person's FirstName
            Console.WriteLine("Enter new last name: ");
            person.LastName = Console.ReadLine();

            // Update the account Balance
            Console.WriteLine("Enter new balance: ");
            person.balance = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("Updated Information: ");
            Console.WriteLine("First Name: " + person.FirstName);
            Console.WriteLine("Last Name: " + person.LastName);
            Console.WriteLine("Account Balance: $" + person.balance);

            //Console.WriteLine(person.Balance); Cant access "Balance" directly since it is private in another classs
        }
	}
}*/