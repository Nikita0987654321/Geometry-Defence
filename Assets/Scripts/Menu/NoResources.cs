using UnityEngine;
using UnityEngine.UI;

public class NoResources : MonoBehaviour
{
    public void OnEnable()
    {
        Invoke("Off", 5f);
    }
    private void Off()
    {
        gameObject.SetActive(false);
    }
}
