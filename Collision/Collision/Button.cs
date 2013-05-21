﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Collision
{
    public class Button: Sprite
    {
        MouseState oldMouseState;
        bool buttonClickedFirstPart = false;
        
        public Button(Texture2D textureImage, Vector2 position, Point frameSize,
            Point currentFrame, Point sheetSize, float angle, float depth)
            : base(textureImage, position, frameSize, currentFrame, sheetSize, angle, depth)
        {
        }

        public bool buttonPressed
        {
            get
            {
                Rectangle buttonBounds = new Rectangle((int)(position.X - frameSize.X / 2), (int)(position.Y - frameSize.Y / 2), (int)frameSize.X, (int)frameSize.Y);
                MouseState mouseState = Mouse.GetState(); 
                Rectangle mousePosition = new Rectangle(mouseState.X, mouseState.Y, 5, 5);

                if (mousePosition.Intersects(buttonBounds))
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        if (oldMouseState.LeftButton == ButtonState.Released)
                        {
                            buttonClickedFirstPart = true;
                        }
                    }
                }
                if (buttonClickedFirstPart)
                {
                    if (mousePosition.Intersects(buttonBounds))
                    {
                        if (mouseState.LeftButton == ButtonState.Released)
                        {
                            if (oldMouseState.LeftButton == ButtonState.Pressed)
                            {
                                buttonClickedFirstPart = false;
                                return true;
                            }
                        }
                    }
                }
                oldMouseState = mouseState;
                return false;
            }
        }

        public bool buttonHovered
        {
            get
            {
                Rectangle buttonBounds = new Rectangle((int)(position.X - frameSize.X / 2), (int)(position.Y - frameSize.Y / 2), (int)frameSize.X, (int)frameSize.Y);
                MouseState mouseState = Mouse.GetState();
                Rectangle mousePosition = new Rectangle(mouseState.X, mouseState.Y, 5, 5);

                if (mousePosition.Intersects(buttonBounds))
                    return true;

                return false;
            }
        }
    }
}
