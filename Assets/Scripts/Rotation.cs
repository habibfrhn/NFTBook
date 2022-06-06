using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float _speed=2;
    private bool rotate;
    private int count;

    void Awake()
    {
        count=0;
        rotate=true;
    }

    // Update is called once per frame    
    void Update() {
        
        if(rotate)
        {
        transform.Rotate(0,0,10 * _speed * Time.deltaTime);
        }
        else if(!rotate)
        {
        transform.rotation = Quaternion.identity;
        }
        
        if (Input.GetMouseButtonDown(0))   
        {              
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;  
        
            if (Physics.Raycast(ray, out hit)) 
                {    
                if (hit.transform != null) 
                {   
                    if(hit.transform.tag == "Right")
                    {
                        rotate=false;
                        count++;
                    }
                    if(hit.transform.tag == "Left")
                    {
                        rotate=false;
                        count--;
                        if(count<=0)
                        {
                        count=0;
                        }
                        
                        if(count==0)
                        {
                        rotate=true;
                        }
                    }
                    if(count== 28)
                        {
                        rotate=true;
                        count=0;
                        }
                }    
                }  
        }  
    }
}