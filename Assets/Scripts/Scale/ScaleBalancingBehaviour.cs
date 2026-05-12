using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class ScaleBalancingBehaviour : MonoBehaviour
{
    [Header ("Scale Settings")]
    public float leftWeight, rightWeight;
    public float tiltMax = 30f;
    public float lerpSpeed = 2f;
    public float balanceTolerance = 0.1f;

    [Header ("Domino Settings")]
    public int totalDominoes;
    public int currentDominoCount;
    private int leftCount, rightCount;

    [Header("UI Settings")]
    public GameObject nextLevelButton;

    [Header ("Particle Settings")]
    public ParticleSystem confetti;
    public ParticleSystem confettiRight;
    public ParticleSystem confettiTop;

    [Header ("Extra Domino Triggers")]
    [SerializeField] private Transform leftBowlAnchor;
    [SerializeField] private Transform rightBowlAnchor;
    [SerializeField] private Vector3 bowlDetectionSize = new Vector3(1.5f, 1f, 1.5f);

    bool isCompleted = false;

    // Unity Event for when level is completed
    public UnityEvent onComplete;

    void Update()
    {
        float weightDifference = rightWeight - leftWeight; // Takes the difference of weight between the right and left scales
        float targetX = Mathf.Clamp(weightDifference * 2f, -tiltMax, tiltMax);

        Quaternion targetRotation = Quaternion.Euler(targetX, 0, 0);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * lerpSpeed);

        bool isBalanced = Mathf.Abs(weightDifference) <= balanceTolerance && (leftWeight > 0);
        bool allDominoes = currentDominoCount == totalDominoes;

        if (isCompleted) return;
        // Win condition if statement
        if (isBalanced && allDominoes && !Mouse.current.leftButton.isPressed && !IsExtraDomino())
        {
            if (!nextLevelButton.activeSelf)
            {
                // Plays confetti and enables button to go to next level
                isCompleted = true;
                nextLevelButton.SetActive(true);
                confetti.Play();
                confettiRight.Play();
                confettiTop.Play();

                onComplete?.Invoke(); // Invokes the onComplete unity event
            }
        }

        if (leftWeight < rightWeight && !isBalanced)
        {
            isCompleted = false;
            nextLevelButton.SetActive(false);
            confetti.Stop();
            confettiRight.Stop();
            confettiTop.Stop();
        }
    }

    private bool IsExtraDomino()
    {
        // Checks the left bowl
        if (CheckExtra(leftBowlAnchor)) return true;

        // Checks the right bowl
        if (CheckExtra(rightBowlAnchor)) return true;

        return false;
    }

    private bool CheckExtra(Transform anchor)
    {
        if (anchor == null) return false;

        Collider[] colliders = Physics.OverlapBox(
            anchor.position,
            bowlDetectionSize / 2f,
            anchor.rotation
        );

        foreach (Collider col in colliders)
        {
            // Checks for the extra tag attached for the domino
            if (col.CompareTag("Extra"))
            {
                return true;
            }
        }
        return false;
    }

    // Function to calculate the weight on the scales and how many objects on scales
    public void UpdatePlatform(bool isLeft, float mass, int count)
    {
        if (isLeft)
        {
            leftWeight = mass;
            leftCount = count;
        } else
        {
            rightWeight = mass;
            rightCount = count;
        }
        currentDominoCount = leftCount + rightCount;
    }
}
