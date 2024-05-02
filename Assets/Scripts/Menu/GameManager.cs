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
        Time.timeScale = 1;
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
        SceneManager.LoadScene(1);
    }

    public void LVL2()
    {
        SceneManager.LoadScene(2);
    }
    public void LVL3()
    {
        SceneManager.LoadScene(3);
    }
    public void LVL4()
    {
        SceneManager.LoadScene(4);
    }
    public void LVL5()
    {
        SceneManager.LoadScene(5);
    }
    public void BOSS()
    {
        SceneManager.LoadScene(6);
    }
}
