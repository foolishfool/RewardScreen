using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewItem : MonoBehaviour
{

    
    public GameObject NewItem;
    //new item number label in UI
    public GameObject NewItemNumber;
    //the item nubmer label at the lower eara of the UI
    public GameObject LowerItemNumber;
    //icon of new item
    public List<GameObject> ShakingIcons;
    //the from position and to position of new created item
    public List<Transform> froms;
    public Transform to;

    private GameObject newItem;

    private bool isShaking = true;  
    //time of genetate newitem
    private float createTime = 0.15f;

    void Start()
    {


    }

     void Update()
    {
        if (!isShaking)
        {
            for (int i = 0; i < ShakingIcons.Count; i++)
            {
                ShakingIcons[i].GetComponent<TweenScale>().enabled = false;
                ShakingIcons[i].transform.localScale = new Vector3(1f, 1f, 1f);
            }

        }
    }

    IEnumerator startCreate()
    {
     
        while (createTime > 0 )
        {
            createTime -= Time.deltaTime;
            newItem = Instantiate(Resources.Load<GameObject>("Prefabs/"+ NewItem.name.ToString().Trim()), gameObject.transform.position, Quaternion.identity) as GameObject;
            int randomIndex = Random.Range(0, froms.Count);
            newItem.GetComponent<TweenTransform>().from = froms[randomIndex];
            newItem.GetComponent<TweenTransform>().to = to;
            newItem.GetComponent<TweenTransform>().PlayForward();
            newItem.GetComponent<TweenTransform>().AddOnFinished(startRolling);

            if (newItem.GetComponent<AudioSource>())
            {
                newItem.GetComponent<AudioSource>().Play();
            }
           
            float interval = Random.Range(0.05f, 0.2f);
            
            yield return new WaitForSeconds(interval);//every 0.05 second create a new item
        }
        //stop shaking
        isShaking = false;       
        StopCoroutine(startCreate());
    }

    public void beginCreate()
    {
        StartCoroutine(startCreate());
    }

    private void startRolling()
    {
        NewItemNumber.GetComponent<RollingNumbers>().StartRolling();
        //rolling nubmer of reward icon
        LowerItemNumber.GetComponent<RollingNumbers>().StartRolling();
        //shaking animation of icon
        if (isShaking)
        {
            for (int i = 0; i < ShakingIcons.Count; i++)
            {
                print(ShakingIcons[i].name);
                ShakingIcons[i].GetComponent<TweenScale>().enabled = true;
            }       
        }

    }
}
