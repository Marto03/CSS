<<<<<<< HEAD
﻿namespace ConsoleApp1 
=======
﻿namespace ConsoleApp1
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Input 12 hour format (Hours:Mins:Secs PM/AM): ");
            string userInput = Console.ReadLine();
            //string[] parts = userInput.Split(':', ' ');
            string[] parts = userInput.Split(' ');

            string hoursPart = "";
            string minsPart = "";
            string secsPart = "";
            string timeZone = "";

            bool flag = false;
            int hour = 0;
            int mins = 0;
            int secs = 0;
            do
            {
<<<<<<< HEAD
                if(parts.Length == 2)
=======
                if (parts.Length == 2)
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
                {
                    string timePart = parts[0];
                    timeZone = parts[1];

                    string[] timeParts = timePart.Split(':');

<<<<<<< HEAD
                    if(timeParts.Length == 3)
=======
                    if (timeParts.Length == 3)
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
                    {
                        hoursPart = timeParts[0];
                        minsPart = timeParts[1];
                        secsPart = timeParts[2];
                    }
<<<<<<< HEAD
                    else if(timeParts.Length == 2)
=======
                    else if (timeParts.Length == 2)
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
                    {
                        hoursPart = timeParts[0];
                        minsPart = timeParts[1];
                    }
                }
<<<<<<< HEAD
                
                /*if (parts.Length == 4)
                {
                    hoursPart = parts[0];
                    minsPart = parts[1];
                    secsPart = parts[2];
                    timeZone = parts[3];
                }
                else if (parts.Length == 3)
                {
                    hoursPart = parts[0];
                    minsPart = parts[1];
                    timeZone = parts[2];
                }*/

                if (int.TryParse(hoursPart, out hour) && int.TryParse(minsPart, out mins))
                    {
                        int.TryParse(secsPart, out secs);
                        if (hour > 12 || mins > 60 || secs > 60)
                        {
                            Console.WriteLine("Invalid time!");
                            userInput = Console.ReadLine();
                            parts = userInput.Split(' ');
                            flag = false;
                        }
                        else if (timeZone == "AM")
                        {
                            flag = true;
                        }
                        else if (timeZone == "PM")
                        {
                            hour += 12;
                            if (hour == 24)
                            {
                                hour = 0;
                            }
                            flag = true;
                        }
                        else
                        {
                            Console.WriteLine("Must be PM or AM!");
                            userInput = Console.ReadLine();
                            parts = userInput.Split(' ');
                            flag = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input!");
                        Console.WriteLine("Input must be in this way:(Hours:Mins:Secs PM/AM):");
=======
                if (int.TryParse(hoursPart, out hour) && int.TryParse(minsPart, out mins))
                {
                    int.TryParse(secsPart, out secs);

                    if (hour > 12 || mins > 60 || secs > 60)
                    {
                        Console.WriteLine("Invalid time!");
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
                        userInput = Console.ReadLine();
                        parts = userInput.Split(' ');
                        flag = false;
                    }
<<<<<<< HEAD

            } while (flag == false);


=======
                    else if (timeZone == "AM")
                    {
                        flag = true;
                    }
                    else if (timeZone == "PM")
                    {
                        hour += 12;
                        if (hour == 24)
                        {
                            hour = 0;
                        }
                        flag = true;
                    }
                    else
                    {
                        Console.WriteLine("Must be PM or AM!");
                        userInput = Console.ReadLine();
                        parts = userInput.Split(' ');
                        flag = false;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input!");
                    Console.WriteLine("Input must be in this way:(Hours:Mins:Secs PM/AM):");
                    userInput = Console.ReadLine();
                    parts = userInput.Split(' ');
                    flag = false;
                }

            } while (flag == false);

>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
            TimeOnly time = new TimeOnly(hour, mins, secs);

            Console.WriteLine($"{time:HH:mm:ss}");

            string formatedHour = hour.ToString("D2");
            string formatedMins = mins.ToString("D2");
            string formatedSecs = secs.ToString("D2");

            Console.WriteLine($"{formatedHour}:{formatedMins}:{formatedSecs}");


        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
