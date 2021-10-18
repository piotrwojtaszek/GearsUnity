using System;
using UnityEngine;

public class GearHandle_EventBased : MonoBehaviour
{
    #region Public variables
    public static event Action<float, int> onRotationChange;
    #endregion

    #region Private variables
    [SerializeField]
    private int id;
    private Vector3 prevoiusRotation;
    #endregion

    void Start() => prevoiusRotation = transform.localEulerAngles;

    void Update() => OnRotationChangeTrigger();

    /// <summary>
    /// Raise OnRotationChange event
    /// </summary>
    void OnRotationChangeTrigger()
    {
        if (prevoiusRotation == transform.localEulerAngles)
            return;
        onRotationChange?.Invoke(CalculateDeltaRotation(), id);
        prevoiusRotation = transform.localEulerAngles;
    }

    /// <summary>
    /// Return diffrence between current rotation and rotation in last frame
    /// </summary>
    /// <param name="rotation"></param>
    float CalculateDeltaRotation()
    {
        float deltaRotation = prevoiusRotation.z - transform.localEulerAngles.z;

        #region Check that the counter has turned over
        if (deltaRotation > 300f)
            deltaRotation = deltaRotation - 360f;
        else if (deltaRotation < -300f)
            deltaRotation = deltaRotation + 360f;
        #endregion

        return deltaRotation;
    }
}
