using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BootStart : MonoBehaviour
{
    public Image imgMail;
    public Image imgMailSystem;
    public Image imgMailTeam;
    public Text textMail;
    public Text textMailSystem;
    public Text textMailTeam;

    private void Start()
    {
        RedPointSystem rps = new RedPointSystem();
        rps.InitRedPointTreeNode();
        rps.SetRedPointNodeCallBack(RedPointConst.mail, MailCallBack);
        rps.SetRedPointNodeCallBack(RedPointConst.mailSystem, MailSystemCallBack);
        rps.SetRedPointNodeCallBack(RedPointConst.mailTeam, MailTeamCallBack);
        rps.SetInvoke(RedPointConst.mailSystem, 3);
        rps.SetInvoke(RedPointConst.mailTeam, 2);


        void MailCallBack(RedPointNode node)
        {
            textMail.text = node.pointNum.ToString();
            imgMail.gameObject.SetActive(node.pointNum > 0);
        }

        void MailSystemCallBack(RedPointNode node)
        {
            textMailSystem.text = node.pointNum.ToString();
            imgMailSystem.gameObject.SetActive(node.pointNum > 0);
        }

        void MailTeamCallBack(RedPointNode node)
        {
            textMailTeam.text = node.pointNum.ToString();
            imgMailTeam.gameObject.SetActive(node.pointNum > 0);
        }
    }
}