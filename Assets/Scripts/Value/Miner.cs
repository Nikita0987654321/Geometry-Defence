using UnityEngine;

public class Miner : MonoBehaviour
{
    public float increaseAmount = 10f;
    public float interval = 1f;
    public Building color; // Ссылка на объект CardManager

    private float timer = 0f;

    private void Update()
    {
        if (color._renderer.material.color == color.colorMaterial)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                timer = 0f;
                ValueCounter.value += increaseAmount;
            }
        }
    }
}