using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public GameObject ExpNum;
    private int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = int.Parse(GetComponent<UILabel>().text);
    }

    // Update is called once per frame
    void Update()
    {
        if (ExpNum.GetComponent<RollingNumbers>().IsLevelup)
        {
            GetComponent<UILabel>().text = (currentLevel + 1).ToString();
        }
    }
}
