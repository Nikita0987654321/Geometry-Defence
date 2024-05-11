using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Vector2 _buildingSize;
    public Renderer _renderer;
    public Color colorMaterial;
    public float health;

    public Vector2 BuildingSize { get => _buildingSize; set {; } }

    private void Start()
    {
        colorMaterial = _renderer.material.color;
        GetComponent<Collider>().enabled = false;
    }

    public void SetColor(bool isAvailableToBuild)
    {
        if (isAvailableToBuild)
        {
            ChangeColorRecursive(transform, Color.green);
        }
        else
        {
            ChangeColorRecursive(transform, Color.red);
        }
    }

    private void ChangeColorRecursive(Transform parent, Color color)
    {
        foreach (Transform child in parent)
        {
            Renderer childRenderer = child.GetComponent<Renderer>();
            if (childRenderer != null)
            {
                childRenderer.material.color = color;
            }
            ChangeColorRecursive(child, color);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ResetColor()
    {
        _renderer.material.color = colorMaterial;
        ResetColorRecursive(transform);
    }

    private void ResetColorRecursive(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Renderer childRenderer = child.GetComponent<Renderer>();
            if (childRenderer != null)
            {
                childRenderer.material.color = colorMaterial;
            }
            GetComponent<Collider>().enabled = true;
            ResetColorRecursive(child);
        }
    }
}