using UnityEngine;

public class Gear : MonoBehaviour
{
    #region Private variables
    [SerializeField]
    [Tooltip("If true object will rotate in opposite direction")]
    private bool invertRotation;

    [SerializeField]
    [Tooltip("The more the faster it will rotate")]
    private float gearRatio = 1;
    #endregion

    /// <summary>
    /// Rotate around Y axis
    /// </summary>
    /// <param name="deltaRotation"></param>
    public void OnRotationChange(float deltaRotation)
    {
        deltaRotation = invertRotation ? -deltaRotation : deltaRotation;
        transform.RotateAround(transform.position, transform.up, deltaRotation * gearRatio);
    }
}
