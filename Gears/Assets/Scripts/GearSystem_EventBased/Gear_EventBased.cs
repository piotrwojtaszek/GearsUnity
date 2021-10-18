using UnityEngine;

public class Gear_EventBased : MonoBehaviour
{
    [SerializeField]
    int handleId;
    [SerializeField]
    bool invertRotation;
    [SerializeField]
    float gearRatio = 1;
    private void Start() => GearHandle_EventBased.onRotationChange += MirrorRotation;
    public void MirrorRotation(float rotation, int id)
    {
        if (handleId != id)
            return;
        rotation = invertRotation ? -rotation : rotation;
        transform.RotateAround(transform.position, transform.up, rotation * gearRatio);

    }

    private void OnDestroy() => GearHandle_EventBased.onRotationChange -= MirrorRotation;
}
