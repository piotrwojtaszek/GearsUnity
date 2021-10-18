using UnityEngine;
using TMPro;
public class UI_AngleDisplayer_EventBased : MonoBehaviour
{
    #region Private variables
    [SerializeField]
    private int handleId;
    private TextMeshProUGUI rotationText;
    private float sumOfDeltaRotation = 0f;
    #endregion

    private void Awake() => rotationText = GetComponent<TextMeshProUGUI>();
    void Start() => GearHandle_EventBased.onRotationChange += UpdateDisplay;
    private void OnDestroy() => GearHandle_EventBased.onRotationChange -= UpdateDisplay;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rotation"></param>
    /// <param name="id"></param>
    private void UpdateDisplay(float rotation, int id)
    {
        if (handleId == id)
            rotationText.text = $"Angle : {UpdateSumOfDeltaRotation(rotation).ToString("F0")}";
    }

    /// <summary>
    /// Sums up all the differences in rotation
    /// </summary>
    /// <param name="rotation"></param>
    /// <returns></returns>
    private float UpdateSumOfDeltaRotation(float rotation) => sumOfDeltaRotation -= rotation;


}