using UnityEngine;

public enum dominoEffect
{
    addition,
    multiply,
    halved,
    sqrt
}

public class DominoEffectsBehaviour : MonoBehaviour
{
    public dominoEffect effect;

    public int pipSideA, pipSideB;
    public float multiplier = 1.5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DominoAddOn();
    }

    void DominoAddOn()
    {
        int totalPips = pipSideA + pipSideB;

        switch (effect)
        {
            case dominoEffect.addition:
                rb.mass = totalPips;
                break;
            case dominoEffect.multiply:
                rb.mass = totalPips * multiplier;
                break;
            case dominoEffect.halved:
                rb.mass = totalPips / 2;
                break;
            case dominoEffect.sqrt:
                rb.mass = Mathf.Sqrt(totalPips);
                break;
        }
    }
}
