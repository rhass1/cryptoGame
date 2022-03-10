using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
    
{
    public GameObject rock;
    public GameObject rock1;
    public GameObject rock2;
    public GameObject rock3;
    public GameObject rock4;
    public GameObject shark;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(rockWave());
        StartCoroutine(sharkWave());
    }

    private void spawnEnemy()
    {
        int ranNum = Random.Range(1, 4);
        if (ranNum == 1)
        {
            GameObject a = Instantiate(rock) as GameObject;
            a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y + .5f, screenBounds.y - 1.5f));
        }
        if (ranNum == 2)
        {
            GameObject a = Instantiate(rock1) as GameObject;
            a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y + .5f, screenBounds.y - 1.5f));
        }
        if (ranNum == 3)
        {
            GameObject a = Instantiate(rock2) as GameObject;
            a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y + .5f, screenBounds.y - 1.5f));
        }
    }

    private void spawnEnemy2()
    {
        int ranNum = Random.Range(1, 3);
        if (ranNum == 1)
        {
            GameObject a = Instantiate(rock3) as GameObject;
            a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y + .5f, screenBounds.y - 1.5f));
        }
        if (ranNum == 2)
        {
            GameObject a = Instantiate(rock4) as GameObject;
            a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y + .5f, screenBounds.y - 1.5f));
        }
    }

    private void spawnShark()
    {
        GameObject b = Instantiate(shark) as GameObject;
        b.transform.position = new Vector2(10, -screenBounds.y * 2);
    }
    private void spawnShark2()
    {
        GameObject b = Instantiate(shark) as GameObject;
        b.transform.position = new Vector2(14, screenBounds.y * 2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Time")
        {
            StartCoroutine(rockWave2());
            Debug.Log("started");
        }
        if (collision.tag == "zone")
        {
            StartCoroutine(rockWave3());
        }
        if (collision.tag == "zoob")
        {
            StartCoroutine(sharkWave2());
        }
    }
    IEnumerator rockWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy2();
        }
    }

    IEnumerator rockWave2()
    {
        while (true)
        {
            yield return new WaitForSeconds(.9f);
            spawnEnemy();
        }
    }

    IEnumerator rockWave3()
    {
        while (true)
        {
            yield return new WaitForSeconds(.8f);
            spawnEnemy();
        }
    }

    IEnumerator sharkWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(8, 14));
            spawnShark();
        }
    }

    IEnumerator sharkWave2()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(7, 11));
            spawnShark2();
        }
    }
}
