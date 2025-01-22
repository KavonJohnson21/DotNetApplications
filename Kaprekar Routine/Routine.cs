using System.ComponentModel.DataAnnotations;

// variable to define string input gathered from user
string number = Routine.GetNum(); 

// Method call to perform Kaprekar's Routine by passing string gathered from user
Routine.Calculate(number); 

// Parent class for program to perform Kaprekar's Routine
class Routine {

    // Method to get number from user
    public static string GetNum() {
        // define variables for GetNum method
        string userNum = string.Empty;
        bool validNum = false; 

        //while loop to ask user for a valid number until one is given
        while (!validNum){
            
            //Ask user for a valid number
            Console.Write("Enter a 4-digit number with at least two different digits (Example: '3433'): ");
            string? number = Console.ReadLine();

            //Check if number is valid with if-else statement
            if (validNumber(number)) {
                validNum = true; 
                userNum = number!;
            }
            else {
                Console.WriteLine("Invalid number! Must be a 4-digit number with at least two different digits (Example: '3433'): ");
                Console.WriteLine("\n");
            }
        }
        // Once a valid number is given, return the string 
        return userNum;
    }

    //Method that returns a boolean on digit validity provided by user
    public static bool validNumber(string? number) {
        //Ensure input is not null
        if (number == null){
            return false;
        }
        //Ensure a 4 digit number is given
        if (number.Length != 4){
            return false; 
        }

        //Ensure an numeric number is given
        //TryParse converts a string to its numeric value. This method returns a boolean dtermining if the conversion was successful. 
        if (!int.TryParse(number, out int result)){
            return false;
        }

        //Ensure the 4 digit number has at least two distinctive digits
        //ToCharArray method coverts a string to a Unicode character array
        //Distinct method removes duplicate elements from a collection
        //Count method is used here to count the muber of distinct digits 
        if (number.ToCharArray().Distinct().Count() < 2){
            return false;
        }
        return true;
    }

    // Method to perform Kaprekar's routine
    public static void Calculate(string number){
        //ToCharArray method coverts a string to a Unicode character array
        char[] c = number.ToCharArray();
        //Order number in descending order by digit 
        string descend = string.Concat(c.OrderByDescending(c => c));
        //Order number in ascending order by digit
        string ascend = string.Concat(c.OrderBy(c => c));
        //Convert string into an integer and find difference
        int difference = int.Parse(descend) - int.Parse(ascend);
        //Call method to show routine calculation
        Display(descend, ascend, difference);
        //As long as the intented number is not reached, keep performing Kaprekar's routine
        if (difference != 6174) {
            Calculate(difference.ToString("0000"));
        }
        else {
            Console.WriteLine("6174, I told you!");
        }
    }

    //Method that will display the steps within Kaprekar's Routine
    public static void Display(string desc, string asc, int diff){
        Console.WriteLine(desc + " - " + asc + " = " + diff);
        //Console.WriteLine("\n");
    }
}