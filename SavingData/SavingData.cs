using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SavingData : MonoBehaviour
{

    //===============================================================
    //Player settings

   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSettings : MonoBehaviour
{
    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private AudioSource myAudio;

    public void Awake()
    {
        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
            toggle.isOn = true;
            myAudio.enabled = true;
            PlayerPrefs.Save();
        }
        else                            //Add script to Game Gameobject, Music ui obj to Toggle, Audio source to My Audio
        {                               //Game go to obj field in the onvaluechanged of music obj, Select dropdown-playersettings-ToggleMusic()
                                        //
            if (PlayerPrefs.GetInt("music") == 0)
            {
                myAudio.enabled = false;
                toggle.isOn = false;
            }
            else
            {
                myAudio.enabled = true;
                toggle.isOn = true;
            }
        }
    }

    public void ToggleMusic()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("music", 1);
            myAudio.enabled = true;
        }
        else
        {

            PlayerPrefs.SetInt("music", 0);
            myAudio.enabled = false;
        }
        PlayerPrefs.Save();
    }



}
//================================================================
//Save:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class Save
{
    public List<int> livingTargetPositions = new List<int>();
    public List<int> livingTargetsTypes = new List<int>();

    public int hits = 0;
    public int shots = 0;



}
//===================================================================
//Game script(Main):
private Save CreateSaveGameObject()
{
    Save save = new Save();
    int i = 0;
    foreach (GameObject targetGameObject in targets)
    {
        Target target = targetGameObject.GetComponent<Target>();
        if (target.activeRobot != null)
        {
            save.livingTargetPositions.Add(target.position);
            save.livingTargetsTypes.Add((int)target.activeRobot.GetComponent<Robot>().type);
            i++;
        }
    }

    save.hits = hits;
    save.shots = shots;

    return save;
}
public void SaveGame()
{
    Save save = CreateSaveGameObject();

    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
    bf.Serialize(file, save);
    file.Close();

    hits = 0;
    shots = 0;
    shotsText.text = "Shots: " + shots;
    hitsText.text = "Hits: " + hits;

    ClearRobots();
    ClearBullets();
    Debug.Log("Game Saved");
}
public void LoadGame()
{
   if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
    {
        ClearBullets();
        ClearRobots();
        RefreshRobots();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
        Save save = (Save)bf.Deserialize(file);
        file.Close();

        for (int i = 0; i < save.livingTargetPositions.Count; i++)
        {
            int position = save.livingTargetPositions[i];
            Target target = targets[position].GetComponent<Target>();
            target.ActivateRobot((RobotTypes)save.livingTargetsTypes[i]);
            target.GetComponent<Target>().ResetDeathTimer();
        }

        shotsText.text = "Shots: " + save.shots;
        hitsText.text = "Hits: " + save.hits;
        shots = save.shots;
        hits = save.hits;

        Debug.Log("Game Loaded");

        Unpause();
    }
    else
    {
        Debug.Log("No game saved!");
    }
}
//SAVING AS JSON
public void SaveAsJSON()
{
    Save save = CreateSaveGameObject();
    string json = JsonUtility.ToJson(save);

    Debug.Log("Saving as JSON: " + json);
}


}

