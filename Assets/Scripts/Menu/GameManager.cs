using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image _fonImage;
    [SerializeField] private float _speed;
    [SerializeField] private float _currentPosition = 960f;

    private void Start()
    {
        _currentPosition = 960f;
    }
    private void Update()
    {
        Vector3 targetPosition = new Vector2(_currentPosition, _fonImage.rectTransform.anchoredPosition.y);
        _fonImage.rectTransform.anchoredPosition = Vector3.Lerp(_fonImage.rectTransform.anchoredPosition, targetPosition, Time.deltaTime * _speed);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        _currentPosition = -960f;
    }
    public void Back()
    {
        _currentPosition = 960f;
    }

    public void LVL1()
    {
        SceneManager.LoadScene("01_Level_Scene");
    }
}
