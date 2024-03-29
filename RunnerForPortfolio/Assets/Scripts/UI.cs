using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _restartPanel;

    [SerializeField] private Text _scoreCountText;

    private int _scoreCount = 0;

    public void HideStartPanel()
    {
        _startPanel.SetActive(false);
    }

    public void ShowRestartPanel()
    {
        Time.timeScale = 0;
        _restartPanel.SetActive(true);
    }

    public void AddScore()
    {
        _scoreCount++;
        _scoreCountText.text = _scoreCount.ToString();
    }
}
