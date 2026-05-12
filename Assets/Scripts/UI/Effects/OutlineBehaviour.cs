using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Materials Settings")]
    private Material[] originalMat;
    private MeshRenderer meshRenderer;
    private Material outlineMat;
    public Material outline; // outline material from shader graph for the inspector

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMat = meshRenderer.materials;
        outlineMat = new Material(outline);
    }

    // Function to activate the outline when mouse is over the domino
    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowOutline();
    }

    // Function to disable the outline when mouse is no longer hovering over domino
    public void OnPointerExit(PointerEventData eventData)
    {
        HideOutline();
    }

    // Function to show outline
    public void ShowOutline()
    {
        Material[] newMaterials = new Material[originalMat.Length + 1];
        for (int i = 0; i < originalMat.Length; i++)
        {
            newMaterials[i] = originalMat[i];
        }
        newMaterials[originalMat.Length] = outlineMat;
        meshRenderer.materials = newMaterials;
    }

    // Function to hide outline
    public void HideOutline()
    {
        meshRenderer.materials = originalMat;
    }
}
