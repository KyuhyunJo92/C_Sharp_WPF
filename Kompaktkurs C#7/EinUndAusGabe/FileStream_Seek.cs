using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ein_undAusgebe
{
    class FileStream_Seek
    {
        
    }
}
/*using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                // Write the data to the file, byte by byte.
                for (int i = 0; i < dataArray.Length; i++)
                {
                    fileStream.WriteByte(dataArray[i]);
                }

                // Set the stream position to the beginning of the file.
                fileStream.Seek(0, SeekOrigin.Begin);

                // Read and verify the data.
                for (int i = 0; i < fileStream.Length; i++)
                {
                    if (dataArray[i] != fileStream.ReadByte())
                    {
                        Console.WriteLine("Error writing data.");
                        return;
                    }
                }
                Console.WriteLine("The data was written to {0} " +
                    "and verified.", fileStream.Name);
            }*/
/*static void Main()
        {
            const string fileName = "Test#@@#.dat";

            // Create random data to write to the file.
            byte[] dataArray = new byte[1000];
            new Random().NextBytes(dataArray);//einfullen allen einzelne Elemente

            FileStream fileStream = new FileStream(fileName, FileMode.Create);

            // Write the data to the file, byte by byte.
            for (int i = 0; i < dataArray.Length; i++)
            {
                fileStream.WriteByte(dataArray[i]);
            }

            // Set the stream position to the beginning of the file.
            fileStream.Seek(0, SeekOrigin.Begin);

            // Read and verify the data.
            for (int i = 0; i < fileStream.Length; i++)
            {
                Console.Write("{0}; ", fileStream.ReadByte());
                //if (dataArray[i] != fileStream.ReadByte())
                //{
                //    Console.WriteLine("Error writing data.");
                //    return;
                //}
            }
            Console.WriteLine("The data was written to {0} " + "and verified.", fileStream.Name);
            
        }*/
