using Sea_battle.Users.Player;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sea_battle.SaveSystem
{
    public static class ProfileSaveSystem
    {
        public static void Save(this PlayerProfile profile)
        {
            BinaryFormatter formatter = new();

            string path = Directory.GetCurrentDirectory() + "\\Profiles\\" + $"\\{profile.Name}.xml";
            FileStream stream = new(path, FileMode.OpenOrCreate);

            formatter.Serialize(stream, profile);
            stream.Close();
        }

        public static PlayerProfile Load(string profileName)
        {
            string path = Directory.GetCurrentDirectory() + "\\Profiles\\" + $"\\{profileName}.xml";

            if (!File.Exists(path))
                return new PlayerProfile();

            BinaryFormatter formatter = new();
            FileStream stream = new(path, FileMode.Open);

            PlayerProfile profile = formatter.Deserialize(stream) as PlayerProfile;
            stream.Close();

            return profile;
        }
    }
}
