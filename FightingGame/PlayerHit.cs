using System;

class hit
{
    public static int DoesPlayerHit(int playerOneHp, int playerTwoHp)
    {
        Random generator = new Random();

        int x = generator.Next(1, 3);

        if (x == 1)
        {
            int damageAmount = generator.Next(10, 20);

            return damageAmount;
        }
        else
        {
            return 0;
        }
    }

}