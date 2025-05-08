using UnityEngine;
using UnityTimer; // ����Unity����Ҫ��Timer���

public class TimerTest : MonoBehaviour
{
    void Start()
    {
        // ע��һ��ÿ��2��˵��������
        Timer.Register(2f,
            () => Debug.Log("����2�뵽��"),
            isLooped: true); // isLooped=true��ʾѭ��

        // ��ͣʾ������ʱ���ã�
        // Timer.Pause(this);

        // ȡ��ʾ������ʱ���ã�
        // Timer.Cancel(this);
    }
}