using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IniParser.Model;
using IniParser.Parser;

namespace CHColourEditor
{
    public class TexturePreviewManager
    {

        private SpriteKeys SpriteKeys { get; set; }
        private PictureBox TextureBox;
        public Image OriginalImage { get; private set; }
        public Bitmap BlendedImage { get; private set; }
        public Color CurrentColor { get; private set; }
        public string CurrentKey { get; private set; }

        public TexturePreviewManager(PictureBox box)
        {
            SpriteKeys = new SpriteKeys();
            TextureBox = box;

            Directory.CreateDirectory("sprites");

            try
            {
                var sr = new StreamReader("sprites\\sprites.ini");
                string iniDataString = sr.ReadToEnd();
                IniData iniData = new IniDataParser().Parse(iniDataString);

                if (!iniData.Sections.ContainsSection("other") || !iniData.Sections.ContainsSection("drums") || !iniData.Sections.ContainsSection("guitar"))
                {
                    return;
                }

                for (int i = 0; i < iniData.Sections["guitar"].Count; i++)
                {
                    KeyData key = iniData.Sections["guitar"].ElementAt(i);
                    if (key.Value != string.Empty || key.Value != " ")
                        SpriteKeys.GuitarSprites.Add(key.KeyName, key.Value);
                }
                for (int i = 0; i < iniData.Sections["drums"].Count; i++)
                {
                    KeyData key = iniData.Sections["drums"].ElementAt(i);
                    if(key.Value != string.Empty || key.Value != " ")
                        SpriteKeys.DrumSprites.Add(key.KeyName, key.Value);
                }
                for (int i = 0; i < iniData.Sections["other"].Count; i++)
                {
                    KeyData key = iniData.Sections["other"].ElementAt(i);
                    if (key.Value != string.Empty || key.Value != " ")
                        SpriteKeys.OtherSprites.Add(key.KeyName, key.Value);
                }
            } catch (Exception) { }
        }

        public void UpdatePreview(int list, string key, Color color)
        {
            // Don't bother doing anything if the key and the colour are the exact same
            if (CurrentKey == key && CurrentColor == color)
                return;
            // Texture has been changed
            if(CurrentKey != key)
            {
                Image newImage = FindSprite(list, key);
                if (newImage == null)
                {
                    TextureBox.Image = null;
                    return;
                }
                OriginalImage = newImage;
            }
            CurrentColor = color;
            BlendedImage = ColorSprite(OriginalImage, CurrentColor);

            TextureBox.Image = BlendedImage;
        }

        private Image FindSprite(int list, string key)
        {
            if (key == CurrentKey)
                return OriginalImage;

            if (SpriteKeys.Textures.ContainsKey($"{list}_{key}"))
                return SpriteKeys.Textures[$"{list}_{key}"];

            string path = "sprites\\";

            switch(list)
            {
                case 0:
                    if(SpriteKeys.GuitarSprites.ContainsKey(key))
                        path += "guitar\\" + SpriteKeys.GuitarSprites[key];
                    break;
                case 1:
                    if(SpriteKeys.DrumSprites.ContainsKey(key))
                        path += "drums\\" + SpriteKeys.DrumSprites[key];
                    break;
                case 2:
                    if(SpriteKeys.OtherSprites.ContainsKey(key))
                        path += "other\\" + SpriteKeys.OtherSprites[key];
                    break;
            }

            try
            {
                Image image = Image.FromFile(path);
                SpriteKeys.Textures.Add($"{list}_{key}", image);
                return Image.FromFile(path);
            } catch(Exception)
            {
                return null;
            }
        }

        private Bitmap ColorSprite(Image sprite, Color color)
        {
            int width = sprite.Width;
            int height = sprite.Height;

            Bitmap src = new Bitmap(sprite);
            Bitmap colorMap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            using (Graphics gfx = Graphics.FromImage(colorMap))
            using (SolidBrush brush = new SolidBrush(color))
            {
                gfx.FillRectangle(brush, 0, 0, sprite.Width, sprite.Height);
            }

            LockBitmap srcLockMap = new LockBitmap(src);
            LockBitmap colorLockMap = new LockBitmap(colorMap);

            srcLockMap.LockBits();
            colorLockMap.LockBits();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var upperPixel = colorLockMap.GetPixel(x, y);
                    var lowerPixel = srcLockMap.GetPixel(x, y);

                    if (lowerPixel.A == 0)
                    {
                        continue;
                    }

                    var lowerColor = new HSLColor(lowerPixel.R, lowerPixel.G, lowerPixel.B);
                    var upperColor = new HSLColor(upperPixel.R, upperPixel.G, upperPixel.B) { Luminosity = lowerColor.Luminosity };

                    Color finalColor = Color.FromArgb(lowerPixel.A, ((Color)upperColor).R, ((Color)upperColor).G, ((Color)upperColor).B);

                    srcLockMap.SetPixel(x, y, finalColor);
                }
            }
            srcLockMap.UnlockBits();
            colorLockMap.UnlockBits();

            return src;
        }
    }
}
