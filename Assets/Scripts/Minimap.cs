using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 迷你地图
/// </summary>
public class Minimap : MonoBehaviour
{
    public Camera cam;
    public Transform player;
    public Transform playerIcon;
    private float mapSize;//小地图的orthographicSize大小
    public float minSize;
    public float maxSize;
    void Start()
    {
        //orthographicSize正交范围大小
        mapSize = cam.orthographicSize;
    }

    
    void Update()
    {
        cam.transform.position=new Vector3(player.position.x,cam.transform.position.y,player.position.z);
        playerIcon.eulerAngles=new Vector3(0,0,-player.eulerAngles.y);
    }
    /// <summary>
    /// 地图缩放
    /// </summary>
    public void ChangeMapSize(float value)
    {
        mapSize += value;
        //Mathf.Clamp使mapSize在minSize到maxSize之间
        mapSize = Mathf.Clamp(mapSize, minSize, maxSize);
        cam.orthographicSize = mapSize;
        //print(mapSize);
    }
}
