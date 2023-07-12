using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObradaSlika
{
    public class Buffer<T>
    {
        private List<T> Elements{ get; set; }
        private int size;
        public int Size 
        {
            get 
            {
                return this.size;
            }
            set 
            { 
                if (value > this.size)
                {
                    this.size = value;
                }
                else
                {
                    int new_size = value;
                    if(new_size > 0 && new_size <= 10)
                    {
                        int amount = this.size - new_size;
                        this.ShiftLeft(amount);
                        this.size = new_size;
                    }
                }
            }
        }
        private int Start { get; set; }

        public Buffer(int size)
        {
            this.size = size;
            this.Elements = new List<T>(size);
            this.Start = -1;
        }
        private void ShiftLeftOne()
        {
            if (this.Start < 0)
            {
                return;
            }
            this.Elements.RemoveAt(0);
            //ako RemoveAt shiftuje automatski ovo ispod nije potrebno
            /*
            for(int i = 0; i<this.Start; i++)
            {
                this.Elements.Insert(i, this.Elements[i + 1]);
            }
            */
            this.Start--;
        }
        private void ShiftLeft(int amount)
        {
            if (amount > this.size)
            {
                amount = this.size; 
            }
            for(int i = 0; i<amount; i++)
            {
                this.ShiftLeftOne();
            }
        }
        public Object Pop()
        {
            //T element = this.Elements.ElementAt<T>(this.Start);
            if (this.Start>-1)
            {
                T element = this.Elements[this.Start];
                this.Elements.Remove(element);
                this.Start--;
                return element;
            }
            return null;
        }
        public void Push(T obj)
        {
            this.Start++;
            if (this.Start == this.Size)
            {
                this.ShiftLeftOne();
            }
            //this.Elements.Append<T>(obj);
            this.Elements.Add(obj);
        }
        public void Clear()
        {
            if (!this.IsEmpty())
            {
                this.Elements.Clear();
                this.Start = -1;
            }
        }
        public bool IsEmpty()
        {
            if (this.Start >= 0)
            {
                return false;
            }
            return true;
        }
    }
}
