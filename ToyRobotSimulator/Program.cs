using System;
using System.Collections.Generic;
using System.IO;

namespace ToyRobotSimulator
{
    /// <summary>
    /// A class of the Robot object.
    /// </summary>
    public class Robot
    {
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
        public string facing { get; set; }
        public string instructions { get; set; }

    }
    /// <summary>
    /// Main class containing all code for the simulator.
    /// </summary>
    public class MainClass
    {
        public static Robot ToyRobot = new Robot(); 
        public static List<string> commands = new List<string>(); //List storing instructions to execute
        public static Boolean isInitialPlacement=false; //A boolean variable to check whether a Toy Robot has initial placement

        /// <summary>
        /// Main method containing methods to read an input file and execute movement.
        /// </summary>
        /// <param name="args">Arguments.</param>
        public static void Main(string[] args)
        {
            ToyRobot.instructions = "Input1.txt"; //Setting the name of the instructions input file 

            ReadFromFile(ToyRobot.instructions); 

            ExecuteMovement();

        }

        /// <summary>
        /// Authenticates a user based on a username and password.
        /// </summary>
        /// <param name="filename">Name of the input file.</param>
        public static void ReadFromFile(string fileName)
        {
            int lineNumber = 0;

            //Setting up the Stream Reader to read from input file
            using (var reader = new StreamReader("../../InputFiles/" + fileName, System.Text.Encoding.UTF8))
            {
                string line;

                //Reading each line of the input file
                while ((line = reader.ReadLine()) != null)
                {
                    //Changing input to be all uppser case to avoid invalid input
                    line = line.ToUpper();

                    //If statement that determines whether instructions contain an initial "Place" command
                    //If the first letter of the string is "P" that means a "Place" command exists
                    if (line[0].Equals('P'))
                    {
                        //If Toy Robot has not been placed yet, set its initial position
                        if (isInitialPlacement == false)
                        {
                            PlacementCommand(line, ToyRobot);
                        }
  
                        commands.Add(line);
                    }
                    //If Toy Robot has been initially placed, other commands can be executed.
                    //This if statement helps ignore any commands before the first "Place" command in the instructions
                    else if (isInitialPlacement == true)
                    {
                        commands.Add(line);
                    }

                    lineNumber++;

                }
            }

        }
        /// <summary>
        /// Executes the instructions which move the Toy Robot.
        /// </summary>
        public static void ExecuteMovement()
        {
            //If statement to determine whether Toy Robot was initially placed (whether instructions contained at least one "Place" command)
            if (isInitialPlacement == true)
            {
                isInitialPlacement = false;

                for (int i = 1; i < commands.Count; i++)
                {
                    var command = commands[i];

                    if (command.Equals("MOVE"))
                    {

                        MoveCommand(ToyRobot.facing, ToyRobot);

                    }
                    else if (command.Equals("LEFT"))
                    {

                        LeftCommand(ToyRobot.facing, ToyRobot);

                    }
                    else if (command.Equals("RIGHT"))
                    {

                        RightCommand(ToyRobot.facing, ToyRobot);

                    }
                    else if (command.Equals("REPORT"))
                    {
                        //Writes output into console
                        Console.WriteLine(ReportCommand(ToyRobot));
                    }
                    else if (command[0].Equals('P'))
                    {

                        PlacementCommand(command, ToyRobot);

                    }
                }
            }
            //Throws exception if and only if no "Place" command was found in the input file
            else
            {
                throw new Exception("Toy Robot was not placed for movement");

            }

        }

        /// <summary>
        /// Makes Toy Robot step forward towards where it is facing.
        /// </summary>
        /// <param name="x">x coordinate if the step would be taken.</param>
        /// <param name="y">y coordinate if the step would be taken.</param>
        /// <param name="f">Current facing of the Toy Robot.</param>
        /// <param name="robot">The object of the Toy Robot which would be taking the step.</param>
        public static void MakeAStep(int x, int y, string f, Robot robot)
        {
            //If statement that determines whether the step would make the Toy Robot fall
            if (x >= 0 && x <= 4 && y >= 0 && y <= 4)
            {
                robot.xCoordinate = x;
                robot.yCoordinate = y;
                robot.facing = f;

            }

        }

        /// <summary>
        /// Executes a "Move" command. A "Move" command makes Toy Robot take one step toward the side it is facing.
        /// </summary>
        /// <param name="currentFacing">Current facing of the Toy Robot.</param>
        /// <param name="robot">The object of the Toy Robot which would be taking the step.</param>
        public static void MoveCommand(string currentFacing, Robot robot)
        {
            if (currentFacing.Equals("NORTH"))
            {
                MakeAStep(robot.xCoordinate, robot.yCoordinate + 1, robot.facing, robot);
            }
            else if (currentFacing.Equals("EAST"))
            {
                MakeAStep(robot.xCoordinate + 1, robot.yCoordinate, robot.facing, robot);
            }
            else if (currentFacing.Equals("SOUTH"))
            {
                MakeAStep(robot.xCoordinate, robot.yCoordinate - 1, robot.facing, robot);
            }
            else if (currentFacing.Equals("WEST"))
            {
                MakeAStep(robot.xCoordinate - 1, robot.yCoordinate, robot.facing, robot);
            }
        }

        /// <summary>
        /// Executes a "Left" command. A "Left" command changes Toy Robot's facing to the one on the left.
        /// </summary>
        /// <param name="currentFacing">Current facing of the Toy Robot.</param>
        /// <param name="robot">The object of the Toy Robot which would be taking the step.</param>
        public static void LeftCommand(string currentFacing, Robot robot)
        {
            if (currentFacing.Equals("NORTH"))
            {
                robot.facing = "WEST";
            }
            else if (currentFacing.Equals("EAST"))
            {
                robot.facing = "NORTH";
            }
            else if (currentFacing.Equals("SOUTH"))
            {
                robot.facing = "EAST";
            }
            else if (currentFacing.Equals("WEST"))
            {
                robot.facing = "SOUTH";
            }
        }

        /// <summary>
        /// Executes a "Right" command. A "Right" command changes Toy Robot's facing to the one on the right.
        /// </summary>
        /// <param name="currentFacing">Current facing of the Toy Robot.</param>
        /// <param name="robot">The object of the Toy Robot which would be taking the step.</param>
        public static void RightCommand(string currentFacing, Robot robot)
        {
            
            if (currentFacing.Equals("NORTH"))
            {
                robot.facing = "EAST";
            }
            else if (currentFacing.Equals("EAST"))
            {
                robot.facing = "SOUTH";
            }
            else if (currentFacing.Equals("SOUTH"))
            {
                robot.facing = "WEST";
            }
            else if (currentFacing.Equals("WEST"))
            {
                robot.facing = "NORTH";
            }

        }
        /// <summary>
        /// Executes a "Report" command. A "Report" command retrieves the output formatted in a desired way.
        /// </summary>
        /// <param name="robot">The object of the Toy Robot which would be taking the step.</param>
        /// <returns>
        /// String formatted in a desired way.
        /// </returns>
        public static string ReportCommand(Robot robot)
        {

            return robot.xCoordinate + "," + robot.yCoordinate + "," + robot.facing;
        }

        /// <summary>
        /// Executes a "Place" command. A "Place" command positions Toy Robot in the supplied coordinates.
        /// </summary>
        /// <param name="placeCommand">String containing the name of the command and coordinates with facing.</param>
        /// <param name="robot">The object of the Toy Robot which would be taking the step.</param>
        public static void PlacementCommand(string placeCommand, Robot robot)
        {
            //String is split on commas
            var placingCoordinates = placeCommand.Split(' ')[1].Split(',');
            var coordinateX = Int32.Parse(placingCoordinates[0]);
            var coordinateY = Int32.Parse(placingCoordinates[1]);
            var facing = placingCoordinates[2];

            //If statement that checks whether the supplied coordinates are valid
            if (coordinateX >= 0 && coordinateX <= 4 && coordinateY >= 0 && coordinateY <= 4)
            {
                robot.xCoordinate = coordinateX;
                robot.yCoordinate = coordinateY;
                robot.facing = facing;

                isInitialPlacement = true;
                
                

            }
            //Throws exception if and only if the coordinates supplied are not valid
            else
            {
                throw new Exception("Coordinates supplied in a 'PLACE' command are invalid");
            }
        }
    }
}