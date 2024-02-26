﻿using System.Numerics;
using System.Reflection.PortableExecutable;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Spel");
Raylib.SetTargetFPS(60);

Vector2 position = new Vector2(5, 5);
Vector2 movement = new Vector2(0, 0);

Color hotpink = new Color(255, 105, 180, 255);

//Rectangle bird = new Rectangle(300, 400, 64, 64);

Rectangle gryphonRect = new Rectangle(300, 400, 64, 64);
Texture2D characterImage = Raylib.LoadTexture("gryphon1.png");
// Console.ReadLine();

Rectangle[] obstacles = new Rectangle[5];
int obstacleSpeed = 5;

for (int i = 0; i < obstacles.Length; i++)
{
    obstacles[i] = new Rectangle(800 + i * 200, 100, 50, new Random().Next(100, 300));
}

float speed = 5;

string scene = "start";

int points = 0;

while (!Raylib.WindowShouldClose())
{
    if (scene =="start")
    {

    }
    else if (scene == "game")
    {

    }
    
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
    {
        gryphonRect.y -= 50;
    }

    gryphonRect.y += 1;

    for (int i = 0; i < obstacles.Length; i++)
    {

        obstacles[i].x -= obstacleSpeed;
        if (obstacles[i].x <= 0 - obstacles[i].width)
        {
            obstacles[i].x = 800;
            obstacles[i].y = new Random().Next(50, 400);
            obstacles[i].height = new Random().Next(50, 200);
            points++;
        }

        if (Raylib.CheckCollisionRecs(gryphonRect, obstacles[i]))
        {
            scene = "finished";
            points++;
        }
    }

    Raylib.BeginDrawing();
    if (scene == "start")
    {
        Raylib.ClearBackground(Color.BLUE);
        Raylib.DrawText("PRESS SPACE TO START", 10, 10, 32, Color.WHITE);
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            scene = "game";
        }
    }

    if (scene == "game")
    {
        Raylib.ClearBackground(Color.BLUE);
        Raylib.DrawTexture(characterImage, (int)gryphonRect.x, (int)gryphonRect.y, Color.WHITE);
       
        for (int i = 0; i < obstacles.Length; i++)
        {
            Raylib.DrawRectangleRec(obstacles[i], Color.GREEN);
        }
        

        Raylib.DrawText(points.ToString(), 10, 10, 32, Color.WHITE);
    }
    else if (scene == "finished")
    {
        Raylib.ClearBackground(Color.YELLOW);
        Raylib.DrawText("GAME OVER! PRESS SPACE TO TRY AGAIN", 10, 10, 32, Color.WHITE);
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            scene = "game";
        }
    }

    
    Raylib.DrawRectangleRec(gryphonRect, hotpink);
    Raylib.EndDrawing();

}

Raylib.CloseWindow();

