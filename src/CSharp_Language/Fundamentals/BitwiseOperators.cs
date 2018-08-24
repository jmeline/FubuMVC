using System;
using Shouldly;
using Xunit;

namespace CSharp_Language.Fundamentals
{
    public class BitwiseOperators
    {
        // C# provides a lot of flexibility with manipulating bits
        // A bit represents a signal which is either 'on' or 'off'

        public string ConvertToBinary(int value, int padValue = 5) =>
            Convert
                .ToString(value, 2)
                .PadLeft(padValue, '0');

        private Func<int, string> ConvertToBinaryGivenPadValue(int padValue) =>
            binaryValue => ConvertToBinary(binaryValue, padValue);
        

        [Fact]
        public void BinaryAndOperator()
        {
            /* truth table for AND
            -----------------------------
            A         	B         	AND
            -----------------------------
            false       false 	    false
            true 	    false 	    false
            false       true        false
            true        true        true
            */
            
            // operation is represented by & sign
            
            string result;
            const int valueA = 10;  // 01010
            const int valueB = 20;  // 10100
            result =                // 00000
                ConvertToBinary(valueA & valueB);
            result.ShouldBe("00000");

            const int valueD = 15;  // 01111
            const int valueC = 10;  // 01010
            result =                // 01010
                ConvertToBinary(valueD & valueC);    
            result.ShouldBe("01010");
        }
        
        [Fact]
        public void BinaryOrOperator()
        {
            /* truth table for OR
            -----------------------------
            A         	B         	OR
            -----------------------------
            false       false 	    false
            true 	    false 	    true
            false       true        true
            true        true        true
            */
            
            // operation is represented by | sign
            
            string result;
            const int valueA = 10;  // 01010
            const int valueB = 20;  // 10100
            result =                // 11110
                ConvertToBinary(valueA | valueB);
            result.ShouldBe("11110");

            const int valueD = 15;  // 01111
            const int valueC = 10;  // 01010
            result =                // 01111
                ConvertToBinary(valueD | valueC);    
            result.ShouldBe("01111");
        }
        
        [Fact]
        public void BinaryExclusiveOr()
        {
            /* truth table for XOR
            -----------------------------
            A         	B         	OR
            -----------------------------
            false       false 	    false
            true 	    false 	    true
            false       true        true
            true        true        false
            */
            
            // Binary XOR is the Exclusive operator.
            // It is looking for the bits that are different.
            
            // operation is represented by ^ sign
            
            string result;
            const int valueA = 25;  // 11001
            const int valueB = 7;   // 00111
            result =                // 11110
                ConvertToBinary(valueA ^ valueB);
            result.ShouldBe("11110");

            const int valueD = 13;  // 01101
            const int valueC = 5;   // 00101
            result =                // 01000 
                ConvertToBinary(valueD ^ valueC);    
            result.ShouldBe("01000");
        }
        
        [Fact]
        public void BinaryRightShift()
        {
            // Binary right shift operation is used for moving the bits positions towards the right
            // essentially it multiples the number by two each time
            // This operation is represented by >> sign and takes the number of movements
            
            string result;
            const int valueA = 10;  // 01010
            result =                // 00101
                ConvertToBinary(valueA >> 1);
            result.ShouldBe("00101");

            const int valueD = 20;  // 10100
            result =                // 01010
                ConvertToBinary(valueD >> 1);    
            result.ShouldBe("01010");
        }
        
        [Fact]
        public void BinaryLeftShift()
        {
            // Binary left shift operation is used for moving the bits positions towards the left
            // essentially it divides the number by two each time
            // This operation is represented by << sign and takes the number of movements
            
            string result;
            const int valueA = 10;  // 01010
            result =                // 10100
                ConvertToBinary(valueA << 1);
            result.ShouldBe("10100");

            const int valueD = 20;  // 010100
            result =                // 101000
                ConvertToBinary(valueD << 1);    
            result.ShouldBe("101000");
        }
        
        [Fact]
        public void BinaryOnesComplementOperator()
        {
            /* truth table for not  
            -----------------------------
            A         	NOT
            -----------------------------
            true        false
            false       true	    
            */
            
            // Binary Ones Complement Operator is a unary and flips the bits
            // This operation is represented by ~ sign 
            
            byte valueA = 10;            // 00001010
            var result =              // 11110101
                ConvertToBinary((byte)~valueA); 
            result.ShouldBe("11110101");
        }
        
        // Who cares?
        // manipulating bits allows you to do various things. It is quite powerful and neat.
        public enum FavoriteColors
        {
            RED     = 1,  // 00000001
            BLUE    = 2,  // 00000010
            GREEN   = 4,  // 00000100
            BLACK   = 8,  // 00001000
            WHITE   = 16, // 00010000
            YELLOW  = 32, // 00100000
            PURPLE  = 64, // 01000000
            PINK    = 128,// 10000000
        }
        
        [Fact]
        public void WhoCaresAboutBitManipulation()
        {
            // 1. Toggling boolean values
            // neat trick to invert booleans. Bits are more space efficient than integers
            const bool value = true;
            (value ^ true).ShouldBeFalse();     // Allows simple toggling.

            var convertToBinary = ConvertToBinaryGivenPadValue(8);
            void BinaryEquals(byte actual, string expected) => 
                convertToBinary(actual).ShouldBe(expected);

            // 2. Enum Flags
            // each value represents a unique bit that can be toggled and manipulated independently
            BinaryEquals((byte)FavoriteColors.RED,   "00000001");
            BinaryEquals((byte)FavoriteColors.BLUE,  "00000010");
            BinaryEquals((byte)FavoriteColors.GREEN, "00000100");
            BinaryEquals((byte)FavoriteColors.BLACK, "00001000");
            BinaryEquals((byte)FavoriteColors.WHITE, "00010000");
            BinaryEquals((byte)FavoriteColors.YELLOW,"00100000");
            BinaryEquals((byte)FavoriteColors.PURPLE,"01000000");
            BinaryEquals((byte)FavoriteColors.PINK,  "10000000");
            
            // manipulation and toggles can simply be achieved through bit manipulations on bits
            BinaryEquals((byte)(FavoriteColors.RED | FavoriteColors.BLUE), "00000011");
            BinaryEquals((byte)(FavoriteColors.YELLOW | FavoriteColors.BLACK | FavoriteColors.PINK | FavoriteColors.RED), "10101001");
            BinaryEquals((byte)(FavoriteColors.PINK ^ FavoriteColors.RED), "10000001");
            
            // How do we select if we have a certain color toggled?
            byte blueAndRed = (byte) (FavoriteColors.RED | FavoriteColors.BLUE);
            ((blueAndRed & (byte) FavoriteColors.BLUE) > 0).ShouldBeTrue();
            ((blueAndRed & (byte) FavoriteColors.PINK) > 0).ShouldBeFalse();
            
            // you could also do the following for equality
            ((blueAndRed & (byte) FavoriteColors.BLUE) == (byte)FavoriteColors.BLUE).ShouldBeTrue();

            // 3. Masking
            // Lets say you are given the following bits            -> 011100
            // ...but you are only interested in this important bit -> 000010 (aka the mask)
            // masking allows you to clear out the left and right side of the bit you consider important.

            byte mask = (byte)FavoriteColors.BLACK;      // 00001000
            byte input = (byte)(FavoriteColors.BLUE      // 00001010
                                | FavoriteColors.BLACK);
            byte result = (byte) (input & mask);         // 00001000 
            convertToBinary(result).ShouldBe("00001000");
            
            // you can then do the same thing as above where we check for a certain byte through using &
            ((result & (byte) FavoriteColors.BLACK) == (byte) FavoriteColors.BLACK).ShouldBeTrue();
            
            // There are many uses for Bitwise manipulation but here are a few examples.
            // I'm done casting to byte... 
        }
    }
}