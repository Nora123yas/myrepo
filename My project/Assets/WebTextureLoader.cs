using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class WebTextureLoader : MonoBehaviour
{
    public string imageUrl = "https://picsum.photos/512"; // 测试用随机图片
    private Renderer sphereRenderer;

    void Start()
    {
        sphereRenderer = GetComponent<Renderer>();
        StartCoroutine(LoadTexture());

        InvokeRepeating("RandomMove", 1.0f, 1.0f);    // 1秒后开始，每1秒执行
        InvokeRepeating("LogPosition", 0.5f, 0.5f);   // 0.5秒后开始，每0.5秒执行
    }

    void RandomMove()
    {
        float newX = Random.Range(-5f, 5f);
        float newZ = Random.Range(-5f, 5f);
        transform.position = new Vector3(newX, 0, newZ);
    }

    void LogPosition()
    {
        Debug.Log($"{gameObject.name} 位置: {transform.position}");
    }

    IEnumerator LoadTexture()
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("加载失败: " + www.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                sphereRenderer.material.mainTexture = texture;
            }
        }
    }
}