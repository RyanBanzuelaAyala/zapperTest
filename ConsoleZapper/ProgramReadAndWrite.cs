
class ProgramReadAndWrite
{
    private const int NumberOfSettings = 8;

    private static byte StringToByteArray(string settings)
    {
        byte result = 0;

        for (int i = 0; i < NumberOfSettings; i++)
        {
            if (settings[i] == '1')
            {
                result |= (byte)(1 << (NumberOfSettings - 1 - i));
            }
        }

        return result;
    }

    private static string ByteArrayToString(byte data)
    {
        char[] chars = new char[NumberOfSettings];

        for (int i = 0; i < NumberOfSettings; i++)
        {
            chars[i] = ((data & (1 << (NumberOfSettings - 1 - i))) != 0) ? '1' : '0';
        }

        return new string(chars);
    }

    public static void WriteSettingsToFile(string settings, string filePath)
    {
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                byte data = StringToByteArray(settings);
                fs.WriteByte(data);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing settings to file: {ex.Message}");
        }
    }

    public static string ReadSettingsFromFile(string filePath)
    {
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                byte[] buffer = new byte[1];
                fs.Read(buffer, 0, 1);
                byte data = buffer[0];
                return ByteArrayToString(data);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading settings from file: {ex.Message}");
            return null;
        }
    }

    public static void Main(string[] args)
    {
        string settings = "00000010";
        string filePath = "user_settings.setting";

        // write
        WriteSettingsToFile(settings, filePath);

        // read
        string readSettings = ReadSettingsFromFile(filePath);
        Console.WriteLine("Read settings from file: " + readSettings);

    }
}