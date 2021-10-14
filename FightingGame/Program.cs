using System;

int playerOneHp = 100;
int playerTwoHp = 100;

int hitDamage;

while (playerOneHp > 0 & playerTwoHp > 0)
{
    //Player one hit check
    hitDamage = fighting.DoesPlayerHit();
    if (hitDamage == 0)
    {
        Console.WriteLine("Player one missed!");
    }
    else
    {
        Console.WriteLine("Player One hit and did " + hitDamage + "damage");
    }
    playerTwoHp -= hitDamage;
    Console.WriteLine("Player Two Remaining hp: " + playerTwoHp);

    //Player two hit check
    hitDamage = fighting.DoesPlayerHit();

    if (hitDamage == 0)
    {
        Console.WriteLine("Player two missed!");
    }
    else
    {
        Console.WriteLine("Player two hit and did " + hitDamage + "damage");
    }

    playerOneHp -= hitDamage;
    Console.WriteLine("Player One Remaining hp: " + playerOneHp);

    Console.WriteLine(hitDamage);

}
if (playerOneHp < 0 & playerTwoHp > 0)
{
    Console.WriteLine("Player one lost!");
}
if (playerOneHp > 0 & playerTwoHp < 0)
{
    Console.WriteLine("Player Two lost!");
}
if (playerOneHp < 0 & playerTwoHp < 0)
{
    Console.WriteLine("The game has ended in a draw!");
}
Console.ReadLine();