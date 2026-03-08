using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScaleBalancingBehaviour : MonoBehaviour
{
    public float leftWeight, rightWeight;
    public float tiltMax = 30f;
    public float lerpSpeed = 2f;
    public float balanceTolerance = 0.1f;

    [Header("UI Settings")]
    public GameObject nextLevelButton;
    
    void Update()
    {
        float weightDifference = rightWeight - leftWeight;
        float targetX = Mathf.Clamp(weightDifference * 10f, -tiltMax, tiltMax);

        Quaternion targetRotation = Quaternion.Euler(targetX, 0, 0);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * lerpSpeed);

        if (Mathf.Abs(weightDifference) <= balanceTolerance && (leftWeight > 0))
        {
            if (!nextLevelButton.activeSelf)
            {
                nextLevelButton.SetActive(true);
            }
        }
        //Debug.Log($"Weights Left: {leftWeight} | Right: {rightWeight}");
    }
}
