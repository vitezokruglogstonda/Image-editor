using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObradaSlika
{
    public class UndoCommand : Command
    {
        public Form1 Obj { get; set; }
        public UndoCommand(Form1 obj)
        {
            this.Obj = obj;
        }
        public void Execute()
        {
            if (!this.Obj.UndoBuffer.IsEmpty())
            {
                this.Obj.RedoBuffer.Push(this.Obj.BitmapImage);
                this.Obj.BitmapImage = (Bitmap)this.Obj.UndoBuffer.Pop();
            }
        }
    }
}
