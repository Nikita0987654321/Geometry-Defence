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
        _fonImage.rectTransform.anchoredPosition = Vector2.Lerp(_fonImage.rectTransform.anchoredPosition, new Vector2(_currentPosition, 0), Time.deltaTime * _speed);
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
        _currentPosition = 960f;
        SceneManager.LoadScene("01_Level_Scene");
    }
}
