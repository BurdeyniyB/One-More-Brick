using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public int maxCalls;
    [SerializeField] private Color startColor = Color.red;
    [SerializeField] private Color endColor = Color.gray;

    private int calls = 0;

    private void Start()
    {
        spriteRenderer.color = startColor;
    }

    public void ChangeColor()
    {
        calls++;
        float t = (float)calls / maxCalls;

        spriteRenderer.color = Color.Lerp(startColor, endColor, t);
    }

    public void SetMaxCalls(int calls)
    {
      maxCalls = calls;
    }
}
