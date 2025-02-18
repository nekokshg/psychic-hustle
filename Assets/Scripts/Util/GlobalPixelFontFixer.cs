using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlobalPixelFontFixer : MonoBehaviour
{
    private void Start()
    {
        TextMeshProUGUI[] allTextObjects = FindObjectsOfType<TextMeshProUGUI>();
        foreach (var tmp in allTextObjects)
        {
            if (tmp.font != null && tmp.font.material!= null)
            {
                tmp.font.material.mainTexture.filterMode= FilterMode.Point;
            }
        }
    }
}
