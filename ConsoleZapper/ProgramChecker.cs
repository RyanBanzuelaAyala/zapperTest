
class ProgramChecker
{

    enum Settings
    {
        SMSNotificationsEnabled = 1,
        PushNotificationsEnabled = 2,
        BiometricsEnabled = 3,
        CameraEnabled = 4,
        LocationEnabled = 5,
        NFCEnabled = 6,
        VouchersEnabled = 7,
        LoyaltyEnabled = 8,
    }

    public static bool IsFeatureEnabled(string settings, int setting)
    {
        int index = setting - 1;

        // 1. index = 6 from 7
        // 2. index = 6 from 7
        // 3. index = 3 from 4
        if (index >= 0)
        {
            // 1. index 6 < 8
            // 2. index 6 < 8
            // 3. index 3 < 8
            if (index < settings.Length)
            {
                // 1. array [0,0,0,0,0,0,0,0] 
                // 2. array [0,0,0,0,0,0,1,0]
                // 3. array [1,1,1,1,1,1,1,1]
                return settings[index] == '1';
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(IsFeatureEnabled("00000000", 7)); // Output: False
        Console.WriteLine(IsFeatureEnabled("00000010", 7)); // Output: True
        Console.WriteLine(IsFeatureEnabled("11111111", 4)); // Output: True

    }
}