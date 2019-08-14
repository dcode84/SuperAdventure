using System.Drawing;

namespace Engine.EventArgs
{
    public class GameMessageEventArgs
    {
        public string Message { get; set; }
        public bool AddNewLine { get; set; }
        public Color Color { get; set; }
        public GameMessageEventArgs(string message, bool addNewLine = false)
        {
            Message = message;
            AddNewLine = addNewLine;
        }

        public GameMessageEventArgs(string message, Color color, bool addNewLine)
        {
            Message = message;
            Color = color;
            AddNewLine = addNewLine;
        }
    }
}
