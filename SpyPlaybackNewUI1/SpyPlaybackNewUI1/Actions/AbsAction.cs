using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gu.Wpf;
using Gu.Wpf.UiAutomation;
using SpyPlaybackNewUI1.SpyPlaybackObjects;

namespace SimplePlayBack.Actions
{
    abstract class AbsAction
    {
        public PlaybackObject PlaybackObject {get; set;}
        public SpyObject SpyObject { get; set; }
        public UiElement UiElement;
        public bool Result;
        public abstract void DoExecute();
    }
}
