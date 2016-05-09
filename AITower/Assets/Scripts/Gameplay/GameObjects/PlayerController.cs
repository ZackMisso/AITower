using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  // public variables
  public PGSystem pgRef = null;
  public double health;
  public int ammo;

  // private variables
  private Weapon weapon; // the player should have a weapon attached to them

  void Start() {
    weapon = gameObject.GetComponent<Weapon>();
    if(weapon == null) {
      Debug.Log("Player Object Must be Given a Weapon");
    }
    if(pgRef == null) {
      Debug.Log("PGSystem Must Be Linked with Player");
    }
    pgRef.GenerateLevel();
    }

    void Update() {
    // to be implemented
  }
}
