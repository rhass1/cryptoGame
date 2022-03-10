using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Controller : MonoBehaviour
{
    public static bool GameIsOver = false;

    float StartTime;
    float elapsedTime;
    public TextMeshProUGUI scoreText;
    public float score;
    private float dragPosition;
    public float moveSpeed = .2f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    public GameObject deadMen;
    private int x = -4;

    void Start()
    {
        StartTime = Time.time;
        Vector3 mousePosition = Input.mousePosition;
        SetBoundaries();

        GCom.StartGame();
    }

    private void SetBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, .12f, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, .8f, 0)).y;
    }
    void Update()
    {
        if (PauseMenu.GamePause)
        {

        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                StartCoroutine(GoLeft());
            }
            else
            {
                Vector3 target = new Vector3(x, dragPosition, -9);
                dragPosition = Mathf.Clamp((Camera.main.ScreenToWorldPoint(Input.mousePosition).y), yMin - .5f, yMax + .5f);
                transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed);
            }
        }

        elapsedTime = Time.time - StartTime;
        score = elapsedTime * 5;
        scoreText.text = "" + Mathf.RoundToInt(score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            GameIsOver = true;
            PauseMenu.GamePause = true;
            Time.timeScale = 0f;
            deadMen.SetActive(true);
            PlayerPrefs.SetInt("HighScore", Mathf.RoundToInt(score));
            Debug.Log(PlayerPrefs.GetInt("HighScore"));

            GCom.EndGame();
        }
    }

    public void Retry()
    {
        GameIsOver = false;
        deadMen.SetActive(false);
        SceneManager.LoadScene("game");
        PauseMenu.GamePause = false;
        Time.timeScale = 1f;
    }

    IEnumerator GoLeft()
    {
        x = -5;
        yield return new WaitForSeconds(.55f);
        x = -4;
    }
}

