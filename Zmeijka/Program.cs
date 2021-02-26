using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Zmeijka
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.SetWindowSize(115, 35);

			Walls walls = new Walls(100, 30);
			walls.Draw();

			// Отрисовка точек			
			Point p = new Point(4, 5, '*',ConsoleColor.Green);
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(100, 30, '¤', ConsoleColor.Green);
			Point food = foodCreator.CreateFood();
			food.Draw();

			Score score = new Score(0,1,50);
			score.ScoreWrite();

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food))
				{
					food = foodCreator.CreateFood();
					food.Draw();
					score.ScoreUp();
					score.ScoreWrite();
					if (score.ScoreUp())
                    {
						score.Speed -= 10;
                    }

		
				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(score.Speed);
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
			WriteGameOver();
			Console.ReadLine();
		}


		static void WriteGameOver()
		{
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("        GAME OVER", xOffset + 1, yOffset++);
			yOffset++;
			WriteText(" Autor: Aleksei Tiora", xOffset + 2, yOffset++);
			WriteText("", xOffset + 1, yOffset++);
			WriteText("============================", xOffset, yOffset++);
		}

		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
	}
}
