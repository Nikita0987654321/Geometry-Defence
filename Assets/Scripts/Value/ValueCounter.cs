using UnityEngine;
using TMPro;

public class ValueCounter : MonoBehaviour
{
    public static float value = 50f;
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = value.ToString();
    }
}

