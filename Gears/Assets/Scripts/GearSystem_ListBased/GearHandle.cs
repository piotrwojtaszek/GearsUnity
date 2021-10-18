using UnityEngine;

public class GearHandle : MonoBehaviour
{
    #region Private variables
    [SerializeField]
    private int id;
    private Vector3 prevoiusRotation;
    #endregion

    private void Start()
    {
        prevoiusRotation = transform.localEulerAngles;
    }

    private void Update()
    {
        OnRotationChangeTrigger();
    }
    /// <summary>
    /// If rotation of object has changed call function
    /// </summary>
    private void OnRotationChangeTrigger()
    {
        if (prevoiusRotation == transform.localEulerAngles)
            return;
        GearManager.Instance.UpdateAllObjectsOnList(id, CalculateDeltaRotation());
        prevoiusRotation = transform.localEulerAngles;
    }

    /// <summary>
    /// Return diffrence between current rotation and rotation in last frame
    /// </summary>
    /// <param name="rotation"></param>
    private float CalculateDeltaRotation()
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
