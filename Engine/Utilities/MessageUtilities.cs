using Engine.EventArgs;
using System;
using System.Drawing;

namespace Engine.Utilities
{
    public class MessageUtilities
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        public void RaiseMessage(string message, bool addExtraNewLine = false)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message, addExtraNewLine));
        }

        public void RaiseWarning(string message, bool addExtraNewLine = false)
        {
            Color color = Color.Red;
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message, color, addExtraNewLine));
        }

        public void RaiseInfo(string message, bool addExtraNewLine = false)
        {
            Color color = Color.Blue;
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message, color, addExtraNewLine));
        }
    }
}
