using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private int sortingBase = 5000;
    private Renderer myRenderer;
    public int offset;
    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }
    void LateUpdate()
    {
        myRenderer.sortingOrder = (int)(sortingBase - transform.position.y - offset);
    }
}
