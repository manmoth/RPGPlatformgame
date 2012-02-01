using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;

namespace WindowsGame1
{
    class Map
    {
        Texture2D[] Backgrounds;
        Texture2D[] Foregrounds;

        Texture2D StepCorner;
        Texture2D StepHorizontal;
        
        Vector2 BackgroundPos;

        private int Karma { get; set; }

        List<Stairssteps> Stairs;

        public void Initialize()
        {
            Stairs = new List<Stairssteps>();
        }
        public void InitializePhysics(World world)
        {
            addSteps(world);
        }
        public void LoadContent(Texture2D StepCorner, Texture2D StepHorizontal, Texture2D[] Backgrounds, Texture2D[] Foregrounds)
        {
            BackgroundPos = new Vector2(0, 0);
            this.Backgrounds = Backgrounds;
            this.Foregrounds = Foregrounds;
            this.StepCorner = StepCorner;
            this.StepHorizontal = StepHorizontal;
        }
        private void addSteps(World world)
        {
            int prevx = 0;
            int prevy = 0;
            
            for (int i = 1; i < Settings.TOTALLEVELCOMP; i++)
            {
                bool stair =  i%3>0 ? false : true;
                prevy += (stair ? 0 : -Settings.PLATEAUHEIGHT);

                for(int j = 0; j < (stair ? Settings.STAIRCOUNT : Settings.PLATEAUCOUNT); j++)
                {
                    prevx += (stair ? Settings.STAIRWIDTH : Settings.PLATEAUWIDTH);
                    prevy += (stair ? -Settings.STAIRHEIGHT : 0);

                    AddOneStair(prevx +Settings.MAPSTARTX, prevy+Settings.MAPSTARTY , stair, world);
                }
                prevx += (stair ? -Settings.PLATEAUWIDTH+ Settings.STAIRWIDTH : 0);
                prevy += (stair ? Settings.PLATEAUHEIGHT : Settings.PLATEAUHEIGHT);
            }
            //Stairs[16].SetEvent(StepCorner, Type.NPC, world);
            //Stairs[22].SetEvent(StepCorner, Type.PICKUP, world);
        }
        private void AddOneStair(int x, int y, bool Step, World world)
        {
            Stairssteps Stair = new Stairssteps();
            if (Step)
            {
                Stair.Initialize(StepCorner, new Vector2(x, y), world, Step);
            }
            else
            {
                Stair.Initialize(StepHorizontal, new Vector2(x, y), world, Step);
            }
            Stairs.Add(Stair);
        }

        public void Update(Vector2 PlayerPosition)
        {
            for (int i = 0; i < Stairs.Count(); i++)
            {
            }
        }

        
        public void Draw(SpriteBatch spriteBatch, Vector2 ScreenOffset, bool foreground)
        {
            if (!foreground)
            {
                for (int i = 0; i < Backgrounds.Length; i++)
                {
                    spriteBatch.Draw(Backgrounds[i], new Vector2(Backgrounds[i].Width * i - ScreenOffset.X,0), Color.White);
                }
                for (int i = 0; i < Stairs.Count(); i++)
                {
                    Stairs[i].Draw(spriteBatch, ScreenOffset);
                }
            }
            else
            for (int i = 0; i < Foregrounds.Length; i++)
            {
                spriteBatch.Draw(Foregrounds[i], new Vector2(Foregrounds[i].Width * i - ScreenOffset.X,0), Color.White);
            }
        }

    }
}

