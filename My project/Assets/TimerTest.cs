using UnityEngine;
using UnityTimer; // 告诉Unity我们要用Timer插件

public class TimerTest : MonoBehaviour
{
    void Start()
    {
        // 注册一个每隔2秒说话的闹钟
        Timer.Register(2f,
            () => Debug.Log("叮！2秒到了"),
            isLooped: true); // isLooped=true表示循环

        // 暂停示例（暂时不用）
        // Timer.Pause(this);

        // 取消示例（暂时不用）
        // Timer.Cancel(this);
    }
}