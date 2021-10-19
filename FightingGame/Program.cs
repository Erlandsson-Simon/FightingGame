using System;

int playerOneHp = 100;
int playerTwoHp = 100;

int hitDamage;

string playerOneName;
string playerTwoName = "steve";

Console.WriteLine("Type a name for player one");
playerOneName = Console.ReadLine();

playerTwoName = NameChooser.PlayerTwoNameChooser();

while (playerOneHp > 0 & playerTwoHp > 0)
{
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
    }

    playerTwoHp -= hitDamage;
    
    if (playerTwoHp > 0)
    {
        Console.WriteLine(playerTwoName + " Remaining hp: " + playerTwoHp);
    }

    //Player two hit check
    hitDamage = hit.DoesPlayerHit(playerOneHp, playerTwoHp);

    if (hitDamage == 0 || playerOneHp > 0 || playerTwoHp > 0)
    {
        Console.WriteLine(playerTwoName + " missed!");
    }
    else
    {
        Console.WriteLine(playerTwoName + " hit and did " + hitDamage + " damage");
    }

    playerOneHp -= hitDamage;
    
    if (playerOneHp > 0)
    {
        Console.WriteLine(playerOneName + " Remaining hp: " + playerOneHp);
    }
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
Console.ReadLine();