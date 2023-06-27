using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 跑马灯
/// </summary>
public class Marquee : MonoBehaviour
{
    public Transform runText;
    public InputField inputField;
    public Button btnSend;
    /// <summary>
    /// 存储字幕的队列
    /// </summary>
    Queue<string> msgQue= new Queue<string>() ;
    /// <summary>
    /// 发送是否进入CD,
    /// false没有进入cd可以发送
    /// </summary>
    private bool isCD=false;
    void Start()
    {
        btnSend.onClick.AddListener(RefMarquee);
    }

    private void RefMarquee()
    {
        if (isCD == false)
        {
            msgQue.Enqueue(inputField.text);
            isCD = true;
            btnSend.interactable = false;
        }
        if (string.IsNullOrEmpty(runText.GetComponent<Text>().text))
        {
            runText.GetComponent<Text>().text = msgQue.Dequeue();
        }
    }

    void Update()
    {
        if(!string.IsNullOrEmpty(runText.GetComponent<Text>().text))
        {
            runText.Translate(Vector3.right * Time.deltaTime * 400);
        }
        if (runText.GetComponent<RectTransform>().anchoredPosition.x >= 1160)
        {
            runText.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            runText.GetComponent<Text>().text=string.Empty;
            isCD=false;
            btnSend.interactable = true;
        }
    }
}
