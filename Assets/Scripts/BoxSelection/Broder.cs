using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 框选3D物体
/// </summary>
public class Broder : MonoBehaviour
{
    /// <summary>
    /// 鼠标起始位置，和当前位置
    /// </summary>
    Vector2 startPos, nowPos;
    /// <summary>
    /// 选中框
    /// </summary>
    public Image broder;
    /// <summary>
    /// UI上的选中范围
    /// </summary>
    private Rect selectRect;
    /// <summary>
    /// 可被选中的游戏对象数组
    /// </summary>
    private GameObject[] objs;
    void Start()
    {
        objs= GameObject.FindGameObjectsWithTag("Respawn");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos= Input.mousePosition;
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }

        if (Input.GetMouseButton(0))
        {
            nowPos = Input.mousePosition;
            Vector2 center=(startPos + nowPos) / 2;//勾选框的中心点
            Vector2 size= new Vector2(Mathf.Abs(nowPos.x - startPos.x), Mathf.Abs(nowPos.y - startPos.y));
            SetBroder(center,size);//Debug.Log(string.Format(center+"      "+ size));
            selectRect = new Rect(center - (size / 2), size);
            SelectObj();
        }

        if (Input.GetMouseButtonUp(0))
        {
            broder.gameObject.SetActive(false);
        }
    }

    private void SelectObj()
    {
        for (int i = 0; i < objs.Length; i++)
        {
            if (selectRect.Contains(Camera.main.WorldToScreenPoint(objs[i].transform.position)))
            {
                //todo:===Logic：
                //这里选择修改颜色来展示效果  
                objs[i].GetComponent<MeshRenderer>().material.color= Color.red;
            }
            else
            {
                objs[i].GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
    }

    /// <summary>
    /// 设置选中框
    /// </summary>
    private void SetBroder(Vector2 pos,Vector2 size)
    {
        broder.gameObject.SetActive(true);
        broder.rectTransform.position = pos;   
        broder.rectTransform.sizeDelta = size; 
    }

}
