using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBar : MonoBehaviour
{

    public GameObject currentExp;
    public GameObject totalExp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UISlider>().value = (float)currentExp.GetComponent<RollingNumbers>().CurrentValue / (float)int.Parse(totalExp.GetComponent<UILabel>().text);
    }
}
