using UnityEngine;
using TMPro;
[RequireComponent(typeof(TextMeshProUGUI))]
public class UI_AngleDisplayer : MonoBehaviour
{
    #region Private variables
    private TextMeshProUGUI rotationText;
    private float sumOfDeltaRotation = 0f;
    #endregion

    private void Awake() => rotationText = GetComponent<TextMeshProUGUI>();

    /// <summary>
    /// Sums up all the differences in rotation
    /// </summary>
    /// <param name="rotation"></param>
    /// <returns></returns>
    private float UpdateSumOfDeltaRotation(float rotation) => sumOfDeltaRotation -= rotation;

    /// <summary>
    /// Update text in UGUI component
    /// </summary>
    /// <param name="id"></param>
    /// <param name="deltaRotation"></param>
    public void OnRotationChange(float deltaRotation) => rotationText.text = $"Angle : {UpdateSumOfDeltaRotation(deltaRotation).ToString("F0")}";
}