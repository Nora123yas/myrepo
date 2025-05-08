using UnityEngine;
public class GridGenerator : MonoBehaviour
{
    public GameObject spherePrefab;
    public int gridSize = 5;
    public float spacing = 2.0f;

    void Start()
    {
        Vector3 center = transform.position;

        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                Vector3 pos = new Vector3(
                    center.x + (x - gridSize / 2) * spacing,
                    0,
                    center.z + (z - gridSize / 2) * spacing
                );
                Instantiate(spherePrefab, pos, Quaternion.identity);
            }
        }
    }
}