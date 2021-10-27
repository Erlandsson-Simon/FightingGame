using System;

class DamageTaken
{
    public static int PlayerOneDamageTakenAmount(int hitDamage, int playerOneHp, int playerTwoHp, string playerTwoName)
    {
        if (hitDamage == 0 && playerOneHp > 0 && playerTwoHp > 0)
        {
            Console.WriteLine(playerTwoName + " missed!");
        }
        else if (playerOneHp > 0 && playerTwoHp > 0)
        {
            Console.WriteLine(playerTwoName + " hit and did " + hitDamage + " damage");
            playerOneHp -= hitDamage;
        }
        return playerOneHp;
    }

    public static int PlayerTwoDamageTakenAmount(int hitDamage, int playerOneHp, int playerTwoHp, string playerOneName)
    {
        if (hitDamage == 0 && playerOneHp > 0 && playerTwoHp > 0)
        {
            Console.WriteLine(playerOneName + " missed!");
        }
        else if (playerOneHp > 0 && playerTwoHp > 0)
        {
            Console.WriteLine(playerOneName + " hit and did " + hitDamage + " damage");
            playerTwoHp -= hitDamage;
        }
        return playerTwoHp; 
    }

}