using UnityEngine;
using System.Collections;

// This class is a singleton
// This class defines the constraints for the procedural generation system and
// the genetic evolution system. For example, this could define the min and max
// speed of a trajectory.

public class Constraints : MonoBehaviour {
  // Constraints for EulerTrajectory
  public float EulerTrajectoryMaxAcceleration = -0.05f;
  public float EulerTrajectoryMinAcceleration = -0.4f;
  public float EulerTrajectoryMinStartingYVelocity = 0.09f;
  public float EulerTrajectoryMaxStartingYVelocity = 0.4f;
  // Constraints for FractalTrajectory
  // Constraints for LineTrajectory
  // Constraints for SineTrajectory
  public float SineTrajectoryMaxAmplitude = 2.0f;
  public float SineTrajectoryMinAmplitude = 0.5f;
  public float SineTrajectoryMaxCrest = 1.0f;
  public float SineTrajectoryMinCrest = 0.04f;
  // Constraints for Trajectory
  public float TrajectoryMaxSpeed = 1.0f;
  public float TrajectoryMinSpeed = 0.1f;
  // Constraints for GA
  public int GAMaxBulletsPerWave = 0;
  public int GAMinBulletsPerWave = 0;
  public float GAMutationRate = 0.0f;
  public float GACrossoverRate = 0.0f;
  public float MinEulerRate = 0.0f;
  public float MaxEulerRate = 0.0f;
  public float MinFractalRate = 0.0f;
  public float MaxFractalRate = 0.0f;
  public float MinLineRate = 0.0f;
  public float MaxLineRate = 0.0f;
  public float MinSineRate = 0.0f;
  public float MaxSineRate = 0.0f;
  // Constraints for Procedural Generation
  // ?????????????????????????????????????
}
