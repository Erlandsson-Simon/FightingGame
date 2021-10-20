using System;

class NameChooser
{
    public static string PlayerOneNameChooser()
    {
        string name;
        Boolean nameLength = true;

        Console.WriteLine("Type a name for player one, atleast 3 letters, max 10 letters.");

        while (nameLength)
        {
            name = Console.ReadLine();

            if (name.Length > 10)
            {
                Console.WriteLine("That name is to big, try another one.");
            }
            else if (name.Length < 3)
            {
                Console.WriteLine("That name is to short, try another one.");
            }
            else
            {
                nameLength = false;
                return name;
            }
        }
        return "";
    }
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