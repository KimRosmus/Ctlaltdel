﻿using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            // Greet the players
            Console.WriteLine("Welcome to the ultimate showdown: Rock, Paper, Scissors!");

            // Prompt the player to choose their weapon
            Console.WriteLine("Prepare yourself, and choose wisely...");
            Console.WriteLine("(R)ock, (P)aper, or (S)cissors?");

            // Get the player's choice
            Console.Write("Your choice: ");
            char playerChoice = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            // Let the computer make its move
            Random random = new Random();
            char[] choices = { 'R', 'P', 'S' };
            char computerChoice = choices[random.Next(0, 3)];

            // Reveal the computer's choice
            Console.WriteLine("The computer has made its decision...");
            Console.WriteLine("Computer chooses: " + computerChoice);

            // Determine the outcome
            if (playerChoice == computerChoice)
            {
                Console.WriteLine("It's a tie! A worthy match, indeed.");
            }
            else if ((playerChoice == 'R' && computerChoice == 'S') ||
                     (playerChoice == 'P' && computerChoice == 'R') ||
                     (playerChoice == 'S' && computerChoice == 'P'))
            {
                Console.WriteLine("Victory is yours! Your prowess is unmatched.");
            }
            else
            {
                Console.WriteLine("Alas, the computer has emerged victorious. A valiant effort, nonetheless.");
            }

            // Ask if the player wants to play again
            Console.WriteLine("Do you want to play again? (Y/N)");
            char response = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            playAgain = (response == 'Y');
        }

        Console.WriteLine("Thank you for playing! Farewell.");
    }
}
