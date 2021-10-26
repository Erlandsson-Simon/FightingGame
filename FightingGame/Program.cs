using System;
using System.IO;
using System.Threading;

Boolean game = true;

int asciiSleepTime = 2000;
int roundSleepTime = 1500;

int roundNumber = 0;
int hitDamage;

int gold = 100;
int betAmount = 0;
string goldText = "You have";
string doesPlayerBet;
Boolean timeToBet = true;

int playerOneHp = 100;
int playerTwoHp = 100;

string playerOneName;
string playerTwoName;

string[] asciiPlayerOne = File.ReadAllLines(@"asciiTextPlayerOne");
string[] asciiPlayerTwo = File.ReadAllLines(@"asciiTextPlayerTwo");

string startOver;

playerOneName = NameChooser.PlayerOneNameChooser();

while (game)
{
    playerTwoName = NameChooser.PlayerTwoNameChooser();

    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine("-------------------- Player ONE --------------------");
    Console.WriteLine("----------------------------------------------------");

    /*----------------------------
      Ascci for player one print
    ----------------------------*/
    for (var i = 0; i < asciiPlayerOne.Length; i++)
    {
        Console.WriteLine(asciiPlayerOne[i]);
    }

    Thread.Sleep(asciiSleepTime);

    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine("-------------------- Player TWO --------------------");
    Console.WriteLine("----------------------------------------------------");

    /*----------------------------
      Ascci for player two print
    ----------------------------*/
    for (var i = 0; i < asciiPlayerTwo.Length; i++)
    {
        Console.WriteLine(asciiPlayerTwo[i]);
    }

    Thread.Sleep(roundSleepTime);

    /*----------------------------
            Main game start
    ----------------------------*/

    while (playerOneHp > 0 && playerTwoHp > 0)
    {
        while (timeToBet)
        {
            Console.WriteLine(goldText + " " + gold);
            Console.WriteLine("Would you like to bet on your next fight?");
            Console.WriteLine("Type, Yes or No");

            doesPlayerBet = Console.ReadLine();

            if (doesPlayerBet == "Yes" || doesPlayerBet == "yes")
            {
                Console.WriteLine("How much would you like to bet, you have " + gold + " remaining gold");
                betAmount = Convert.ToInt32(Console.ReadLine());
            }
            timeToBet = false;
        }

        roundNumber += 1;

        Console.WriteLine("Round: " + roundNumber + "----------------------------");

        /*----------------------------
            Player one hit check
        ----------------------------*/
        hitDamage = hit.DoesPlayerHit(playerOneHp, playerTwoHp);

        if (hitDamage == 0 && playerOneHp <= 0)
        {
            Console.WriteLine(".");
        }
        else if (hitDamage == 0)
        {
            Console.WriteLine(playerOneName + " missed!");
        }
        else
        {
            Console.WriteLine(playerOneName + " hit and did " + hitDamage + " damage");
            playerTwoHp -= hitDamage;
        }

        if (playerOneHp > 0 && playerTwoHp > 0)
        {
            Console.WriteLine(playerTwoName + " Remaining hp: " + playerTwoHp);
        }

        /*----------------------------
            Player two hit check
        ----------------------------*/
        hitDamage = hit.DoesPlayerHit(playerOneHp, playerTwoHp);

        if (hitDamage == 0 && playerOneHp > 0 && playerTwoHp > 0)
        {
            Console.WriteLine(playerTwoName + " missed!");
        }
        else if (playerOneHp > 0 && playerTwoHp > 0)
        {
            Console.WriteLine(playerTwoName + " hit and did " + hitDamage + " damage");
            playerOneHp -= hitDamage;
        }

        if (playerOneHp > 0 && playerTwoHp > 0)
        {
            Console.WriteLine(playerOneName + " Remaining hp: " + playerOneHp);
        }

        Console.WriteLine("");

        Thread.Sleep(roundSleepTime);
    }

    /*----------------------------
          Have anyone died
    ----------------------------*/

    if (playerOneHp <= 0 && playerTwoHp > 0)
    {
        Console.WriteLine(playerOneName + " lost!");
        Console.WriteLine("You lost " + betAmount + " gold");
        gold -= betAmount;
        Console.WriteLine("You now have " + gold + " gold");
    }

    if (playerOneHp > 0 && playerTwoHp <= 0)
    {
        Console.WriteLine(playerTwoName + " lost!");
        Console.WriteLine("You earned " + betAmount + " gold");
        gold += betAmount;
        Console.WriteLine("You now have " + gold + " gold");
    }

    if (playerOneHp <= 0 && playerTwoHp <= 0)
    {
        Console.WriteLine("The game has ended in a draw!");
        Console.WriteLine("You didn't earn or lose any gold.");
        Console.WriteLine("You have " + gold + ".");

    }

    Console.WriteLine("If you would like to fight again, type restart");

    startOver = Console.ReadLine();

    /*----------------------------
            Restart check
    ----------------------------*/

    if (startOver == "Restart" || startOver == "restart")
    {
        game = true;
        goldText = "You now have";
        timeToBet = true;

        playerOneHp = 100;
        playerTwoHp = 100;
    }
    else
    {
        game = false;
    }
}