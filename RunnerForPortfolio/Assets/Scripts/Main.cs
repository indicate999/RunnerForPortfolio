using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject RestartPanel;

    [HideInInspector] public int scoreCount = 0;
    [SerializeField] private Text scoreCountText;

    //When this method is called, the points in the ui element are updated
    public void UpdateScore()
    {
        scoreCountText.text = scoreCount.ToString();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
