using System;

class Bet
{

    public static int playerBet(bool timeToBet, int betAmount, int gold)
    {
        while (timeToBet)
        {
            string doesPlayerBet;

            Console.WriteLine("Would you like to bet on your next fight?");
            Console.WriteLine("Type, Yes or No");

            doesPlayerBet = Console.ReadLine();

            if (doesPlayerBet == "Yes" || doesPlayerBet == "yes")
            {
                Console.WriteLine("How much would you like to bet, you have " + gold + " remaining gold");
                betAmount = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                betAmount = 0;
            }
            timeToBet = false;
        }
        return betAmount;
    }
    public static int GoldAfterBet(int playerOneHp, int playerTwoHp, string playerOneName, string playerTwoName, int betAmount, int gold)
    {
        if (playerOneHp <= 0 && playerTwoHp > 0)
        {
            gold -= betAmount;
            Console.WriteLine(playerOneName + " lost!");
            Console.WriteLine("You lost " + betAmount + " gold");
            Console.WriteLine("You now have " + gold + " gold");
        }

        if (playerOneHp > 0 && playerTwoHp <= 0)
        {
            gold -= betAmount;
            Console.WriteLine(playerTwoName + " lost!");
            Console.WriteLine("You earned " + betAmount + " gold");
            Console.WriteLine("You now have " + gold + " gold");
        }

        if (playerOneHp <= 0 && playerTwoHp <= 0)
        {
            Console.WriteLine("The game has ended in a draw!");
            Console.WriteLine("You didn't earn or lose any gold.");
            Console.WriteLine("You have " + gold + ".");

        }
        return gold;
    }
}