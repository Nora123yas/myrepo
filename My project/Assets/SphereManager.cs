using UnityEngine;
using System.Collections.Generic;
using System.Linq; // 排序需要这个

public class SphereManager : MonoBehaviour
{
    public Transform targetSphere; // 要拖拽指定的目标Sphere
    private List<Transform> allSpheres = new List<Transform>();

    void Start()
    {
        // 收集所有带"Sphere"标签的物体
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

        // 方法1：不开平方
        stopwatch.Start();
        var sorted1 = allSpheres.OrderBy(s => GetSqrDistance(s.position)).Take(5).ToList();
        stopwatch.Stop();
        Debug.Log($"不开平方耗时：{stopwatch.ElapsedMilliseconds}ms");

        // 方法2：开平方
        stopwatch.Restart();
        var sorted2 = allSpheres.OrderBy(s => GetRealDistance(s.position)).Take(5).ToList();
        stopwatch.Stop();
        Debug.Log($"开平方耗时：{stopwatch.ElapsedMilliseconds}ms");
    }

    // 不开平方的计算（快）
    float GetSqrDistance(Vector3 pos)
    {
        Vector2 targetPos = new Vector2(targetSphere.position.x, targetSphere.position.z);
        Vector2 currentPos = new Vector2(pos.x, pos.z);
        return (targetPos - currentPos).sqrMagnitude; // 省去开平方
    }

    // 开平方的计算（慢）
    float GetRealDistance(Vector3 pos)
    {
        Vector2 targetPos = new Vector2(targetSphere.position.x, targetSphere.position.z);
        Vector2 currentPos = new Vector2(pos.x, pos.z);
        return Vector2.Distance(targetPos, currentPos); // 自动开平方
    }
}