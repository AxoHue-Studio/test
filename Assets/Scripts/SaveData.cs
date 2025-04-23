using UnityEngine;
using System.Collections.Generic;

[System.Serializable]

public class SaveData
{
   public Vector3 playerPosition;
   public List<RockIoSaveData> rockIoSaveData;
}

[System.Serializable]

public class RockIoSaveData
{
   public string RockID;
   public bool IsBroken;
}
