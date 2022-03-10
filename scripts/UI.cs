using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    public GameObject infoScreen;
    public void LoadScene()
    {
        SceneManager.LoadScene("game");
    }
}
