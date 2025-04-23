using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class SaveController : MonoBehaviour
{
    private string saveLocation;
    private RockIO[] rocks;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
        rocks = FindObjectsOfType<RockIO>();

        LoadGame();
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
            rockIoSaveData = GetRockIoState()
        };

        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    private List<RockIoSaveData> GetRockIoState()
    {
        List<RockIoSaveData> rockStates = new List<RockIoSaveData>();

        foreach(RockIO rock in rocks)
        {
            RockIoSaveData rockIoSaveData = new RockIoSaveData
            {
                RockID = rock.RockID,
                IsBroken = rock.IsBroken
            };
            rockStates.Add(rockIoSaveData);
        }
        
        return rockStates;
    }

    public void LoadGame()
    {
        if(File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));

            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;

            LoadRockIoStates(saveData.rockIoSaveData);
        }
        else
        {
            SaveGame();
        }
    }
    
    private void LoadRockIoStates(List<RockIoSaveData> rockStates)
    {
        foreach(RockIO rock in rocks)
        {
            RockIoSaveData rockIoSaveData = rockStates.FirstOrDefault(c => c.RockID == rock.RockID);

            if(rockIoSaveData != null)
            {
                rock.SetBroken(rockIoSaveData.IsBroken);
            }
        }

    }
}
