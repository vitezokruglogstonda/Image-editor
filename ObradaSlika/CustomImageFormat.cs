using ObradaSlika.Huffman;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObradaSlika
{
    public class CustomImageFormat
    {
        public byte[] Data { get; set; } //offset, width, height, <codes>, data
        public Bitmap Image { get; set; }
        public CustomImageFormat(Bitmap image, bool coding = true)
        {
            byte[] bitmap;
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                bitmap = stream.ToArray();
            }
            int newSize = bitmap.Length - 54 + 12;
            this.Data = new byte[newSize];
            Buffer.BlockCopy(BitConverter.GetBytes((Int32)12), 0, this.Data, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes((Int32)image.Width), 0, this.Data, 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes((Int32)image.Height), 0, this.Data, 8, 4);
            /*
            int j = 16;
            for(int i = 54; i<bitmap.Length; i++)
            {
                this.Data[j] = bitmap[i];
                j++;
            }
            */
            int j = 54;
            for (int i = 12; i < newSize; i++)
            {
                this.Data[i] = bitmap[j];
                j++;
            }
            if (coding)
            {
                //this.HuffmanCode();

                HuffmanTree huffmanTree = new HuffmanTree();

                byte[] dataPart = new byte[newSize-12];
                Buffer.BlockCopy(this.Data, 12, dataPart, 0, newSize-12);
                string input = Encoding.ASCII.GetString(dataPart);

                huffmanTree.Build(input);

                BitArray encoded = huffmanTree.Encode(input);
                byte[] codedData = new byte[(encoded.Length - 1) / 8 + 1];
                encoded.CopyTo(codedData, 0);

                byte[] codes = huffmanTree.GetTree();
                int codesLength = codes.Length;

                int offset = 12;
                Buffer.BlockCopy(codes, 0, this.Data, offset, codesLength);
                offset += codesLength;
                Buffer.BlockCopy(BitConverter.GetBytes(offset), 0, this.Data, 0, 4);
                Buffer.BlockCopy(codedData, 0, this.Data, offset, codedData.Length);
            }
        }
        public CustomImageFormat(byte[] image)
        {
            this.Data = image;
            int codesLength = 0;
            int offset = BitConverter.ToInt32(image, 0);
            if (offset!=12)
            {
                //this.HuffmanDecode();
                codesLength = offset - 12;
                byte[] nodes = new byte[codesLength];
                Buffer.BlockCopy(image, 12, nodes, 0, codesLength);
                HuffmanTree huffmanTree = new HuffmanTree(nodes); 
                byte[] imageData = new byte[image.Length - offset];
                Buffer.BlockCopy(image, offset, imageData, 0, image.Length - offset);
                BitArray encoded = new BitArray(imageData);
                string decoded = huffmanTree.Decode(encoded);
                imageData = new byte[decoded.Length];
                imageData = Encoding.ASCII.GetBytes(decoded);
                offset = 12;
                this.Data = new byte[offset + imageData.Length];
                Buffer.BlockCopy(BitConverter.GetBytes(offset), 0, this.Data, 0, 4);
                Buffer.BlockCopy(image, 4, this.Data, 4, 4);
                Buffer.BlockCopy(image, 8, this.Data, 8, 4);
                Buffer.BlockCopy(imageData, 0, this.Data, offset, imageData.Length);
            }            
            int width = BitConverter.ToInt32(this.Data, 4);
            int height = BitConverter.ToInt32(this.Data, 8);
            this.Image = new Bitmap(width, height);
            BitmapData bmData = this.Image.LockBits(new Rectangle(0, 0, this.Image.Width, this.Image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                for (int i = offset; i < image.Length - codesLength; i++)
                {
                    p[0] = this.Data[i];                    
                    p++;
                }                
            }
            this.Image.UnlockBits(bmData);
            Filters.Flip(this.Image);
        }
        /*
        private void HuffmanCode()
        {
            Dictionary<string, (int,string)> map = new Dictionary<string, (int, string)>();
            for(int i = 12; i<this.Data.Length; i++)
            {
                if (!map.ContainsKey(this.Data[i].ToString()))
                {
                    map.Add(this.Data[i].ToString(), (1,""));
                }
                else
                {
                    map[this.Data[i].ToString()] = (map[this.Data[i].ToString()].Item1+1 , "");
                }
            }
            map = map.OrderByDescending(p => p.Value.Item1).ToDictionary(p => p.Key, p => p.Value);
            int count = map.Count-1;
            string tmpCode = "";
            KeyValuePair<string, (int, string)> pair;
            for(int i = 0; i < map.Count-1; i++)
            {
                tmpCode += "0";
                pair = map.ElementAt(i);
                map[pair.Key] = (pair.Value.Item1, tmpCode);
                count--;
                tmpCode.Remove(tmpCode.Length-1);
                tmpCode += "1";
            }
            pair = map.ElementAt(map.Count-1);
            map[pair.Key] = (pair.Value.Item1, tmpCode);

            //izvuces iz dictionary kao byte[] i stavis ga u heder
            byte[] headerCodes = new byte[map.Count];
            int index = 0;
            foreach (KeyValuePair<string, (int, string)> p in map)
            {
                byte key = Encoding.ASCII.GetBytes(p.Key).First();
                headerCodes[index] = key;
                index++;
                byte[] values = Encoding.ASCII.GetBytes(string.Join("", Encoding.ASCII.GetBytes(p.Value.Item2).Select(n => Convert.ToString(n, 2).PadLeft(8, '0'))));
                int len = values.Length;
                Buffer.BlockCopy(values, 0, headerCodes, index, len);
                index += len;
            }
            int codeLength = headerCodes.Length;
            Buffer.BlockCopy(headerCodes, 0, this.Data, 12, codeLength);
            int newOffset = codeLength + 12;
            Buffer.BlockCopy(BitConverter.GetBytes(newOffset), 0, this.Data, 0, 4);

            //podatke slike zamenis ovim kodovima iz dictionary-ja
            byte[] newData = new byte[];

            //
            Buffer.BlockCopy(newData, 0, this.Data, newOffset, newData.Length);
        }
        private void HuffmanDecode()
        {

        }
        */
    }
}
