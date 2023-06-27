using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPointNode
{

    public string nodeName;
    public int pointNum = 0;
    public RedPointNode parent = null;
    public RedPointSystem.OnPointNumChange OnPointNumChange;
    public Dictionary<string, RedPointNode> dicChilds = new Dictionary<string, RedPointNode>();

    public void SetRedPointNum(int rpNum)
    {
        if (dicChilds.Count > 0)
        {
            Debug.LogWarning("onlyC案setleaf Node");
            return;
        }
        pointNum = rpNum;
        NotifyPointNumChange();
        if (parent != null)
        {
            parent.ChangePredPointNum();
        }
    }

    public void ChangePredPointNum()
    {
        int num = 0;
        foreach (var item in dicChilds.Values)
        {
            num += item.pointNum;
        }
        if (num != pointNum)
        {
            pointNum = num;
            if (parent != null)
                parent.ChangePredPointNum();
            NotifyPointNumChange();
        }
    }
    public void NotifyPointNumChange()
    {
        OnPointNumChange?.Invoke(this);
    }
}