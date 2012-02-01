using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace WindowsGame1
{
    public class AudioManager : GameComponent
    {
        static AudioManager audioManager = null;
        public static AudioManager Instance
        {
            get
            {
                return audioManager;
            }
        }

        static readonly string soundAssetLocation = "Sounds/";
        
        Dictionary<string, SoundEffectInstance> soundBank;
        Dictionary<string, Song> musicBank;

        private AudioManager(Game game)
            : base(game) { }

        public static void Initialize(Game game)
        {
            audioManager = new AudioManager(game);
            audioManager.soundBank = new Dictionary<string, SoundEffectInstance>();
            audioManager.musicBank = new Dictionary<string, Song>();

            game.Components.Add(audioManager);
        }

        public static void LoadSound(string nameOfFile, string namealias)
        {
            SoundEffect soundEffect = audioManager.Game.Content.Load<SoundEffect>(soundAssetLocation + nameOfFile);
            SoundEffectInstance soundEffectInstance = soundEffect.CreateInstance();

            if (!audioManager.soundBank.ContainsKey(namealias))
            {
                audioManager.soundBank.Add(namealias, soundEffectInstance);
            }
        }

        public static void LoadSong(string nameOfFile, string namealias)
        {
            Song song = audioManager.Game.Content.Load<Song>(soundAssetLocation + nameOfFile);

            if (!audioManager.musicBank.ContainsKey(namealias))
            {
                audioManager.musicBank.Add(namealias, song);
            }
        }

        public static void LoadSounds()
        {
            LoadSound("One-NPC1", "One-NPC1");
            LoadSound("One-NPC21", "One-NPC21");
            LoadSound("One-NPC22", "One-NPC22");
            LoadSound("One-NPC23", "One-NPC23");

            LoadSound("Two-NPC1", "Two-NPC1");
            LoadSound("Two-NPC21", "Two-NPC21");
            LoadSound("Two-NPC22", "Two-NPC22");
            LoadSound("Two-NPC23", "Two-NPC23");

            LoadSound("Three-NPC11", "Three-NPC11");
            LoadSound("Three-NPC12", "Three-NPC12");
            LoadSound("Three-NPC13", "Three-NPC13");

            LoadSound("Four-NPC1", "Four-NPC1");
            LoadSound("Four-NPC21", "Four-NPC21");
            LoadSound("Four-NPC22", "Four-NPC22");
            LoadSound("Four-NPC23", "Four-NPC23");

            LoadSound("Five-NPC1", "Five-NPC1");
            LoadSound("Five-NPC21", "Five-NPC21");
            LoadSound("Five-NPC22", "Five-NPC22");
            LoadSound("Five-NPC23", "Five-NPC23");

            LoadSound("Six-NPC1", "One-NPC1");
            LoadSound("Six-NPC21", "Six-NPC21");
            LoadSound("Six-NPC22", "Six-NPC22");
            LoadSound("Six-NPC23", "Six-NPC23");

            LoadSound("Seven-NPC1", "Seven-NPC1");
            LoadSound("Seven-NPC21", "Seven-NPC21");
            LoadSound("Seven-NPC22", "Seven-NPC22");
            LoadSound("Seven-NPC23", "Seven-NPC23");

            LoadSound("Eight-NPC1", "Eight-NPC1");
            LoadSound("Eight-NPC21", "Eight-NPC21");
            LoadSound("Eight-NPC22", "Eight-NPC22");
            LoadSound("Eight-NPC23", "Eight-NPC23");

            LoadSound("Nine-NPC1", "Seven-NPC1");
            LoadSound("Nine-NPC21", "Seven-NPC21");
            LoadSound("Nine-NPC22", "Seven-NPC22");
            LoadSound("Nine-NPC23", "Seven-NPC23");

            LoadSound("Ten-NPC1", "Ten-NPC1");
            LoadSound("Ten-NPC21", "Ten-NPC21");
            LoadSound("Ten-NPC22", "Ten-NPC22");
            LoadSound("Ten-NPC23", "Ten-NPC23");
        }

        public static void LoadMusic()
        {
            LoadSong("win","win");

            LoadSong("1", "1");
            LoadSong("2", "2");
            LoadSong("3", "3");
            LoadSong("4", "4");
            LoadSong("5", "5");
            LoadSong("6", "6");
            LoadSong("7", "7");

            LoadSong("death", "death");
        }

        public SoundEffectInstance this[string soundName]
        {
            get
            {
                if (audioManager.soundBank.ContainsKey(soundName))
                {
                    return audioManager.soundBank[soundName];
                }
                else
                {
                    return null;
                }
            }
        }

        public static void PlaySound(string soundName)
        {
            if (audioManager.soundBank.ContainsKey(soundName))
            {
                audioManager.soundBank[soundName].Play();
            }
        }

        public static void PlaySound(string soundName, bool isLooped)
        {
            if (audioManager.soundBank.ContainsKey(soundName))
            {
                if (audioManager.soundBank[soundName].IsLooped != isLooped)
                {
                    audioManager.soundBank[soundName].IsLooped = isLooped;
                }

                audioManager.soundBank[soundName].Play();
            }
        }

        public static void PlaySound(string soundName, bool isLooped, float volume)
        {
            if (audioManager.soundBank.ContainsKey(soundName))
            {
                if (audioManager.soundBank[soundName].IsLooped != isLooped)
                {
                    audioManager.soundBank[soundName].IsLooped = isLooped;
                }

                audioManager.soundBank[soundName].Volume = volume;
                audioManager.soundBank[soundName].Play();
            }
        }

        public static void StopSound(string soundName)
        {
            if (audioManager.soundBank.ContainsKey(soundName))
            {
                audioManager.soundBank[soundName].Stop();
            }
        }

        public static void StopSounds()
        {
            foreach (SoundEffectInstance sound in audioManager.soundBank.Values)
            {
                if (sound.State != SoundState.Stopped)
                {
                    sound.Stop();
                }
            }
        }

        public static void PauseResumeSounds(bool resumeSounds)
        {
            SoundState state = resumeSounds ? SoundState.Paused : SoundState.Playing;

            foreach (SoundEffectInstance sound in audioManager.soundBank.Values)
            {
                if (sound.State == state)
                {
                    if (resumeSounds)
                    {
                        sound.Resume();
                    }
                    else
                    {
                        sound.Pause();
                    }
                }
            }
        }

        public static void PlayMusic(string musicSoundName)
        {
            if (audioManager.musicBank.ContainsKey(musicSoundName))
            {
                if (MediaPlayer.State != MediaState.Stopped)
                {
                    MediaPlayer.Stop();
                }

                MediaPlayer.IsRepeating = true;

                MediaPlayer.Play(audioManager.musicBank[musicSoundName]);
            }
        }

        public static void StopMusic()
        {
            if (MediaPlayer.State != MediaState.Stopped)
            {
                MediaPlayer.Stop();
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    foreach (var item in soundBank)
                    {
                        item.Value.Dispose();
                    }
                    soundBank.Clear();
                    soundBank = null;
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }
    }
}