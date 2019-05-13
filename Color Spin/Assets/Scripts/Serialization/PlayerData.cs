using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public bool level1Complete;
    public bool level2Complete;
    public bool level3Complete;
    public bool level4Complete;
    public bool level5Complete;
    public bool level6Complete;

    public PlayerData (LevelStatTrack trackScript)
    {
        level1Complete = trackScript.level1Complete;
        level2Complete = trackScript.level2Complete;
        level3Complete = trackScript.level3Complete;
        level4Complete = trackScript.level4Complete;
        level5Complete = trackScript.level5Complete;
        level6Complete = trackScript.level6Complete;



    }

}
