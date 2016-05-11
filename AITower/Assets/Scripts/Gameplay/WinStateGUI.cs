using UnityEngine;
using System.Collections;

public class WinStateGUI : MonoBehaviour {
  public DeathPersist deathPersist;
  public int numberOfPGDeaths;
  public int numberOfBossDeaths;
  public GUIStyle style = new GUIStyle();

  void Start() {
    GameObject deathPersistObj = GameObject.Find("DeathPersist");
    if(deathPersistObj != null) {
      deathPersist = deathPersistObj.GetComponent<DeathPersist>();
      if(deathPersist == null) {
        Debug.Log("Error.. Death Persist Object Exists but Its Script is Null");
      } else {
        numberOfPGDeaths = deathPersist.pgDeaths;
        numberOfBossDeaths = deathPersist.bossDeaths;
      }
    } else {
      Debug.Log("Error.. Death Persist Object Can Not Be Found");
    }
  }

  public void OnGUI() {
    string endString;
    endString = "Congratulations! You Have Beaten the Game";
    endString += "\n            You Died a Total of "+(numberOfPGDeaths+numberOfBossDeaths)+" Times";
    GUI.Box(new Rect(Screen.width/2 - 116, Screen.height - 200,400,200), endString, style);
  }

}
