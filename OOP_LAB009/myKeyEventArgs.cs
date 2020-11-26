using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace OOP_LAB009
{
    class myKeyEventArgs : HandledEventArgs
    {
        public ConsoleKeyInfo key;

        public myKeyEventArgs(ConsoleKeyInfo _key)
        {
            key = _key;
        }
    }

    class KeyEvent
    {
        public event EventHandler<myKeyEventArgs> KeyPress;
        public void OnKeyPress(ConsoleKeyInfo _key)
        {
            KeyPress(this, new myKeyEventArgs(_key));
        }
    }
    
}
