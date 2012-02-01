using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace WindowsGame1
{
    enum EventType
    {
        NPC,
        PICKUP
    }
    class Event
    {
        public bool Active;
        MenuEventType Type;
        public Event()
        {
        }
        CharacterID npcType;
        ItemType ItemType;

        public void InitializeNPC(CharacterID npcType)
        {
            this.npcType = npcType;
            Active= true;
        }
        public void InitializeItem(ItemType ItemType)
        {
            this.ItemType = ItemType;
            Active = true;
        }

        public void CheckPlayerActivateDialogeEvent(Vector2 playerpos, Rectangle npcRect)
        {
            Rectangle player = new Rectangle((int)playerpos.X, (int)playerpos.Y, Settings.PLAYERWIDTH, Settings.PLAYERHEIGHT);
            

            if (player.Intersects(npcRect))
            {
                //Console.WriteLine("hai!");
                GoGoEvent(EventType.NPC);
                // Venter på enums!
            }
        }
        private void GoGoEvent(EventType type)
        {
            if(type == EventType.NPC){
                switch(npcType){
                    case CharacterID.ONE:
                        One();
                        break;
                    case CharacterID.TWO:
                        Two();
                        break;
                    case CharacterID.THREE:
                        Three();
                        break;
                    case CharacterID.FOUR:
                        Four();
                        break;
                    case CharacterID.FIVE:
                        Five();
                        break;
                    case CharacterID.SIX:
                        Six();
                        break;
                    case CharacterID.SEVEN:
                        Seven();
                        break;
                    case CharacterID.EIGTH:
                        Eigth();
                        break;
                    case CharacterID.NINE:
                        Nine();
                        break;
                    case CharacterID.TEN:
                        Ten();

                        break;
                }
            }
            else if(type == EventType.PICKUP)
            {
                switch (ItemType)
                {
                    case ItemType.COIN:
                        Item1();
                        break;
                    case ItemType.Item2:
                        Item2();
                        break;
                }

            }



        }

        private void Item1()//Item
        {

        }
        private void Item2()
        {

        }

        //----------------------------------------------------
        private void One()//NPC
        {

        }
        private void Two()
        {

        }
        private void Three()
        {

        }
        private void Four()
        {

        }
        private void Five()
        {

        }
        private void Six()
        {

        }
        private void Seven()
        {

        }
        private void Eigth()
        {

        }
        private void Nine()
        {

        }
        private void Ten()
        {

        }

        private void RemoveClass()
        {

            Active = false;
        }

        public void CheckPlayerKarmaPoints(int karma)
        {
            if (karma == 0)
            {
                //AudioManager.StopMusic();
                //AudioManager.PlayMusic("death");
                //Note Spille restarte med død
            }
            if ((karma == 1) && (karma == 2))
            {
                AudioManager.StopMusic();
                AudioManager.PlayMusic("Dramatisk");
            }
            else if (karma == 3) {
                AudioManager.StopMusic();
                AudioManager.PlayMusic("Dramatisk");
            } 
            else if (karma == 4)
            {
                AudioManager.StopMusic();
                AudioManager.PlayMusic("Dramatisk");
            }
            else if (karma == 5) {
                AudioManager.StopMusic();
                AudioManager.PlayMusic("Dramatisk");
            } 
            else if (karma == 6)
            {
                AudioManager.StopMusic();
                AudioManager.PlayMusic("Dramatisk");
            }
            else if (karma == 7)
            {
                AudioManager.StopMusic();
                AudioManager.PlayMusic("Dramatisk");

            } else if ((karma == 8) && (karma == 9))
            {
                AudioManager.StopMusic();
                AudioManager.PlayMusic("Dramatisk");
            }
            else if (karma == 10)
            {
                //AudioManager.StopMusic();
                //AudioManager.PlayMusic("win");
                //Note Spille ?restarte? med vi har vunnet?
            }
        }

        /*public void NPCRunDialog(String name)
        {
            NPCDialoge npcd = new NPCDialoge();
            outputs.Add(npcd.getText(name));
            Draw();
            foreach (String o in npcd.getReplay(name))
            {
                outputs.Add(o);
            }
            // Få inn input av spiller
            int input = 1;
            outputs.Add(npcd.getNPCReplay(npcd.getReplay(name)[input]));
            Draw();
            karma += npcd.getKarmaPoints(name, input);
            CheckPlayerActivateDialogeEvent();
        }
        
        protected override void Draw(GameTime GameTime) {
               GraphicsDevice.clear(Color.CornflowerBlue);
                SpriteBatch.Begin();
                for (int i = 0; i < outputs.Count; i++)
                {
                    Vector2 FontOrigin = Font1.MeasureString(outputs[i]) / 2;
                    SpriteBatch.DrawString(Font1, output, FontPos, Color.Black, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
                }
                SpriteBatch.End();
                base.Draw(GameTime);

        }*/
    }
}
