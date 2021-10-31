using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace SideyUtils
{
    /// <summary>
    /// Represents a Console with extra features such as XML tags and more simple coloring of text.
    /// </summary>
    public static class XConsole
    {
        private const ConsoleColor ERROR_COLOR   = ConsoleColor.Red;
        private const ConsoleColor WARNING_COLOR = ConsoleColor.DarkYellow;
        private const ConsoleColor SUCCESS_COLOR = ConsoleColor.Green;
        private const ConsoleColor INFO_COLOR    = ConsoleColor.Blue;
        private const ConsoleColor LOG_COLOR     = ConsoleColor.Gray;

        private static readonly Dictionary<string, Action> _actions =
            new Dictionary<string, Action>()
        {
            { "black",       () => Console.ForegroundColor = ConsoleColor.Black },
            { "blue",        () => Console.ForegroundColor = ConsoleColor.Blue },
            { "cyan",        () => Console.ForegroundColor = ConsoleColor.Cyan },
            { "darkblue",    () => Console.ForegroundColor = ConsoleColor.DarkBlue },
            { "darkcyan",    () => Console.ForegroundColor = ConsoleColor.DarkCyan },
            { "darkgray",    () => Console.ForegroundColor = ConsoleColor.DarkGray },
            { "darkgreen",   () => Console.ForegroundColor = ConsoleColor.DarkGreen },
            { "darkmagenta", () => Console.ForegroundColor = ConsoleColor.DarkMagenta },
            { "darkred",     () => Console.ForegroundColor = ConsoleColor.DarkRed },
            { "darkyellow",  () => Console.ForegroundColor = ConsoleColor.DarkYellow },
            { "gray",        () => Console.ForegroundColor = ConsoleColor.Gray },
            { "green",       () => Console.ForegroundColor = ConsoleColor.Green },
            { "magenta",     () => Console.ForegroundColor = ConsoleColor.Magenta },
            { "red",         () => Console.ForegroundColor = ConsoleColor.Red },
            { "white",       () => Console.ForegroundColor = ConsoleColor.White },
            { "yellow",      () => Console.ForegroundColor = ConsoleColor.Yellow },
            { "error",       () => Console.ForegroundColor = ERROR_COLOR },
            { "warning",     () => Console.ForegroundColor = WARNING_COLOR },
            { "success",     () => Console.ForegroundColor = SUCCESS_COLOR },
            { "info",        () => Console.ForegroundColor = INFO_COLOR },
            { "log",         () => Console.ForegroundColor = LOG_COLOR },
        };

        /// <summary>
        /// Writes the string formatted with Xml tags, 
        /// followed by the current line terminator.
        /// </summary>
        /// <param name="value"></param>
        public static void WriteLine(string value = "")
        {
            Write(value);
            Console.WriteLine();
        }

        /// <summary>
        /// Writes the string formatted with Xml tags.
        /// </summary>
        /// <param name="value"></param>
        public static void Write(string value = "")
        {
            XmlReader reader = XmlReader.Create
            (
                new StringReader(value), 
                new XmlReaderSettings
                {
                    ConformanceLevel = ConformanceLevel.Fragment,
                    IgnoreWhitespace = false,
                    IgnoreComments = true
                }
            );

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (_actions.ContainsKey(reader.Name))
                        {
                            _actions[reader.Name]();
                        }
                        break;
                    case XmlNodeType.Text:
                        Console.Write(reader.Value);
                        break;
                    case XmlNodeType.EndElement:
                        Console.ResetColor();
                        break;
                    default:
                        Console.Write(' ');
                        break;
                }
            }
        }

        /// <summary>
        /// Writes the text representation of the specified object with the specified foreground color and background color, 
        /// followed by the current line terminator.
        /// </summary>
        /// <param name="value"></param>
        public static void WriteColorLine(object value, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        /// <summary>
        /// Writes the text representation of the specified object with the specified foreground color and background color, 
        /// followed by the current line terminator.
        /// </summary>
        /// <param name="value"></param>
        public static void WriteColor(object value, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(value);
            Console.ResetColor();
        }

        /// <summary>
        /// Writes the text representation of the specified object with the specified color, 
        /// followed by the current line terminator.
        /// </summary>
        /// <param name="value"></param>
        public static void WriteColorLine(object value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        /// <summary>
        /// Writes the text representation of the specified object with the specified color, 
        /// followed by the current line terminator.
        /// </summary>
        /// <param name="value"></param>
        public static void WriteColor(object value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ResetColor();
        }

        /// <summary>
        /// Writes the text representation of the specified object colored as an error, 
        /// followed by the current line terminator.
        /// </summary>
        /// <param name="value"></param>
        public static void WriteErrorLine(object value)
            => WriteColorLine(value, ERROR_COLOR);

        /// <summary>
        /// Writes the text representation of the specified object colored as an error
        /// </summary>
        /// <param name="value"></param>
        public static void WriteError(object value)
            => WriteColor(value, ERROR_COLOR);

        /// <summary>
        /// Writes the text representation of the specified object colored as a warning, 
        /// followed by the current line terminator.
        /// </summary>
        /// <param name="value"></param>
        public static void WriteWarningLine(object value)
            => WriteColorLine(value, WARNING_COLOR);

        /// <summary>
        /// Writes the text representation of the specified object colored as a warning
        /// </summary>
        /// <param name="value"></param>
        public static void WriteWarning(object value)
            => WriteColor(value, WARNING_COLOR);


        /// <summary>
        /// Writes the text representation of the specified object colored as a success, 
        /// followed by the current line terminator.
        /// </summary>
        /// <param name="value"></param>
        public static void WriteSuccessLine(object value)
            => WriteColorLine(value, SUCCESS_COLOR);

        /// <summary>
        /// Writes the text representation of the specified object colored as a success
        /// </summary>
        /// <param name="value"></param>
        public static void WriteSuccess(object value)
            => WriteColor(value, SUCCESS_COLOR);

        /// <summary>
        /// Writes the text representation of the specified object colored as info, 
        /// followed by the current line terminator.
        /// </summary>
        /// <param name="value"></param>
        public static void WriteInfoLine(object value)
            => WriteColorLine(value, INFO_COLOR);

        /// <summary>
        /// Writes the text representation of the specified object colored as info
        /// </summary>
        /// <param name="value"></param>
        public static void WriteInfo(object value)
            => WriteColor(value, INFO_COLOR);

        /// <summary>
        /// Writes the text representation of the specified object colored as a log, 
        /// followed by the current line terminator.
        /// </summary>
        /// <param name="value"></param>
        public static void WriteLogLine(object value)
            => WriteColorLine(value, LOG_COLOR);

        /// <summary>
        /// Writes the text representation of the specified object colored as a log
        /// </summary>
        /// <param name="value"></param>
        public static void WriteLog(object value)
            => WriteColor(value, LOG_COLOR);

        /// <summary>
        /// Writes a line separator, followed by the current line terminator.
        /// </summary>
        public static void WriteLineSeparator()
        {
            // lol
            Console.WriteLine("---------------------------------------------------------------");
        }
    }
}
