using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class WebTextureLoader : MonoBehaviour
{
    public string imageUrl = "https://picsum.photos/512"; // ���������ͼƬ
    private Renderer sphereRenderer;

    void Start()
    {
        sphereRenderer = GetComponent<Renderer>();
        StartCoroutine(LoadTexture());

        InvokeRepeating("RandomMove", 1.0f, 1.0f);    // 1���ʼ��ÿ1��ִ��
        InvokeRepeating("LogPosition", 0.5f, 0.5f);   // 0.5���ʼ��ÿ0.5��ִ��
    }

    void RandomMove()
    {
        float newX = Random.Range(-5f, 5f);
        float newZ = Random.Range(-5f, 5f);
        transform.position = new Vector3(newX, 0, newZ);
    }

    void LogPosition()
    {
        Debug.Log($"{gameObject.name} λ��: {transform.position}");
    }

    IEnumerator LoadTexture()
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("����ʧ��: " + www.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                sphereRenderer.material.mainTexture = texture;
            }
        }
    }
}