// See https://aka.ms/new-console-template for more information
using System;
using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Welcome to Chirpus Market!");
bool InValid = true;
decimal mostExpensive = 0.0m;
string mostExpensiveItem = "";
decimal leastExpensive = decimal.MaxValue;
string leastexpensiveItem = "";
Dictionary<string, decimal> shoppingList = new Dictionary<string, decimal>
{
    {"apple",0.99m },
    {"banana",0.59m },
    {"cauliflower",1.59m },
    {"dragonfruit",2.19m },
    {"elderberry ",1.79m },
    {"figs",2.09m },
    {"grapefruit",1.99m },
    {"honeydew",3.49m }


};
List<string> cart = new List<string>();
decimal total = 0.0m;
int count = 0;
while (InValid)
{ 
    Console.WriteLine("Item\t\t\t\tPrice");
    Console.WriteLine("");
    Console.WriteLine("====================================");
    foreach(var n in shoppingList)
    {
        Console.WriteLine($"{n.Key.PadRight(16)}\t\t${n.Value}");
    }
    Console.WriteLine("What item would you like to order? ");
    string? userInput = Console.ReadLine().Trim();
    if(int.TryParse(userInput,out int choiceNum)){
        List<string> key = shoppingList.Keys.ToList();
        if (choiceNum <= key.Count && choiceNum>0)
        {
            string item = key[choiceNum - 1];
            if (shoppingList.ContainsKey(item))
            {
                cart.Add(item);
                Console.WriteLine($"Adding {item} to cart at ${shoppingList[item]}");
            }
        }
        else
        {
            Console.WriteLine($"Invalid input please enter 1-{shoppingList.Count}");
        }
    }
    else if(shoppingList.ContainsKey(userInput))
    {
    cart.Add(userInput);
    Console.WriteLine($"Adding {userInput} to cart at ${shoppingList[userInput]}");
    }
    else
    {
        Console.WriteLine("Invalid Option");
        continue;
    }
    Console.WriteLine("");

    while (InValid) 
    {
        Console.WriteLine("Would you like to order anything else (y/n)?");
        string? input = Console.ReadLine();
        if (input.ToLower() == "n" )
        {
            Console.Clear();
            Console.WriteLine("Thanks for your order!");
            Console.WriteLine("Here's what you got:");
            var sortedCart = cart.OrderBy(item => shoppingList[item]);// LINQ
            foreach (var n in sortedCart)
            {
                if (shoppingList.ContainsKey(n))                
                {
                    Console.WriteLine($"{n.PadRight(16)} ${shoppingList[n]}");
                    if (mostExpensive< shoppingList[n])
                    {
                        mostExpensive = shoppingList[n];
                        mostExpensiveItem = n;
                        
                    }
                    
                    
                    if (leastExpensive > shoppingList[n])
                    {
                            leastExpensive = shoppingList[n];
                            leastexpensiveItem = n;
                    }
                   
                    total += shoppingList[n];
                    count++;
                }
                else
                {
                    Console.WriteLine("Cart is empty");
                }
            }
            
            decimal average = total / count;
            Console.WriteLine($"Total cost : ${total}");
            Console.WriteLine($"The most expensive item in the cart : {mostExpensiveItem} :${mostExpensive}");
            Console.WriteLine($"The least expensive item in the cart : {leastexpensiveItem} :${leastExpensive}");
            Console.WriteLine($"Average price per item in order {Math.Round(average,2)} ");
            InValid = false;
            break;
        }
    else if(input.ToLower() == "y")
    {
            break;
    }
    else
    {
        Console.WriteLine("Invalid Option");
           
    }
}
}
