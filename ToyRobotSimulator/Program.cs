using System;
using System.Collections.Generic;
using System.IO;

namespace ToyRobotSimulator
{
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string F { get; set; }

    }

    class MainClass
    {
        public static Robot ToyRobot = new Robot();
        public static List<string> commands = new List<string>(); //A list that will store all the commands from a file
        public static string facing;
        public static Boolean isInitialPlacement = false;

        public static void Main(string[] args)
        {

            ReadFromFile();

            //Initial placement of toy robot
            if (isInitialPlacement == true)
            {
                var placingCoordinates = commands[0].Split(' ')[1].Split(',');
                var x = Int32.Parse(placingCoordinates[0]);
                var y = Int32.Parse(placingCoordinates[1]);
                facing = placingCoordinates[2];

                if(x>=0 && x<=4 && y >= 0 && y <= 4)
                {
                    ToyRobot.X = x;
                    ToyRobot.Y = y;
                    ToyRobot.F = facing;

                }

                ExecuteMovement();

            }
            else
            {
                Console.WriteLine("Toy Robot was not placed for movement");
            }



        }

        public static void ReadFromFile()
        {
            int lineNo = 0;
            //Reading the input commands
            using (var reader = new StreamReader("Input1.txt"))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line[0].Equals('P'))
                    {
                        isInitialPlacement = true;
                        commands.Add(line);
                    }
                    else if(isInitialPlacement == true)
                    {
                        commands.Add(line);
                    }
                    lineNo++;
                    
                }
            }
        }

        public static void ExecuteMovement()
        {

            for(int i=1; i<commands.Count; i++)
            {
                var command = commands[i];

                if (command.Equals("MOVE"))
                {
                    if (ToyRobot.F.Equals("NORTH"))
                    {
                        MakeAMove(ToyRobot.X, ToyRobot.Y+1, ToyRobot.F);
                    }
                    else if (ToyRobot.F.Equals("EAST"))
                    {
                        MakeAMove(ToyRobot.X+1, ToyRobot.Y, ToyRobot.F);
                    }
                    else if (ToyRobot.F.Equals("SOUTH"))
                    {
                        MakeAMove(ToyRobot.X, ToyRobot.Y-1, ToyRobot.F);
                    }
                    else
                    {
                        MakeAMove(ToyRobot.X-1, ToyRobot.Y, ToyRobot.F);
                    }
                }
                else if (command.Equals("LEFT"))
                {
                    if (ToyRobot.F.Equals("NORTH"))
                    {
                        ToyRobot.F="WEST";
                    }
                    else if (ToyRobot.F.Equals("EAST"))
                    {
                        ToyRobot.F = "NORTH";
                    }
                    else if (ToyRobot.F.Equals("SOUTH"))
                    {
                        ToyRobot.F = "EAST";
                    }
                    else
                    {
                        ToyRobot.F = "SOUTH";
                    }
                }
                else if (command.Equals("RIGHT"))
                {
                    if (ToyRobot.F.Equals("NORTH"))
                    {
                        ToyRobot.F = "EAST";
                    }
                    else if (ToyRobot.F.Equals("EAST"))
                    {
                        ToyRobot.F = "SOUTH";
                    }
                    else if (ToyRobot.F.Equals("SOUTH"))
                    {
                        ToyRobot.F = "WEST";
                    }
                    else
                    {
                        ToyRobot.F = "NORTH";
                    }
                }
                else if (command.Equals("REPORT"))
                {
                    Console.WriteLine(ToyRobot.X+","+ToyRobot.Y+","+ToyRobot.F);
                }
                else
                {
                    var placingCoordinates = commands[0].Split(' ')[1].Split(',');
                    var x = Int32.Parse(placingCoordinates[0]);
                    var y = Int32.Parse(placingCoordinates[1]);
                    facing = placingCoordinates[2];
                    MakeAMove(x, y, facing);

                }
            }

        }

        public static void MakeAMove(int x, int y, string f)
        {

            if (x >= 0 && x <= 4 && y >= 0 && y <= 4)
            {
                ToyRobot.X = x;
                ToyRobot.Y = y;
                ToyRobot.F = f;

            }

        }

    }
}
