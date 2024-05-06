
// Test data 1
double expectedResult = -74.5;
byte byte1 = Convert.ToByte("10110101", 2);
byte byte2 = Convert.ToByte("10000000", 2);

// Testing code
if(convertSpecialTwosComplement(byte1, byte2) == expectedResult)
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
double convertSpecialTwosComplement(byte byte1, byte byte2) 
{
    return 0;
}
