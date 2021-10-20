using System;
using System.IO;
using System.Threading;

Boolean game = true;

int asciiSleepTime = 1000;
int roundSleepTime = 500;

int roundNumber = 0;
int hitDamage;

int playerOneHp = 100;
int playerTwoHp = 100;

string playerOneName;
string playerTwoName;

string[] asciiPlayerOne = File.ReadAllLines(@"asciiTextPlayerOne");
string[] asciiPlayerTwo = File.ReadAllLines(@"asciiTextPlayerTwo");

string startOver;

while (game)
{
    playerOneName = NameChooser.PlayerOneNameChooser();
    playerTwoName = NameChooser.PlayerTwoNameChooser();


    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine("-------------------- Player ONE --------------------");
    Console.WriteLine("----------------------------------------------------");

    for (var i = 0; i < asciiPlayerOne.Length; i++)
    {
        Console.WriteLine(asciiPlayerOne[i]);
    }

    Thread.Sleep(asciiSleepTime);

    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine("-------------------- Player TWO --------------------");
    Console.WriteLine("----------------------------------------------------");

    for (var i = 0; i < asciiPlayerTwo.Length; i++)
    {
        Console.WriteLine(asciiPlayerTwo[i]);
    }

    Thread.Sleep(roundSleepTime);

    while (playerOneHp > 0 & playerTwoHp > 0)
    {
        roundNumber += 1;

        Console.WriteLine("Round: " + roundNumber + "----------------------------");

        //Player one hit check
        hitDamage = hit.DoesPlayerHit(playerOneHp, playerTwoHp);

        if (hitDamage == 0 & playerOneHp <= 0)
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

        if (playerTwoHp > 0)
        {
            Console.WriteLine(playerTwoName + " Remaining hp: " + playerTwoHp);
        }

        //Player two hit check
        hitDamage = hit.DoesPlayerHit(playerOneHp, playerTwoHp);

        if (hitDamage == 0 & playerOneHp > 0 & playerTwoHp > 0)
        {
            Console.WriteLine(playerTwoName + " missed!");
        }
        else if (playerOneHp > 0 & playerTwoHp > 0)
        {
            Console.WriteLine(playerTwoName + " hit and did " + hitDamage + " damage");
            playerOneHp -= hitDamage;
        }

        if (playerOneHp > 0)
        {
            Console.WriteLine(playerOneName + " Remaining hp: " + playerOneHp);
        }

        Console.WriteLine("");

        Thread.Sleep(roundSleepTime);
    }

    if (playerOneHp <= 0 & playerTwoHp > 0)
    {
        Console.WriteLine(playerOneName + " lost!");
    }
    if (playerOneHp > 0 & playerTwoHp <= 0)
    {
        Console.WriteLine(playerTwoName + " lost!");
    }
    if (playerOneHp <= 0 & playerTwoHp <= 0)
    {
        Console.WriteLine("The game has ended in a draw!");
    }

    Console.WriteLine("If you would like to play again, write restart");

    startOver = Console.ReadLine();

    if (startOver == "Restart" || startOver == "restart")
    {
        game = true;
    }
    else
    {
        game = false;
    }
}

Console.WriteLine("test");
Console.ReadLine();