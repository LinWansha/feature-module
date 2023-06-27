using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RedPointSystem
{
    public delegate void OnPointNumChange(RedPointNode node);
    RedPointNode mRootNode;
    static List<string> istRedPointTreeList = new List<string>
    {
      RedPointConst.main,
      RedPointConst.mail,
      RedPointConst.mailTeam,
      RedPointConst.mailSystem,
};

    public void InitRedPointTreeNode()
    {
        mRootNode = new RedPointNode();
        mRootNode.nodeName = RedPointConst.main;
        foreach (var s in istRedPointTreeList)
        {
            var node = mRootNode;
            var treeNodeAy = s.Split('.');
            if (treeNodeAy.Length > 1)
            {
                for (int i = 0; i < treeNodeAy.Length; i++)
                {
                    if (!node.dicChilds.ContainsKey(treeNodeAy[i]))
                        node.dicChilds.Add(treeNodeAy[i], new RedPointNode());
                    node.dicChilds[treeNodeAy[i]].nodeName = treeNodeAy[i];
                    node.dicChilds[treeNodeAy[i]].parent = node;
                    node = node.dicChilds[treeNodeAy[i]];
                }
            }
        }
    }
    public void SetRedPointNodeCallBack(string strNode, RedPointSystem.OnPointNumChange callBack)
    {
        var nodeList = strNode.Split('.');
        var node = mRootNode;
        for (int i = 0; i < nodeList.Length; i++)
        {
            if (!node.dicChilds.ContainsKey(nodeList[i]))
            {
                Debug.LogWarning("未找到父节点" + nodeList[i]);
                return;
            }
            node = node.dicChilds[nodeList[i]];
            if (i == nodeList.Length - 1)
            {
                node.OnPointNumChange = callBack;
            }
        }
    }

    public void SetInvoke(string strNode, int rpNum)
    {
        var nodeList = strNode.Split('.');
        var node = mRootNode;
        for (int i = 0; i < nodeList.Length; i++)
        {
            if (!node.dicChilds.ContainsKey(nodeList[i]))
            {
                Debug.LogWarning("未找到父节点" + nodeList[i]);
                return;
            }
            node = node.dicChilds[nodeList[i]];
            if (i == nodeList.Length - 1)
            {
                node.SetRedPointNum(rpNum);
            }
        }
    }
}