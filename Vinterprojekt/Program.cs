﻿using System.Numerics;
using System.Reflection.PortableExecutable;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Spel");
Raylib.SetTargetFPS(60);

Vector2 position = new Vector2(5, 5);
Vector2 movement = new Vector2 (0,0);

Color hotpink = new Color(255, 105, 180, 255);

Rectangle doorRect = new Rectangle(760, 20, 32, 32);

Rectangle bird = new Rectangle(300, 400, 64, 64);

float speed = 5;

string scene = "start";

int points = 0;

 while (!Raylib.WindowShouldClose())
        {
            // Uppdatera spellogik här
             if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                bird.y -= 50;
            }

            bird.y += 1;


            // Rita här
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);

            // Rita andra spelobjekt eller grafik här
            Raylib.DrawRectangleRec(bird, hotpink);
            Raylib.EndDrawing();
        }

        // Stäng Raylib-fönster när spelet avslutas
        Raylib.CloseWindow();
    
