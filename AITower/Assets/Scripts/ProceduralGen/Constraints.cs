using UnityEngine;
using System.Collections;

// This class is a singleton
// This class defines the constraints for the procedural generation system and
// the genetic evolution system. For example, this could define the min and max
// speed of a trajectory.

public class Constraints : MonoBehaviour {
  ////////////////////// GLOBAL FUNCTIONS ///////////////////////////

  private static Constraints instance;

  public static Constraints GetInstance() {
    return instance;
  }

  public static void Initialize() {
    instance = new Constraints();
  }

  ///////////////////////////////////////////////////////////////////
  // Constraints for EulerTrajectory
  public float EulerTrajectoryMaxAcceleration = 0.0f;
  public float EulerTrajectoryMinAcceleration = 0.0f;
  public float EulerTrajectoryMaxStartingYVelocity = 0.0f;
  public float EulerTrajectoryMinStartingYVelocity = 0.0f;
  // Constraints for FractalTrajectory
  // Constraints for LineTrajectory
  // Constraints for SineTrajectory
  public float SineTrajectoryMaxAmplitude = 0.0f;
  public float SineTrajectoryMinAmplitude = 0.0f;
  public float SineTrajectoryMaxCrest = 0.0f;
  public float SineTrajectoryMinCrest = 0.0f;
  // Constraints for Trajectory
  public float TrajectoryMaxSpeed = 0.0f;
  public float TrajectoryMinSpeed = 0.0f;
  // Constraints for GA
  public int GAMaxBulletsPerWave = 0;
  public int GAMinBulletsPerWave = 0;
  public float GAMutationRate = 0.0f;
  public float GACrossoverRate = 0.0f;
  // Constraints for Procedural Generation
  // ?????????????????????????????????????
}
