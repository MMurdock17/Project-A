using UnityEngine;

public class SelectionArrow : MonoBehaviour
{
    private RectTransform rect;
    [SerializeField] private RectTransform[] options;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
}
