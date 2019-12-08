# ToyRobotSimulator
-----

### Tools Used 
C# v4.0.30319,
NUnit 3.12.0, 
Visual Studio for Mac v8.3.10 (build 2)
 

### Description

This is a Toy Robot Simulator. Toy Robot is moving according to instructions on a 5x5 table top. The instructions are supplied in the input file.


The commands are "PLACE", "MOVE", "LEFT", "RIGHT" and "REPORT".
"PLACE" command places the Toy Robot in position according to coordinates.
"MOVE" command makes Toy Robot take a steo forward its facing direction.
"LEFT" command changes Toy Robot's facing to the one on the left.
"RIGHT" command changes Toy Robot's facing to the one on the right.
"REPORT" command finishes movement and prints the output.

Toy Robot ignores all commands before the initial "PLACE" command. Toy Robot ignores all steps that cause the robot to fall off the table.

### Compilation

The program can be compiled in an IDE that supports C# i.e. Visual Studio.

### Input Files

Input files are stored in the InputFiles folder in the ToyRobotSimulator project. 

The input file names can be changed and specified in the file "Program.cs" on line 33.

### Unit Tests
Unit tests are provided in the repository. To run the tests i.e. in Visual Studio open the file "TestRobotToySimulator.cs" navigate to "Run" and press "Run Unit Tests".
