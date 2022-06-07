using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPage : MonoBehaviour
{   
    public Animator animator;
    private int count;

    void Awake()
    {
        count=0;
    }

    // Update is called once per frame    
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {    
            Debug.Log("clicked");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;  
        
            if (Physics.Raycast(ray, out hit)) 
                {    
                if (hit.transform != null) 
                {   
                    if(hit.transform.tag == "Right")
                    {
                        animator.SetBool(count.ToString(), true);
                        count++;
                        Debug.Log("right " + count);
                    }
                    if(hit.transform.tag == "Left")
                    {
                        count--;
                        if(count<=0)
                        {
                        count=0;
                        }
                        Debug.Log("Left");
                        animator.SetBool(count.ToString(), false);
                    }
                    if(count== 28 || hit.transform.tag == "Middle" )
                        {
                        count=0;
                        for(int i=28; i>=-1;i--)
                        {
                        animator.SetBool(i.ToString(), false);
                        }
                        }

                }    
            }  
        }  
    }
}