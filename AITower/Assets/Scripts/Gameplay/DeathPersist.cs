using UnityEngine;
using System.Collections;

public class DeathPersist : MonoBehaviour {
  public int pgDeaths;
  public int bossDeaths;

  void Start() {
    DontDestroyOnLoad(gameObject);
  }
}
