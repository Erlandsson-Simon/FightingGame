using System;

class Bet
{
    /*Kollar ifall man vill betta och hur mycket*/
    public static int playerBet(bool timeToBet, int betAmount, int gold)
    {

        string doesPlayerBet;
        bool betQuestion = true;

        while (timeToBet)
        {
            Console.WriteLine("Would you like to bet on your next fight?");

            while (betQuestion)
            {
                Console.WriteLine("Type, Yes or No");

                doesPlayerBet = Console.ReadLine();

                if (doesPlayerBet == "Yes" || doesPlayerBet == "yes")
                {
                    Console.WriteLine("How much would you like to bet, you have " + gold + " remaining gold");
                    betAmount = Convert.ToInt32(Console.ReadLine());

                    betQuestion = false;
                }
                else if (doesPlayerBet == "No" || doesPlayerBet == "no")
                {
                    betAmount = 0;

                    betQuestion = false;
                }
                else
                {
                    Console.WriteLine("That is not a 'Yes' or a 'No', please try again :)");
                }
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
            gold += betAmount;
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