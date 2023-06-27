using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField]
    RectTransform Handle, Fill;

    float handleAnchorMax;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handleAnchorMax = Handle.anchorMax.x;

        if (handleAnchorMax >= 0.5)
        {
            Fill.pivot = new Vector2(0, 0.5f);
            Fill.GetComponent<Image>().color = Color.red;

            Fill.GetComponent<Image>().fillOrigin = 0;
        }
        else
        {
            Fill.pivot = new Vector2(1, 0.5f);
            Fill.GetComponent<Image>().color = Color.blue;

            Fill.GetComponent<Image>().fillOrigin = 1;
        }
        Debug.LogError(Mathf.Abs(Handle.localPosition.x));
        Fill.GetComponent<Image>().fillAmount=Mathf.Abs(Handle.localPosition.x/100);
    }
}
