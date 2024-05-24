using System;

namespace Shop
{
    class Products
    {
        static string username = "admin";
        static string password = "123";
        static bool isLoggedIn = false;
        static int[] productIds = { 1, 2, 3, 4, 5 };
        static string[] productNames = { "Apple iPhone 15", "Samsung S24 Ultra", "Google Pixel 8", "Xiaomi 14", "Realme 10 Pro" };
        static double[] productPrices = { 50000, 80000, 60000, 45000, 25000 };
        static int selectedProductId = -1;
        static int selectedQuantity = 0;

        static void Main(string[] args)
        {
            WelcomeScreen();
        }

        static void WelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome to our shop!");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            try
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        LoginScreen();
                        break;
                    case 2:
                        RegisterScreen();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key.");
                        Console.ReadKey();
                        WelcomeScreen();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Press any key.");
                Console.ReadKey();
                WelcomeScreen();
            }
        }

        static void LoginScreen()
        {
            Console.Clear();
            Console.Write("Enter username: ");
            string enteredUsername = Console.ReadLine();
            Console.Write("Enter password: ");
            string enteredPassword = Console.ReadLine();

            if (enteredUsername == username && enteredPassword == password)
            {
                isLoggedIn = true;
                ProductListScreen();
            }
            else
            {
                Console.WriteLine("Incorrect username or password. Press any key.");
                Console.ReadKey();
                WelcomeScreen();
            }
        }

        static void RegisterScreen()
        {
            Console.Clear();
            Console.WriteLine("Registration not implemented yet.");
            Console.WriteLine("Press any key.");
            Console.ReadKey();
            WelcomeScreen();
        }

        static void ProductListScreen()
        {
            Console.Clear();
            Console.WriteLine("Product List:");
            for (int i = 0; i < productIds.Length; i++)
            {
                Console.WriteLine($"{productIds[i]}. {productNames[i]} - Rs.{productPrices[i]}");
            }

            Console.Write("Enter product ID to select: ");
            try
            {
                selectedProductId = int.Parse(Console.ReadLine());
                if (Array.IndexOf(productIds, selectedProductId) != -1)
                {
                    Console.Write("Enter quantity: ");
                    selectedQuantity = int.Parse(Console.ReadLine());
                    ProductDetailsScreen();
                }
                else
                {
                    Console.WriteLine("Invalid product ID. Press any key.");
                    Console.ReadKey();
                    ProductListScreen();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Press any key.");
                Console.ReadKey();
                ProductListScreen();
            }
        }

        static void ProductDetailsScreen()
        {
            Console.Clear();
            int productIndex = Array.IndexOf(productIds, selectedProductId);
            Console.WriteLine($"Selected Product: {productNames[productIndex]}");
            Console.WriteLine($"Price: Rs.{productPrices[productIndex]}");
            Console.WriteLine($"Quantity: {selectedQuantity}");
            Console.WriteLine("\n1. Add to Cart");
            Console.WriteLine("2. Main Menu");
            Console.Write("Enter your choice: ");

            try
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CheckoutScreen();
                        break;
                    case 2:
                        WelcomeScreen();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key.");
                        Console.ReadKey();
                        ProductDetailsScreen();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Press any key.");
                Console.ReadKey();
                ProductDetailsScreen();
            }
        }

        static void CheckoutScreen()
        {
            Console.Clear();
            int productIndex = Array.IndexOf(productIds, selectedProductId);
            double totalPrice = productPrices[productIndex] * selectedQuantity;
            Console.WriteLine($"Product: {productNames[productIndex]}");
            Console.WriteLine($"Quantity: {selectedQuantity}");
            Console.WriteLine($"Total Price: Rs.{totalPrice}");
            Console.WriteLine("\nThank you!");
            Console.WriteLine("Press any key.");
            Console.ReadKey();
            WelcomeScreen();
        }
    }
}
