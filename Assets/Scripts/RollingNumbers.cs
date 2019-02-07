using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingNumbers : MonoBehaviour
{
    public  int EndNum;  // the ending number
    public  int InitialNum;   //the initial number
    //from big to small number or small to big number
    public bool IsAdd;
    public int CurrentValue;
    public bool isExp;
    public GameObject TotalExp;
    public bool IsLevelup;

    private int result = 0;
    public float ChangeTime = 2f; //rolling time

    private int change_number;
    private int difference;
    

    // Start is called before the first frame update
    void Start()
    {
        CurrentValue = InitialNum;
        GetComponent<UILabel>().text = InitialNum.ToString();
    }

    private void Update()
    {
        if (name == "CurrentNum")
        {
            print(CurrentValue.ToString());
        }
     
    }

    public void StartRolling()
    {
        difference = EndNum - InitialNum;
        change_number = (int)Mathf.Ceil(difference / (ChangeTime * (1 / 0.05f)));   
        StartCoroutine(Change());
    }

    IEnumerator Change()
    {
        if (IsAdd)
        {
            if (change_number > 0)
            {
                if (!isExp)
                {
                    while (CurrentValue < EndNum)
                    {
                        CurrentValue += change_number;
                        GetComponent<UILabel>().text = CurrentValue.ToString();
                        yield return new WaitForSeconds(0.05f);     // add by every 0.05s
                    }
                }
                else
                {
                    int currentTotalExp = int.Parse(TotalExp.GetComponent<UILabel>().text);

                    if (CurrentValue < currentTotalExp && !IsLevelup)
                    {
                        while (CurrentValue < EndNum && !IsLevelup)
                        {
                            CurrentValue += change_number;
                            GetComponent<UILabel>().text = CurrentValue.ToString();
                            print("1");
                            yield return new WaitForSeconds(0.05f);     // add by every 0.05s
                        }
                    }
                    else if (CurrentValue >= currentTotalExp && !IsLevelup)//level up
                    {
                        IsLevelup = true;
                        CurrentValue -= currentTotalExp;
                    }

                    if (IsLevelup)
                    {
                        while (CurrentValue < EndNum - currentTotalExp && IsLevelup)
                        {
                            CurrentValue += change_number;
                            GetComponent<UILabel>().text = CurrentValue.ToString();
                            print("2");
                            yield return new WaitForSeconds(0.05f);     // add by every 0.05s
                        }
                    }

                }

            }
        }
        else
        {
            if (change_number < 0)
            {
                while (EndNum < CurrentValue)
                {
                    CurrentValue += change_number;
                    GetComponent<UILabel>().text = CurrentValue.ToString();
                    yield return new WaitForSeconds(0.05f);     // add by every 0.05s
                }
            }
        }

        if (!IsLevelup)
        {
            GetComponent<UILabel>().text = EndNum.ToString();
        }
        //already levelup
        else GetComponent<UILabel>().text = (EndNum - int.Parse(TotalExp.GetComponent<UILabel>().text)).ToString();

        StopCoroutine(Change());     

    }


}
