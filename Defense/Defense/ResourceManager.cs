using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Defense
{
    public static class ResourceManager
    {
        static Dictionary<String, Texture2D> texDic = new Dictionary<string, Texture2D>();
        static Dictionary<String, SpriteFont> fontDic = new Dictionary<string, SpriteFont>();
        static Dictionary<String, Song> songDic = new Dictionary<string, Song>();
        static Dictionary<String, SoundEffect> soundDic = new Dictionary<string, SoundEffect>();

        static List<String> textureNames = new List<String> { "Pixel" };
        static List<String> songNames = new List<String>();
        static List<String> fontNames = new List<String>();
        static List<String> soundNames = new List<String>();

        public static void LoadContent(ContentManager cm) 
        {
            foreach (String name in textureNames)
                texDic[name] = cm.Load<Texture2D>(name);
            foreach (String name in fontNames)
                fontDic[name] = cm.Load<SpriteFont>(name);
            foreach (String name in songNames)
                songDic[name] = cm.Load<Song>(name);
            foreach (String name in soundNames)
                soundDic[name] = cm.Load<SoundEffect>(name);
        }

        public static Texture2D GetTexture(String name)
        {
            return texDic[name];
        }

        public static SpriteFont GetFont(String name) 
        {
            return fontDic[name];
        }

        public static Song GetSong(String name) 
        {
            return songDic[name];
        }

        public static SoundEffect GetSound(String name) 
        {
            return soundDic[name];
        }

    }
}
