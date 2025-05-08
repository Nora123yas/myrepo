using UnityEngine;
using System.Collections;

public class SphereMovement : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(RandomMove());
        StartCoroutine(LogPosition());
    }

    IEnumerator RandomMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Vector3 newPos = transform.position;
            newPos.x = Random.Range(-2f, 2f);
            newPos.z = Random.Range(-2f, 2f);
            transform.position = newPos;
        }
    }

    IEnumerator LogPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log($"Sphere: {gameObject.name} | Position: {transform.position}");
        }
    }
}