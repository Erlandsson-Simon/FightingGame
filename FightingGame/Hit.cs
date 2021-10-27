using System;

class hit
{
    public static int DoesPlayerHit()
    {
        int damageAmount;

        Random generator = new Random();

        int x = generator.Next(1, 3);

        if (x == 1)
        {
            damageAmount = generator.Next(10, 20);
        }
        else
        {
            damageAmount = 0;
        }

        return damageAmount;
    }

}