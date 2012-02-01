using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GGJ_2012_Spill
{
    public class NPCDialogue
    {
        String one = "My life of eternity is dependant on a gold coin for the ferry master at the River Styx. Could you spare me one, please?";
        String onereplay1 = "Of course little girl! I have one to spare.";
        String onenpcreplay1 = "Thank you! You are too kind!";
        String onereplay2 = "Sorry, I don’t have any gold coins, and you are way to young to be concerned with such troubling matters";
        String onenpcreplay2 = "You are mean and unfair, traveler.";
        String onereplay3 = "I don’t practice charity. Get your own gold coins!";
        String onenpcreplay3 = "Oh, well. I'll ask the next one that passes by.";

        String two = "Hello! I must say that I’m impressed with your achievements in life. A fine sample of a human being, indeed!";
        String tworeplay1 = "Thank you, sir!";
        String twonpcreplay1 = "Thank you! You are too kind!";
        String tworeplay2 = "Great achievements come with alot of work, but thank you. !";
        String twonpcreplay2 = "Indeed they do, indeed they do!";
        String tworeplay3 = "Hrmph! Of course I’m great! Look at me...";
        String twonpcreplay3 = "Well, aren't you a rude one!";

        String three = "A handsome man by the stairs?";
        String threereplay1 = "Well, hello there! How would you like to come with me for a special little adventure?";
        String threenpcreplay1 = "Your lust is both scary and unacceptable! Now move along, please";
        String threereplay2 = "Nod politely at him and continue walking up the stairs.";
        String threenpcreplay2 = "Hello there, traveler.";
        String threereplay3 = "Run away in fear of seeming affected by his charm.";
        String threenpcreplay3 = "Why in such a hurry? Oh, well. Best luck on your travels!";

        String four = "You there. Would you mind picking up my walking stick? I managed to drop it down a flight of stairs.";
        String fourreplay1 = "Of course, I would love to help!";
        String fournpcreplay1 = "I am so grateful! I'm eternally grateful!";
        String fourreplay2 = "I could, but I can’t be bothered to go down all those stairs.";
        String fournpcreplay2 = "Rude excuse for a human being!";
        String fourreplay3 = "I’m sorry, I can’t help you as the staircase broke as I walked over it.";
        String fournpcreplay3 = "Oh, that was unfortunate. Well, thank you anyway.";

        String five = "You seem down and apathetic, young one. Are you troubled?";
        String fivereplay1 = "Yes, my life is basically in ruins and everything is dark and sad.";
        String fivenpcreplay1 = "You should have a positive look at life, do not mope! You sadden everyone around you.";
        String fivereplay2 = "I’m troubled, but I’ll carry on and hope things lighten up";
        String fivenpcreplay2 = "Let us hope that things will take a turn for the better. Good luck on your travels!";
        String fivereplay3 = "I’m sorry, I can’t help you as the staircase broke as I walked over it.";
        String fivenpcreplay3 = "That's the spirit! Keep nurturing those thoughts and you will reach far!";

        String six = "Would you mind handing me some water? I don't feel well.";
        String sixreplay1 = "No , stay away from me you filthy man!";
        String sixnpcreplay1 = "I've never hurt anyone. I hope you'll be reborn a serpent!";
        String sixreplay2 = "Of course, poor man. I hope you'll feel better soon!";
        String sixnpcreplay2 = "So kind! I wish all travelers were like you!";
        String sixreplay3 = "I would love to help you, but I don't want to catch your disease.";
        String sixnpcreplay3 = "I understand. Thank you for being so polite!";

        String seven = "I have seen a foul serpent in this area. Would you be able to slay the beast for me?";
        String sevenreplay1 = "Hah! I’ve already slain that serpent. It was an easy pray!";
        String sevennpcreplay1 = "That's a lie, and you know it! I don't approve of your bragging ways.";
        String sevenreplay2 = "It sounds dangerous and scary, but I’ll do my best";
        String sevennpcreplay2 = "Sounds good! Good luck on your quest then.";
        String sevenreplay3 = "I’m not much of a fighter, so that quest would probably suit someone stronger than me, but I’ll try";
        String sevennpcreplay3 = "Ah! A humble adventurer with a powerful mind is way better than any armored knight!";

        String eight = "Could you spare me some food, stranger?";
        String eightreplay1 = "You are too kind, stranger! Thank you!";
        String eightnpcreplay1 = "You are too kind, stranger! Thank you!";
        String eightreplay2 = "Shoo! Get away from me, I need all the food I can get! ";
        String eightnpcreplay2 = "You gluttonous beast! Curse you!";
        String eightreplay3 = "I'm sorry, I no food to spare.";
        String eightnpcreplay3 = "Ok then. Be well!";

        String nine = "Are you satisfied with your pathetic little life? You are a miserable excuse of a human being on a road to emptiness and under-achievement. I frown upon seeing useless beings like you. I will laugh the day you fall to the bottom of the River Styx!";
        String ninereplay1 = "Are you taunting me you foul useless beast!? I will rip you to pieces and make you pray for your life!";
        String ninenpcreplay1 = "Hah! I will fight until you lie dead on the ground!";
        String ninereplay2 = "I am no fool! I will not let you taunt me to unleash my wrath upon you! ";
        String ninenpcreplay2 = "A patient one, I see. Be gone with you!";
        String ninereplay3 = "Ignore the evil spirit and continue up the stairs.";
        String ninenpcreplay3 = "How dare you ignore me!? Show me your wrath!";

        String ten = "I used to be a stair walker like you, but then I took a lightning bolt to the hair";
        String tenreplay1 = "Yees, I like Skyrim too.";
        String tennpcreplay1 = "Aha! A fellow gamer! How nice!";
        String tenreplay2 = "In Sovjet Russia, lightning bolt takes you to the knee.";
        String tennpcreplay2 = "Yees, in Sovjet Russia, answer questions you!";
        String tenreplay3 = "Y u no fix your hair!?";
        String tennpcreplay3 = "Y u so rude!?";

        public String getText(String name)
        {
            switch (name)
            {
                case "one":
                    return one;
                case "two":
                    return two;
                case "three":
                    return three;
                case "four":
                    return four;
                case "five":
                    return five;
                case "six":
                    return six;
                case "seven":
                    return seven;
                case "eight":
                    return eight;
                case "nine":
                    return nine;
                case "ten":
                    return ten;
            }
            return null;
        }

        public List<string> getReplay(String name)
        {
            List<string> replay = new List<string>();
            switch (name)
            {
                case "one":
                    replay.Add(onereplay1);
                    replay.Add(onereplay2);
                    replay.Add(onereplay3);
                    break;
                case "two":
                    replay.Add(tworeplay1);
                    replay.Add(tworeplay2);
                    replay.Add(tworeplay3);
                    break;
                case "three":
                    replay.Add(threereplay1);
                    replay.Add(threereplay2);
                    replay.Add(threereplay3);
                    break;
                case "four":
                    replay.Add(fourreplay1);
                    replay.Add(fourreplay2);
                    replay.Add(fourreplay3);
                    break;
                case "five":
                    replay.Add(fivereplay1);
                    replay.Add(fivereplay2);
                    replay.Add(fivereplay3);
                    break;
                case "six":
                    replay.Add(sixreplay1);
                    replay.Add(sixreplay2);
                    replay.Add(sixreplay3);
                    break;
                case "seven":
                    replay.Add(sevenreplay1);
                    replay.Add(sevenreplay2);
                    replay.Add(sevenreplay3);
                    break;
                case "eight":
                    replay.Add(eightreplay1);
                    replay.Add(eightreplay2);
                    replay.Add(eightreplay3);
                    break;
                case "nine":
                    replay.Add(ninereplay1);
                    replay.Add(ninereplay2);
                    replay.Add(ninereplay3);
                    break;
                case "ten":
                    replay.Add(tenreplay1);
                    replay.Add(tenreplay2);
                    replay.Add(tenreplay3);
                    break;
            }
            return replay;
        }

        public String getNPCReplay(String returnstring)
        {

            String back = null;

            if (returnstring == onereplay1)
            {
                back = onenpcreplay1;
            }
            else if (returnstring == onereplay2)
            {
                back = onenpcreplay2;
            }
            else if (returnstring == onereplay3)
            {
                back = onenpcreplay3;
            }
            else if (returnstring == tworeplay1)
            {
                back = twonpcreplay1;
            }
            else if (returnstring == tworeplay2)
            {
                back = twonpcreplay2;
            }
            else if (returnstring == tworeplay3)
            {
                back = twonpcreplay3;
            }
            else if (returnstring == threereplay1)
            {
                back = threenpcreplay1;
            }
            else if (returnstring == threereplay2)
            {
                back = threenpcreplay2;
            }
            else if (returnstring == threereplay3)
            {
                back = threenpcreplay3;
            }
            else if (returnstring == fourreplay1)
            {
                back = fournpcreplay1;
            }
            else if (returnstring == fourreplay2)
            {
                back = fournpcreplay2;
            }
            else if (returnstring == fourreplay3)
            {
                back = fournpcreplay3;
            }
            else if (returnstring == fivereplay1)
            {
                back = fivenpcreplay1;
            }
            else if (returnstring == fivereplay2)
            {
                back = fivenpcreplay2;
            }
            else if (returnstring == fivereplay3)
            {
                back = fivenpcreplay3;
            }
            else if (returnstring == sixreplay1)
            {
                back = sixnpcreplay1;
            }
            else if (returnstring == sixreplay2)
            {
                back = sixnpcreplay2;
            }
            else if (returnstring == sixreplay3)
            {
                back = sixnpcreplay3;
            }
            else if (returnstring == sevenreplay1)
            {
                back = sevennpcreplay1;
            }
            else if (returnstring == sevenreplay2)
            {
                back = sevennpcreplay2;
            }
            else if (returnstring == sevenreplay3)
            {
                back = sevennpcreplay3;
            }
            else if (returnstring == eightreplay1)
            {
                back = eightnpcreplay1;
            }
            else if (returnstring == eightreplay2)
            {
                back = eightnpcreplay2;
            }
            else if (returnstring == eightreplay3)
            {
                back = eightnpcreplay3;
            }
            else if (returnstring == ninereplay1)
            {
                back = ninenpcreplay1;
            }
            else if (returnstring == ninereplay2)
            {
                back = ninenpcreplay2;
            }
            else if (returnstring == ninereplay3)
            {
                back = ninenpcreplay3;
            }
            else if (returnstring == tenreplay1)
            {
                back = tennpcreplay1;
            }
            else if (returnstring == tenreplay2)
            {
                back = tennpcreplay2;
            }
            else if (returnstring == tenreplay3)
            {
                back = tennpcreplay3;
            }
            return back;
            
        }

        public int getKarmaPoints(String name, int number)
        {
            int tall = 0;
            switch (name)
            {
                case "one":
                    if (number == 1)
                    {
                        tall++;
                    } else if (number == 2) {
                        tall--;
                    }
                    return tall;
                case "two":
                    if (number == 1)
                    {
                        tall++;
                    }
                    else if (number == 3)
                    {
                        tall--;
                    }
                    return tall;
                case "three":
                    if (number == 1)
                    {
                        tall--;
                    }
                    else if (number == 2)
                    {
                        tall++;
                    }
                    return tall;
                case "four":
                    if (number == 1)
                    {
                        tall--;
                    }
                    else if (number == 3)
                    {
                        tall++;
                    }
                    return tall;
                case "five":
                    if (number == 1)
                    {
                        tall--;
                    }
                    else if (number == 3)
                    {
                        tall++;
                    }
                    return tall;
                case "six":
                    if (number == 1)
                    {
                        tall++;
                    }
                    else if (number == 2)
                    {
                        tall--;
                    }
                    return tall;
                case "seven":
                    if (number == 1)
                    {
                        tall--;
                    }
                    else if (number == 3)
                    {
                        tall++;
                    }
                    return tall;
                case "eight":
                    if (number == 1)
                    {
                        tall--;
                    }
                    else if (number == 3)
                    {
                        tall++;
                    }
                    return tall;
                case "nine":
                    if (number == 1)
                    {
                        tall--;
                    }
                    else if (number == 3)
                    {
                        tall++;
                    }
                    return tall;
                case "ten":
                    if (number == 1)
                    {
                        tall--;
                    }
                    else if (number == 3)
                    {
                        tall++;
                    }
                    return tall;
            }
            return tall;
        }
    }
}