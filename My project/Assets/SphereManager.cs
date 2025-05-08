using UnityEngine;
using System.Collections.Generic;
using System.Linq; // ������Ҫ���

public class SphereManager : MonoBehaviour
{
    public Transform targetSphere; // Ҫ��קָ����Ŀ��Sphere
    private List<Transform> allSpheres = new List<Transform>();

    void Start()
    {
        // �ռ����д�"Sphere"��ǩ������
        GameObject[] spheres = GameObject.FindGameObjectsWithTag("Sphere");
        foreach (GameObject go in spheres)
        {
            allSpheres.Add(go.transform);
        }
    }

    void Update()
    {
        UpdateNeighbors();
    }

    void UpdateNeighbors()
    {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

        // ����1������ƽ��
        stopwatch.Start();
        var sorted1 = allSpheres.OrderBy(s => GetSqrDistance(s.position)).Take(5).ToList();
        stopwatch.Stop();
        Debug.Log($"����ƽ����ʱ��{stopwatch.ElapsedMilliseconds}ms");

        // ����2����ƽ��
        stopwatch.Restart();
        var sorted2 = allSpheres.OrderBy(s => GetRealDistance(s.position)).Take(5).ToList();
        stopwatch.Stop();
        Debug.Log($"��ƽ����ʱ��{stopwatch.ElapsedMilliseconds}ms");
    }

    // ����ƽ���ļ��㣨�죩
    float GetSqrDistance(Vector3 pos)
    {
        Vector2 targetPos = new Vector2(targetSphere.position.x, targetSphere.position.z);
        Vector2 currentPos = new Vector2(pos.x, pos.z);
        return (targetPos - currentPos).sqrMagnitude; // ʡȥ��ƽ��
    }

    // ��ƽ���ļ��㣨����
    float GetRealDistance(Vector3 pos)
    {
        Vector2 targetPos = new Vector2(targetSphere.position.x, targetSphere.position.z);
        Vector2 currentPos = new Vector2(pos.x, pos.z);
        return Vector2.Distance(targetPos, currentPos); // �Զ���ƽ��
    }
}