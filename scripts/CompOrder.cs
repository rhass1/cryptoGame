using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompOrder : MonoBehaviour
{
    public int offset = -10;
    private int sortingBase = 5000;
    void LateUpdate()
    {
        foreach (var rend in GetComponentsInChildren<Renderer>())
        {
            rend.sortingOrder = -(int)(sortingBase - transform.position.y - offset);
        }
    }
}
