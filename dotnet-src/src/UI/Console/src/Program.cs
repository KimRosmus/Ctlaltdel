﻿using System.Runtime.CompilerServices;
using System.Text;
using Ctlaltdel.Models;

// all games need a game loop!

// we are going to need a game world now!
var level = new Level(20, 20);

// we are going to need a player
var player = new Player(new(10, 10));

var instructions = "wasd, or arrow keys to move, q to quit";

var feedbackMessage = "";

ConsoleKey? lastInput = null;

while (true)
{
    Console.Clear();
    
    Console.WriteLine(DrawMap());

    if (feedbackMessage != "")
    {
        Console.WriteLine($"{feedbackMessage}");
        feedbackMessage = "";
    }

    Console.WriteLine(instructions);

    var input = Console.ReadKey();
    lastInput = input.Key;

    if (lastInput == ConsoleKey.Q)
    {
        break;
    }

    AttemptLastCommand(lastInput.Value);
}

Console.WriteLine("Thank you for playing!");

string DrawMap()
{
    var visualMap = new StringBuilder();

    for (var x = 0; x < level.WidthX; x++)
    {
        for (var y = 0; y < level.DepthY; y++)
        {
            var room = level.Rooms.FirstOrDefault(rs => rs.Point.X == x && rs.Point.Y == y);
            if (player.Position.X == x && player.Position.Y == y)
            {
                visualMap.Append("x ");
            }
            else if (room.IsPassable)
            {
                visualMap.Append(". ");
            }
            else
            {
                visualMap.Append("@ ");
            }
        }
        visualMap.AppendLine();
    }
    return visualMap.ToString();
}

string AttemptToMove(int x, int y)
{
    var errorMessage = "";
    var currentRoom = level.Rooms.SingleOrDefault(rs => rs.Point.X == player.Position.X && rs.Point.Y == player.Position.Y);
    var nextRoom = level.Rooms.SingleOrDefault(rs => rs.Point.X == player.Position.X + x && rs.Point.Y == player.Position.Y + y);
    if (nextRoom is null || !nextRoom.IsPassable)
    {
        errorMessage = "Cannot move that direction, -1hp";
    }
    else
    {
        player.MovePosition(x, y);
    }
    return errorMessage;
}

void AttemptLastCommand(ConsoleKey lastInput) {
    switch (lastInput)
    {
        case ConsoleKey.W:
        case ConsoleKey.UpArrow:
            {
                feedbackMessage = AttemptToMove(-1, 0);
                break;
            }

        case ConsoleKey.D:
        case ConsoleKey.RightArrow:
            {
                feedbackMessage = AttemptToMove(0, 1);
                break;
            }

        case ConsoleKey.S:
        case ConsoleKey.DownArrow:
            {
                feedbackMessage = AttemptToMove(1, 0);
                break;
            }

        case ConsoleKey.A:
        case ConsoleKey.LeftArrow:
            {
                feedbackMessage = AttemptToMove(0, -1);
                break;
            }
    }
}