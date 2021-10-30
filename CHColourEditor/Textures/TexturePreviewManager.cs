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

        private SpriteKeys SpriteKeys { get; }
        private readonly PictureBox TextureBox;
        public Image OriginalImage { get; private set; }
        public Bitmap BlendedImage { get; private set; }
        public Color CurrentColor { get; private set; }
        public List<string> CurrentKeys { get; private set; } = new List<string>();

        public TexturePreviewManager(PictureBox box)
        {
            SpriteKeys = new SpriteKeys();
            TextureBox = box;

            Directory.CreateDirectory("sprites");

            try
            {
                // Read the sprite keys file
                var sr = new StreamReader("sprites\\sprites.ini");
                string iniDataString = sr.ReadToEnd();
                sr.Close();

                // Parse to IniData
                IniData iniData = new IniDataParser().Parse(iniDataString);

                // Must contain these sections or else it is invalid
                if (!iniData.Sections.ContainsSection("other") || !iniData.Sections.ContainsSection("drums") || !iniData.Sections.ContainsSection("guitar"))
                {
                    return;
                }

                // Read all the keys in the Guitar section
                for (int i = 0; i < iniData.Sections["guitar"].Count; i++)
                {
                    KeyData key = iniData.Sections["guitar"].ElementAt(i);
                    if (key.Value != string.Empty || key.Value != " ")
                        SpriteKeys.GuitarSprites.Add(key.KeyName, key.Value);
                }

                // Read all the keys in the Drums section
                for (int i = 0; i < iniData.Sections["drums"].Count; i++)
                {
                    KeyData key = iniData.Sections["drums"].ElementAt(i);
                    if(key.Value != string.Empty || key.Value != " ")
                        SpriteKeys.DrumSprites.Add(key.KeyName, key.Value);
                }

                // Read all the keys in Other section
                for (int i = 0; i < iniData.Sections["other"].Count; i++)
                {
                    KeyData key = iniData.Sections["other"].ElementAt(i);
                    if (key.Value != string.Empty || key.Value != " ")
                        SpriteKeys.OtherSprites.Add(key.KeyName, key.Value);
                }
            } catch { }
        }

        public void UpdatePreview(int list, List<string> keys, Color color)
        {
            // Don't bother doing anything if the key and the colour are the exact same
            if (CurrentKeys == keys && CurrentColor == color)
                return;

            // Texture key has changed, so find the new sprite
            if (CurrentKeys != keys)
            {
                Image newImage = FindSprite(list, keys[0]);
                if (newImage == null)
                {
                    TextureBox.Image = null;
                    return;
                }
                OriginalImage = newImage;
            }
            if (OriginalImage == null)
                return;

            // Color the sprite with the selected color
            BlendedImage = ColorSprite(OriginalImage, CurrentColor);

            CurrentKeys = keys;
            CurrentColor = color;

            // Update the Image in the UI PictureBox with the new Blended Image.
            TextureBox.Image = BlendedImage;
        }

        private Image FindSprite(int list, string key)
        {
            // If we have already loaded this texture, we can return it quickly
            if (SpriteKeys.Textures.ContainsKey($"{list}_{key}"))
                return SpriteKeys.Textures[$"{list}_{key}"];

            // Relative folder to the executable
            string path = "sprites\\";

            // Setup the subfolder by looking at the key name and the current list (guitar, drums, other)
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

            // Attempt to load the Image from the file and add it to the sprite keys
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

        // TODO Redo color blending using additive color blending algorithms for faster blending
        // TODO Implement proper asynchronous image manipulation
        private Bitmap ColorSprite(Image sprite, Color color)
        {
            int width = sprite.Width;
            int height = sprite.Height;

            // Load the original sprite
            Bitmap src = new Bitmap(sprite);

            // Generate a Bitmap of the sprite width and height for coloring
            Bitmap colorMap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            // Apply the selected color to the colorMap sprite
            using (Graphics gfx = Graphics.FromImage(colorMap))
            using (SolidBrush brush = new SolidBrush(color))
            {
                gfx.FillRectangle(brush, 0, 0, sprite.Width, sprite.Height);
            }

            // Use LockBitmap for faster performance (Locks bits and uses pointer arithmetic to retrieve pixels)
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

                    // If the alpha is 0 we skip it as this pixel is transparent
                    if (lowerPixel.A == 0)
                    {
                        continue;
                    }

                    // Calculate the blended colors
                    var lowerColor = new HSLColor(lowerPixel.R, lowerPixel.G, lowerPixel.B);
                    var upperColor = new HSLColor(upperPixel.R, upperPixel.G, upperPixel.B) { Luminosity = lowerColor.Luminosity };

                    Color finalColor = Color.FromArgb(lowerPixel.A, ((Color)upperColor).R, ((Color)upperColor).G, ((Color)upperColor).B);

                    srcLockMap.SetPixel(x, y, finalColor);
                }
            }
            // Unlock the bits from memory as we are done with them
            srcLockMap.UnlockBits();
            colorLockMap.UnlockBits();

            return src;
        }
    }
}
