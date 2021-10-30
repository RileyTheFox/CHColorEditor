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
                    case 0:
                        iniData["guitar"]["note_green"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["sustain_green"] = ColorTranslator.ToHtml(color);
                        break;
                    case 1:
                        iniData["guitar"]["note_red"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["sustain_red"] = ColorTranslator.ToHtml(color);
                        break;
                    case 2:
                        iniData["guitar"]["note_yellow"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["sustain_yellow"] = ColorTranslator.ToHtml(color);
                        break;
                    case 3:
                        iniData["guitar"]["note_blue"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["sustain_blue"] = ColorTranslator.ToHtml(color);
                        break;
                    case 4:
                        iniData["guitar"]["note_orange"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["sustain_orange"] = ColorTranslator.ToHtml(color);
                        break;
                    // Star power
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
                    // Not including flames as GameColors allows you to change each fret's flame whereas CH changes it globally.
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    // Can't change lightning in CH so not included
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                        continue;
                    // SP Bar
                    case 16:
                        iniData["other"]["sp_bar_color"] = ColorTranslator.ToHtml(color);
                        break;
                    case 17:
                        iniData["other"]["sp_bar_color"] = ColorTranslator.ToHtml(color);
                        break;
                    case 18:
                        iniData["other"]["sp_bar_elec"] = ColorTranslator.ToHtml(color);
                        break;
                    // Striker Cover
                    case 19:
                        iniData["guitar"]["striker_cover_green"] = ColorTranslator.ToHtml(color);
                        break;
                    case 20:
                        iniData["guitar"]["striker_cover_red"] = ColorTranslator.ToHtml(color);
                        break;
                    case 21:
                        iniData["guitar"]["striker_cover_yellow"] = ColorTranslator.ToHtml(color);
                        break;
                    case 22:
                        iniData["guitar"]["striker_cover_blue"] = ColorTranslator.ToHtml(color);
                        break;
                    case 23:
                        iniData["guitar"]["striker_cover_orange"] = ColorTranslator.ToHtml(color);
                        break;
                    // Striker Head Cover
                    case 24:
                        iniData["guitar"]["striker_head_cover_green"] = ColorTranslator.ToHtml(color);
                        break;
                    case 25:
                        iniData["guitar"]["striker_head_cover_red"] = ColorTranslator.ToHtml(color);
                        break;
                    case 26:
                        iniData["guitar"]["striker_head_cover_yellow"] = ColorTranslator.ToHtml(color);
                        break;
                    case 27:
                        iniData["guitar"]["striker_head_cover_blue"] = ColorTranslator.ToHtml(color);
                        break;
                    case 28:
                        iniData["guitar"]["striker_head_cover_orange"] = ColorTranslator.ToHtml(color);
                        break;
                    // Striker Head Light
                    case 29:
                        iniData["guitar"]["striker_head_light_green"] = ColorTranslator.ToHtml(color);
                        break;
                    case 30:
                        iniData["guitar"]["striker_head_light_red"] = ColorTranslator.ToHtml(color);
                        break;
                    case 31:
                        iniData["guitar"]["striker_head_light_yellow"] = ColorTranslator.ToHtml(color);
                        break;
                    case 32:
                        iniData["guitar"]["striker_head_light_blue"] = ColorTranslator.ToHtml(color);
                        break;
                    case 33:
                        iniData["guitar"]["striker_head_light_orange"] = ColorTranslator.ToHtml(color);
                        break;
                    case 36:
                    case 37:
                    case 38:
                    case 39:
                    case 40:
                    case 41:
                    case 42:
                    case 43:
                        continue;
                    case 44:
                        iniData["guitar"]["note_open"] = ColorTranslator.ToHtml(color);
                        iniData["guitar"]["sustain_open"] = ColorTranslator.ToHtml(color);
                        break;
                    case 45:
                        iniData["other"]["sp_act_flash"] = ColorTranslator.ToHtml(color);
                        break;
                    // From this point on none of these things can be changed in Clone Hero like you can do in GameColors.
                    // There's things like particles but CH only allows you to globally change particles, not per fret so I'm not including them
                }
            }
            return true;
        }

    }
}
