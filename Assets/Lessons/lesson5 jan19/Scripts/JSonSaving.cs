using UnityEngine;
using System.IO;

public class JSonSaving : MonoBehaviour
{
    public string filePath;
    public SaveProfile profileData;
    string profileName;
    [ContextMenu("JSON Save")]

    public void SaveData()
    {
        SaveProfile saveProfile = new SaveProfile("Sujan", 1111);
        string file = filePath + profileName + ".json";
        string json = JsonUtility.ToJson(saveProfile, true);

        File.WriteAllText(filePath, json);
    }

    [ContextMenu("JSON Load")]

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            profileData = JsonUtility.FromJson<SaveProfile>(json);
        }

        else
        {
            Debug.LogError("Save file not found");
        }
    }
}
