using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObradaSlika.Huffman
{
    public class Node
    {
        public char Symbol { get; set; }
        public int Frequency { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }

        public List<bool> Traverse(char symbol, List<bool> data)
        {
            // Terminalni cvor
            if (Right == null && Left == null)
            {
                if (symbol.Equals(this.Symbol))
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                List<bool> left = null;
                List<bool> right = null;

                if (Left != null)
                {
                    List<bool> leftPath = new List<bool>();
                    leftPath.AddRange(data);
                    leftPath.Add(false);

                    left = Left.Traverse(symbol, leftPath);
                }

                if (Right != null)
                {
                    List<bool> rightPath = new List<bool>();
                    rightPath.AddRange(data);
                    rightPath.Add(true);
                    right = Right.Traverse(symbol, rightPath);
                }

                if (left != null)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
        }
        public static Node Deserialize(byte[] node)
        {
            Node result;
            char symbol = (char)node[0];
            int freq = BitConverter.ToInt32(node, 1);
            Node right = null, left = null;
            byte[] rightArray = null, leftArray = null, lengthArray = new byte[4];
            int rLength, lLength;
            rLength = BitConverter.ToInt32(node, 5);

            if (rLength>0)
            {
                rightArray = new byte[rLength];
                Buffer.BlockCopy(node, 9, rightArray, 0, rLength);
                right = Node.Deserialize(rightArray);
            }
            lLength = BitConverter.ToInt32(node, 9 + rLength);
            if (lLength > 0)
            {
                leftArray = new byte[lLength];
                Buffer.BlockCopy(node, 13+rLength, leftArray, 0, lLength);
                left = Node.Deserialize(leftArray);
            }
            result = new Node
            {
                Symbol = symbol,
                Frequency = freq,
                Right = right,
                Left = left
            };
            return result;
        }
        public byte[] Serialize()
        {
            byte[] result;
            byte symbol = (byte)this.Symbol;
            byte[] freq = new byte[sizeof(int)];
            freq = BitConverter.GetBytes(this.Frequency);
            byte[] right, left;
            int rLength, lLength;
            if (this.Right != null)
            {
                right = this.Right.Serialize();
                rLength = right.Length;
            }
            else
            {
                rLength = 0;
                right = null;
            }
            if (this.Left != null)
            {
                left = this.Left.Serialize();
                lLength = left.Length;
            }
            else
            {
                lLength = 0;
                left = null;
            }
            result = new byte[13 + rLength + lLength];
            result[0] = symbol;
            Buffer.BlockCopy(freq, 0, result, 1, 4);            
            Buffer.BlockCopy(BitConverter.GetBytes(rLength), 0, result, 5, 4);
            if (rLength > 0)
            {
                Buffer.BlockCopy(right, 0, result, 9, rLength);
            }
            Buffer.BlockCopy(BitConverter.GetBytes(lLength), 0, result, 9+rLength, 4);
            if (lLength > 0)
            {
                Buffer.BlockCopy(left, 0, result, 13+rLength, lLength);
            }            
            return result;
        }
    }
}
