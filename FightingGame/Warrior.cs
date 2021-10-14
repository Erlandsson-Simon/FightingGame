using System;

class fighting
{
    public static int DoesPlayerHit()
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