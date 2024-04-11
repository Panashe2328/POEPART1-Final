using System;

namespace CookBook
{
    class RecipeIngredients
    {
        private int numIngredients;
        private string[] ingrNames;
        private double[] ingrQuantities;
        private string[] ingrUnits;
        private int numSteps;
        private string[] steps;
        private string recipeName;
        private string lastAction;

        public RecipeIngredients()
        {
            numIngredients = 0;
            numSteps = 0;
            lastAction = "";
        }

        public void Details()
        {
            Console.WriteLine("Enter the name of the Recipe: ");
            
            recipeName = Console.ReadLine();


            Console.WriteLine("Enter the number of the ingredients:");
            numIngredients = Convert.ToInt32(Console.ReadLine());
            
            ingrNames = new string[numIngredients];
            ingrQuantities = new double[numIngredients];
            ingrUnits = new string[numIngredients];

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter ingredient {i + 1} name: ");
                ingrNames[i] = Console.ReadLine();

                Console.Write($"Enter ingredient {i + 1} quantity: ");
                ingrQuantities[i] = double.Parse(Console.ReadLine());

                Console.Write($"Enter ingredient {i + 1} unit: ");
                ingrUnits[i] = Console.ReadLine();
            }

            Console.WriteLine("Enter the number of steps:");
            numSteps = Convert.ToInt32(Console.ReadLine());

            steps = new string[numSteps];

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}: ");
                steps[i] = Console.ReadLine();
            }

            lastAction = "Details";
            
        }

        public void Display()
        {// Method to display the users input 
            Console.WriteLine("The full Recipe is as follows:");

            for (int i = 0; i < ingrNames.Length; i++)
            {
                Console.WriteLine($"{ingrQuantities[i]}  {ingrUnits[i]} {ingrNames[i]}");
            }

            Console.WriteLine();

            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"Step {i + 1}: {steps[i]}");
            }
        }

        public void Scale()
        {
            Console.WriteLine("Would you like to scale the quantity (True/False): ");
            bool scaleFactor = bool.Parse(Console.ReadLine());

            if (scaleFactor)
            {
                Console.Write("Enter a scaling factor (0.5, 2, or 3): ");
                double scalingFactor = double.Parse(Console.ReadLine());

                for (int i = 0; i < ingrQuantities.Length; i++)
                {
                    ingrQuantities[i] *= scalingFactor;
                }

                Console.WriteLine("Recipe scaled successfully.");
            }
            else
            {
                Console.WriteLine("The scaling factor for the quantity has not been changed");
            }

            lastAction = "Scale";
        }

        public void Reset()
        {
            for (int i = 0; i < numIngredients; i++)
            {
                ingrQuantities[i] /= 2;
            }

            Console.WriteLine("Reset is successful");

            lastAction = "Reset";
        }

        public void ClearData()
        {
            Console.WriteLine("Are you sure you want to clear recipe data? (Y/N)");
            string choice = Console.ReadLine();

            if (choice.ToUpper() == "Y")
            {
                numIngredients = 0;
                numSteps = 0;
                ingrNames = null;
                ingrQuantities = null;
                ingrUnits = null;
                steps = null;
                recipeName = null;

                Console.WriteLine("Data has been cleared");
            }
            else
            {
                Console.WriteLine("No data has been cleared");
            }

            lastAction = "ClearData";
        }

        public void Menu()
        {
            RecipeIngredients myRecipe = new RecipeIngredients();
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset recipe");
                Console.WriteLine("5. Clear recipe data");
                Console.WriteLine("6. Quit");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        myRecipe.Details();
                        break;

                    case "2":
                        myRecipe.Display();
                        break;

                    case "3":
                        myRecipe.Scale();
                        break;

                    case "4":
                        myRecipe.Reset();
                        break;

                    case "5":
                        myRecipe.ClearData();
                        break;

                    case "6":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            RecipeIngredients myRecipe = new RecipeIngredients();
            myRecipe.Menu();
            Console.ResetColor();
        }
    }
}
