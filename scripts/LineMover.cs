using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMover : MonoBehaviour
{
    public float move = 0f;
    void Start()
    {
        StartCoroutine(MoveUp());   
    }
    IEnumerator MoveUp()
    {
        yield return new WaitForSeconds(.1f);
        transform.Translate(0, move * Time.deltaTime, 0);
        yield return new WaitForSeconds(.1f);
        transform.localPosition = new Vector3(0, 0, 0);
        StartCoroutine(MoveDown());
    }
    IEnumerator MoveDown()
    {   
        yield return new WaitForSeconds(.1f);
        transform.Translate(0, -move * Time.deltaTime, 0);
        yield return new WaitForSeconds(.1f);
        transform.localPosition = new Vector3(0, 0, 0);
        StartCoroutine(MoveUp());
    }
}
