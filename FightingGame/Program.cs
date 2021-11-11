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
Boolean timeToBet = true;

int playerOneStartHp = 100;
int playerTwoStartHp = 100;

int playerOneHp = playerOneStartHp;
int playerTwoHp = playerTwoStartHp;

string playerOneName = "";
string playerTwoName;

/*här väljer jag att använda en array istället för en list för att 
jag vet att den ändå ska vara statisk och array laddar även in snabbare*/
string[] asciiPlayerOne = File.ReadAllLines(@"asciiTextPlayerOne");
string[] asciiPlayerTwo = File.ReadAllLines(@"asciiTextPlayerTwo");

string startOver;

/*------------------------------------------------
låter spelaren välja namn till spelare ett och ser 
till att namnet inte är för långt och inte för kort
--------------------------------------------------*/
playerOneName = NameChooser.PlayerOneNameChooser(playerOneName);

while (game)
{
    /*------------------------------
    Väljer ett namn till spelare två
    -------------------------------*/
    playerTwoName = NameChooser.PlayerTwoNameChooser();

    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine("-------------------- Player ONE --------------------");
    Console.WriteLine("----------------------------------------------------");

    /*------------------------
    Ascci bild för spelare ett
    -------------------------*/

    foreach (string line in asciiPlayerOne)
    {
        Console.WriteLine(line);
    }

    Thread.Sleep(asciiSleepTime);

    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine("-------------------- Player TWO --------------------");
    Console.WriteLine("----------------------------------------------------");

    /*------------------------
    Ascci bild för spelare två
    -------------------------*/
    foreach (string line in asciiPlayerTwo)
    {
        Console.WriteLine(line);
    }

    Thread.Sleep(roundSleepTime);

    /*--------
    spel start
    ---------*/
    while (playerOneHp > 0 && playerTwoHp > 0)
    {
        /*Kollar ifall spelaren vill 
        betta och isåfall hur mycket*/
        betAmount = Bet.playerBet(timeToBet, betAmount, gold);
        timeToBet = false;
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

        /*kollar så att båda spelarna fortfarande lever*/
        if (playerOneHp > 0 && playerTwoHp > 0)
        {
            Console.WriteLine(playerOneName + " Remaining hp: " + playerOneHp);
        }

        Thread.Sleep(roundSleepTime);
    }

    /*-------------------------
    kollar ifall någon har dött
    --------------------------*/

    gold = Bet.GoldAfterBet(playerOneHp, playerTwoHp, playerOneName, playerTwoName, betAmount, gold);

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