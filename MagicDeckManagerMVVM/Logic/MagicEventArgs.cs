using MagicGameTracker.Logic.MagicEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicGameTracker.Logic
{
    namespace MagicEventArgs
    {
        public class FormatEventArgs : EventArgs
        {
            public DeckFormats format { get; set; }
        }  

    }
}
