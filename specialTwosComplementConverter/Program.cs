
// Test data 1
double expectedResult = -74.5;
byte byte1 = Convert.ToByte("10110101", 2);
byte byte2 = Convert.ToByte("10000000", 2);

// Testing code
if(ConvertSpecialTwosComplement(byte1, byte2) == expectedResult)
{
    Console.WriteLine("Correct result");
} else
{
    Console.WriteLine("Wrong result");
}

// Convert two bytes with the following format into a float
// byte 1 -128 64 32 16 8 4 2 1
// byte 2 0.5 x x x x x x x
// The bytes are read from a LM75 module 
double ConvertSpecialTwosComplement(byte byte1, byte byte2) 
{
    double[] CONVERSION_TABLE = { -128, 64, 32, 16, 8, 4, 2, 1, 0.5 };

    double result = 0;

    Convert.ToString(byte1);

    short[] bits = new short[9];

    {
        short[] byte1Bits = GetBitArray(byte1);
        short[] byte2Bits = GetBitArray(byte2);

        for(int i = 0; i < 8; i++)
        {
            bits[i] = byte1Bits[i];
        }
        bits[8] = byte2Bits[0];
    }

    for(int i = 0; i < 9; i++)
    {
        result += bits[i] * CONVERSION_TABLE[i];
    }

    return result;
}

short[] GetBitArray(byte b)
{
    bool[] bitArrayBool = new bool[8];
    for (int i = 0; i < 8; i++)
    {
        bitArrayBool[7 - i] = (b & (1 << i)) != 0; // Check if the i-th bit is set
    }

    short[] bitArrayShort = new short[8];
    for(int i = 0; i < 8; i++)
    {
        if(bitArrayBool[i])
        {
            bitArrayShort[i] = 1;
            continue;
        }
        bitArrayShort[i] = 0;
    }

    return bitArrayShort;
}