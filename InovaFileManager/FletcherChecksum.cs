﻿namespace InovaFileManager
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
	/// Calculates Fletcher's checksums
	/// Sample outputs: 
	/// Fletcher16: "abcde" -> 51440
	/// Fletcher32: "abcde" -> 3948201259
	/// Fletcher64: "abcde" -> 14034561336514601929
	/// </summary>
	public class FletcherChecksum
    {
        /// <summary>
        /// Transforms byte array into an enumeration of blocks of 'blockSize' bytes
        /// </summary>
        /// <param name="inputAsBytes"></param>
        /// <param name="blockSize"></param>
        /// <returns></returns>
        private IEnumerable<UInt64> Blockify(byte[] inputAsBytes, int blockSize)
        {
            int i = 0;

            //UInt64 used since that is the biggest possible value we can return.
            //Using an unsigned type is important - otherwise an arithmetic overflow will result
            UInt64 block = 0;

            //Run through all the bytes			
            while (i < inputAsBytes.Length)
            {
                //Keep stacking them side by side by shifting left and OR-ing				
                block = block << 8 | inputAsBytes[i];

                i++;

                //Return a block whenever we meet a boundary
                if (i % blockSize == 0 || i == inputAsBytes.Length)
                {
                    yield return block;

                    //Set to 0 for next iteration
                    block = 0;
                }
            }
        }

        /// <summary>
        /// Get Fletcher's checksum, n can be either 16, 32 or 64
        /// </summary>
        /// <param name="inputWord"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public UInt64 GetChecksum(String inputWord, int n)
        {
            //Fletcher 16: Read a single byte
            //Fletcher 32: Read a 16 bit block (two bytes)
            //Fletcher 64: Read a 32 bit block (four bytes)
            int bytesPerCycle = n / 16;

            //2^x gives max value that can be stored in x bits
            //no of bits here is 8 * bytesPerCycle (8 bits to a byte)
            UInt64 modValue = (UInt64)(Math.Pow(2, 8 * bytesPerCycle) - 1);

            //ASCII encoding conveniently gives us 1 byte per character 
            byte[] inputAsBytes = Encoding.ASCII.GetBytes(inputWord);

            UInt64 sum1 = 0;
            UInt64 sum2 = 0;
            foreach (UInt64 block in Blockify(inputAsBytes, bytesPerCycle))
            {
                sum1 = (sum1 + block) % modValue;
                sum2 = (sum2 + sum1) % modValue;
            }

            return sum1 + (sum2 * (modValue + 1));
        }
    }
}
