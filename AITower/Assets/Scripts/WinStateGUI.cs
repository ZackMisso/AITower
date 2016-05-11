using UnityEngine;
using System.Collections;

public class WinStateGUI : MonoBehaviour {
  public int numberOfPGDeaths;
  public int numberOfBossDeaths;
  public GUIStyle style = new GUIStyle();

  public void OnGUI() {
    string endString;
    endString = "Congratulations! You Have Beaten the Game";
    endString += "\n            You Died a Total of "+(numberOfPGDeaths+numberOfBossDeaths)+" Times";
    GUI.Box(new Rect(Screen.width/2 - 116, Screen.height - 200,400,200), endString, style);
  }

}
