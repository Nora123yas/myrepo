using UnityEngine;

public class SphereArrayGenerator : MonoBehaviour
{
    public GameObject spherePrefab;
    public float spacing = 2f;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Vector3 position = new Vector3(i * spacing, 0, j * spacing);
                Instantiate(spherePrefab, position, Quaternion.identity);
            }
        }
    }
}