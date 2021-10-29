using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IniParser.Model;

namespace CHColourEditor
{
    public class GameColors
    {

        public static bool ConvertGameColors(ref IniData iniData, string gameColorsData)
        {
            // Required to account for decimal point differences across various cultures
            NumberFormatInfo numberFormat = new CultureInfo("").NumberFormat;

            string[] lines = gameColorsData.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            for(int i = 0; i < lines.Length; i++)
            {
                // Ignore rainbow lines as these are not possible.
                if (lines[i] == "RB" || lines[i] == "empty" || lines[i] == string.Empty)
                    continue;

                string[] rgbStrings = lines[i].Split('|');
                int[] colors = new int[rgbStrings.Length];
                for(int j = 0; j < colors.Length; j++)
                {
                    // Account for cfg files that may use the opposite decimal separator than what is normal for the current culture,
                    // i.e. , instead of . for regions that use . for decimals, and . instead of , for regions that use , for decimals.
                    // This could just be set once, but checking every time is more robust towards the
                    // (albeit unlikely) chance that a cfg has both . and , in different lines.
                    if(rgbStrings[j].Contains("."))
                    {
                        numberFormat.NumberDecimalSeparator = ".";
                    }
                    else if(rgbStrings[j].Contains(","))
                    {
                        numberFormat.NumberDecimalSeparator = ",";
                    }

                    colors[j] = Convert.ToInt32(Math.Round(Convert.ToDouble(rgbStrings[j], numberFormat)));
                }

                Color color = Color.FromArgb(colors[0], colors[1], colors[2]);

                switch(i)
                {
                    // Notes/Sustains
                    // Green
                    case 0:
                        iniData["guitar"]["note_green"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["sustain_green"] = ColorTranslator.ToHtml(color);
                        break;

                    // Red
                    case 1:
                        iniData["guitar"]["note_red"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["sustain_red"] = ColorTranslator.ToHtml(color);
                        break;

                    // Yellow
                    case 2:
                        iniData["guitar"]["note_yellow"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["sustain_yellow"] = ColorTranslator.ToHtml(color);
                        break;

                    // Blue
                    case 3:
                        iniData["guitar"]["note_blue"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["sustain_blue"] = ColorTranslator.ToHtml(color);
                        break;

                    // Orange
                    case 4:
                        iniData["guitar"]["note_orange"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["sustain_orange"] = ColorTranslator.ToHtml(color);
                        break;

                    // Star Power
                    case 5:
                        iniData["guitar"]["note_sp_phrase"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["note_sp_phrase_active"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["note_sp_active"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["sustain_sp_phrase"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["sustain_sp_phrase_active"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["sustain_sp_active"] = ColorTranslator.ToHtml(color);

                        iniData["other"]["general_sp"] = ColorTranslator.ToHtml(color);
                        iniData["other"]["general_sp_active"] = ColorTranslator.ToHtml(color);
                        iniData["other"]["striker_hit_flame_sp_active"] = ColorTranslator.ToHtml(color);
                        iniData["other"]["combo_sp_active"] = ColorTranslator.ToHtml(color);
                        break;

                    // Flames
                    // Not included, as GameColors allows you to change each fret's flame individually, whereas CH changes it globally.
                    // Green
                    case 6:
                    // Red
                    case 7:
                    // Yellow
                    case 8:
                    // Blue
                    case 9:
                    // Orange
                    case 10:

                    // SP Lightning
                    // Can't be changed in CH, so not included.
                    // Green
                    case 11:
                    // Red
                    case 12:
                    // Yellow
                    case 13:
                    // Blue
                    case 14:
                    // Orange
                    case 15:
                        continue;

                    // SP Bar
                    // Lower bar
                    case 16:
                        iniData["other"]["sp_bar_color"] = ColorTranslator.ToHtml(color);
                        break;
                    // Upper bar
                    case 17:
                        iniData["other"]["sp_bar_color"] = ColorTranslator.ToHtml(color);
                        break;
                    // Electricity
                    case 18:
                        iniData["other"]["sp_bar_elec"] = ColorTranslator.ToHtml(color);
                        break;

                    // Striker Cover
                    // Green
                    case 19:
                        iniData["guitar"]["striker_cover_green"] = ColorTranslator.ToHtml(color);
                        break;
                    // Red
                    case 20:
                        iniData["guitar"]["striker_cover_red"] = ColorTranslator.ToHtml(color);
                        break;
                    // Yellow
                    case 21:
                        iniData["guitar"]["striker_cover_yellow"] = ColorTranslator.ToHtml(color);
                        break;
                    // Blue
                    case 22:
                        iniData["guitar"]["striker_cover_blue"] = ColorTranslator.ToHtml(color);
                        break;
                    // Orange
                    case 23:
                        iniData["guitar"]["striker_cover_orange"] = ColorTranslator.ToHtml(color);
                        break;

                    // Striker Head Cover
                    // Green
                    case 24:
                        iniData["guitar"]["striker_head_cover_green"] = ColorTranslator.ToHtml(color);
                        break;
                    // Red
                    case 25:
                        iniData["guitar"]["striker_head_cover_red"] = ColorTranslator.ToHtml(color);
                        break;
                    // Yellow
                    case 26:
                        iniData["guitar"]["striker_head_cover_yellow"] = ColorTranslator.ToHtml(color);
                        break;
                    // Blue
                    case 27:
                        iniData["guitar"]["striker_head_cover_blue"] = ColorTranslator.ToHtml(color);
                        break;
                    // Orange
                    case 28:
                        iniData["guitar"]["striker_head_cover_orange"] = ColorTranslator.ToHtml(color);
                        break;

                    // Striker Head Light
                    // Green
                    case 29:
                        iniData["guitar"]["striker_head_light_green"] = ColorTranslator.ToHtml(color);
                        break;
                    // Red
                    case 30:
                        iniData["guitar"]["striker_head_light_red"] = ColorTranslator.ToHtml(color);
                        break;
                    // Yellow
                    case 31:
                        iniData["guitar"]["striker_head_light_yellow"] = ColorTranslator.ToHtml(color);
                        break;
                    // Blue
                    case 32:
                        iniData["guitar"]["striker_head_light_blue"] = ColorTranslator.ToHtml(color);
                        break;
                    // Orange
                    case 33:
                        iniData["guitar"]["striker_head_light_orange"] = ColorTranslator.ToHtml(color);
                        break;

                    // Multiplier Meter
                    // Number
                    case 36:
                    // Progress
                    // Not included as CH sets the meter color to the number's base color.
                    case 37:

                    // Score Meter
                    // Not included, as CH only allows changing the highway elements.
                    // Song Progress
                    case 38:
                    // Star Progress
                    case 39:
                    // Outer Star
                    case 40:
                    // Iner Star
                    case 41:
                    // Star Count
                    case 42:

                    // FC Ring
                    // Not included as CH does not allow changing the FC ring color.
                    case 43:
                        continue;

                    // Open Note
                    case 44:
                        iniData["guitar"]["note_open"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["sustain_open"] = ColorTranslator.ToHtml(color);
                        break;

                    // SP Activation
                    case 45:
                        iniData["other"]["sp_act_flash"] = ColorTranslator.ToHtml(color);
                        break;

                    // *From this point onward, none of these things can currently be changed in Clone Hero like you can do in GameColors.*
                    // There's things like particles, but CH only allows you to globally change particles, not per fret.
                    // There's also a couple things specific to GameColors such as the mod menu theme and particle settings.
                    // These are only included for format reference purposes.

                    // Particles
                    // Green
                    case 46:
                    // Red
                    case 47:
                    // Yellow
                    case 48:
                    // Blue
                    case 49:
                    // Orange
                    case 50:

                    // GameColors mod menu theme
                    case 51:

                    // Particle settings
                    case 52:

                    // Score meter font color
                    case 53:

                    // Combo count font color
                    case 54:

                    // Strikeline strings
                    // Green
                    case 55:
                    // Red
                    case 56:
                    // Yellow
                    case 57:
                    // Blue
                    case 58:
                    // Orange
                    case 59:

                    // Highway sides
                    case 60:
                        continue;
                }
            }
            return true;
        }

    }
}
