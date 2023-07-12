using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObradaSlika
{
    public class RedoCommand : Command
    {
        public Form1 Obj { get; set; }
        public RedoCommand(Form1 obj)
        {
            this.Obj = obj;
        }
        public void Execute()
        {
            if (!this.Obj.RedoBuffer.IsEmpty())
            {
                this.Obj.UndoBuffer.Push(this.Obj.BitmapImage);
                this.Obj.BitmapImage = (Bitmap)this.Obj.RedoBuffer.Pop();
            }
        }
    }
}
