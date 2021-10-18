using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GearHandleRotationChange : MonoBehaviour, IRotatationChange
{
    [SerializeField]
    private int handleId;

    public int HandleId { get => handleId;}

    [SerializeField]
    private UnityEvent<float> onRotationChange;

    private void Start() => GearManager.Instance.AddToListOnRotationChange(this);

    private void OnDestroy() => GearManager.Instance.RemoveFromListOnRotationChange(this);

    public void OnRotationChange(int id, float deltaRotation)
    {
        if (id != HandleId)
            return;
        onRotationChange?.Invoke(deltaRotation);
    }
}
