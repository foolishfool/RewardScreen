using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingNumbers : MonoBehaviour
{
    public  int endNum;  // the ending number
    public int initialNum;   //the initial number
    //from big to small number or small to big number
    public bool isAdd;
    private int result = 0;
    public float change_time = 2f; //rolling time

    private int change_number;
    private int difference;

    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    public void StartRolling()
    {
        difference = endNum - initialNum;
        change_number = (int)Mathf.Ceil(difference / (change_time * (1 / 0.05f)));    
        StartCoroutine(Change());
    }

    IEnumerator Change()
    {
        if (isAdd)
        {
            if (change_number > 0)
            {
                while (initialNum < endNum)
                {
                    initialNum += change_number;
                    GetComponent<UILabel>().text = initialNum.ToString();
                    yield return new WaitForSeconds(0.05f);     // add by every 0.05s
                }
            }

        }
        else
        {
            if (change_number < 0)
            {
                while (endNum < initialNum)
                {
                    initialNum += change_number;
                    GetComponent<UILabel>().text = initialNum.ToString();
                    yield return new WaitForSeconds(0.05f);     // add by every 0.05s
                }
            }

        }

        GetComponent<UILabel>().text = endNum.ToString();
        StopCoroutine(Change());
    }


}
