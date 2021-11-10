using System;

class NameChooser
{
    /*säger till användaren att skriva in ett namn och ser sedan till 
    att namnet håller en viss standard, exempelvis minst tre bokstäver*/
    public static string PlayerOneNameChooser(string playerOneName)
    {
        Boolean nameLength = true;

        Console.WriteLine("Type a name for player one, atleast 3 letters, max 10 letters.");

        while (nameLength)
        {
            playerOneName = Console.ReadLine();

            if (playerOneName.Length > 10)
            {
                Console.WriteLine("That name is to big, try a shorter one.");
            }
            else if (playerOneName.Length < 3)
            {
                Console.WriteLine("That name is to short, try a longer one.");
            }
            else
            {
                nameLength = false;

            }
        }
        return playerOneName;
    }

    /*väljer ett namn till spelare två med hjälp av slupen*/
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