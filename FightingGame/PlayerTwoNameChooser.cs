using System;

class NameChooser
{
    public static string PlayerTwoNameChooser()
    {
        string playerTwoName;

        Random generator = new Random();
        int name = generator.Next(1, 6);

        if (name == 1)
        {
            playerTwoName = "Jessica";
        }
        else if (name == 2)
        {
            playerTwoName = "Karim";
        }
        else if (name == 3)
        {
            playerTwoName = "Anh Tu Tran";
        }
        else if (name == 4)
        {
            playerTwoName = "Michael";
        }
        else
        {
            playerTwoName = "Julia";
        }

        return playerTwoName;
    }

}