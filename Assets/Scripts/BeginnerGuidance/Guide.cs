﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 新手引导动画
/// </summary>
[RequireComponent(typeof(EventPermeate))]
public class Guide : MonoBehaviour
{
    public Image target;

    private Material material;
    private float diameter; // 直径
    private float current = 0f;
    Vector3[] corners = new Vector3[4];

    public List<Button> btns;
    private void Awake()
    {
        GuideNext();

        for (int i = 0; i < btns.Count; i++)
        {
            int j = i;
            btns[i].onClick.AddListener(() =>
            {
                if (j < btns.Count - 1)
                {
                    target = btns[j + 1].image;
                    GuideNext();
                }
            });
        }
    }
    void GuideNext()
    {

        // 设置事件透传对象
        gameObject.GetComponent<EventPermeate>().target = target.gameObject;

        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        target.rectTransform.GetWorldCorners(corners);
        diameter = Vector2.Distance(WordToCanvasPos(canvas, corners[0]), WordToCanvasPos(canvas, corners[2])) / 2f;

        float x = corners[0].x + ((corners[3].x - corners[0].x) / 2f);
        float y = corners[0].y + ((corners[1].y - corners[0].y) / 2f);

        Vector3 center = new Vector3(x, y, 0f);
        Vector2 position = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, center, canvas.GetComponent<Camera>(), out position);

        center = new Vector4(position.x, position.y, 0f, 0f);
        material = GetComponent<Image>().material;
        material.SetVector("_Center", center);

        (canvas.transform as RectTransform).GetWorldCorners(corners);
        for (int i = 0; i < corners.Length; i++)
        {
            current = Mathf.Max(Vector3.Distance(WordToCanvasPos(canvas, corners[i]), center), current);
        }

        material.SetFloat("_Silder", current);
    }

    float yVelocity = 0f;
    void Update()
    {
        float value = Mathf.SmoothDamp(current, diameter, ref yVelocity, 0.3f);
        if (!Mathf.Approximately(value, current))
        {
            current = value;
            material.SetFloat("_Silder", current);
        }
    }

    void OnGUI()
    {
        if (GUILayout.Button("Test"))
        {
            GuideNext();
        }
    }

    Vector2 WordToCanvasPos(Canvas canvas, Vector3 world)
    {
        Vector2 position = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, world, canvas.GetComponent<Camera>(), out position);
        return position;
    }
}