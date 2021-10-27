using System;
using System.IO;
using System.Threading;

Boolean game = true;

int asciiSleepTime = 2000;
int roundSleepTime = 1500;

int roundNumber = 0;
int damageAmount;

int gold = 100;
int betAmount = 0;
string doesPlayerBet;
Boolean timeToBet = true;

int playerOneStartHp = 100;
int playerTwoStartHp = 100;

int playerOneHp = playerOneStartHp;
int playerTwoHp = playerTwoStartHp;

string playerOneName;
string playerTwoName;

string[] asciiPlayerOne = File.ReadAllLines(@"asciiTextPlayerOne");
string[] asciiPlayerTwo = File.ReadAllLines(@"asciiTextPlayerTwo");

string startOver;

/*-------------------------------------------
Makes sure player name isnt too short or long
---------------------------------------------*/
playerOneName = NameChooser.PlayerOneNameChooser();

while (game)
{
    /*---------------------------
    Chooses a name for player two.
    ----------------------------*/
    playerTwoName = NameChooser.PlayerTwoNameChooser();

    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine("-------------------- Player ONE --------------------");
    Console.WriteLine("----------------------------------------------------");

    /*------------------------
    Ascci for player one print
    -------------------------*/
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

    /*-------------
    Main game start
    --------------*/
    while (playerOneHp > 0 && playerTwoHp > 0)
    {
        while (timeToBet)
        {
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

        /*Kollar ifall spelare ett gjort skada 
        och hur mycket*/
        damageAmount = hit.DoesPlayerHit();

        /*Kollar hur mycket hp spelare ett har 
        kvar efter gjord skada och printar det*/
        playerTwoHp = DamageTaken.PlayerTwoDamageTakenAmount(damageAmount, playerOneHp, playerTwoHp, playerOneName);

        if (playerOneHp > 0 && playerTwoHp > 0)
        {
            Console.WriteLine(playerTwoName + " Remaining hp: " + playerTwoHp);
        }

        /*Kollar ifall spelare två gjort skada 
        och hur mycket*/
        damageAmount = hit.DoesPlayerHit();

        /*Kollar hur mycket hp spelare två har 
        kvar efter gjord skada och printar det*/
        playerOneHp = DamageTaken.PlayerOneDamageTakenAmount(damageAmount, playerOneHp, playerTwoHp, playerTwoName);

        if (playerOneHp > 0 && playerTwoHp > 0)
        {
            Console.WriteLine(playerOneName + " Remaining hp: " + playerOneHp);
        }

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
        timeToBet = true;

        playerOneHp = playerOneStartHp;
        playerTwoHp = playerTwoStartHp;
    }
    else
    {
        game = false;
    }
}