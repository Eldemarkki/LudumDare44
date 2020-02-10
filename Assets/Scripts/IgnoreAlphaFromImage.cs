using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class IgnoreAlphaFromImage : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    void Awake()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = threshold;
    }
}
