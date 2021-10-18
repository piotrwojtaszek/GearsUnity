using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    private float sumOfDeltaRotation;
    private float UpdateSumOfDeltaRotation(float rotation) => sumOfDeltaRotation += rotation;
    public void OnRotationChange(float deltaRotation) => transform.localScale = new Vector3(1f, (UpdateSumOfDeltaRotation(deltaRotation / 1000f)),1f);
}
