using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBook : MonoBehaviour
{
    public Camera camera;
    
    public Animator animator;
    private int count;

    private Vector3 endPosition = new Vector3(0.98f, 2.15f, -0.03f);
    private Vector3 originalPosition = new Vector3( 0f, 2.15f, -0.03f);
    private Vector3 startPosition;
    private float desiredDuration = 1.5f;
    private float elapsedTime;
    private float percentageComplete;
    private bool lerping;
    private bool reset;
    private bool temp;

    [SerializeField] private AnimationCurve curve;

    void Awake()
    {
        count=0;
        percentageComplete=0;
        lerping=false;
        reset=false;
        temp=false;
    }

    void Start()
    {
        camera = Camera.main;
        startPosition = Camera.main.transform.position; 
    }

    // Update is called once per frame    
    void Update() {

        if(reset)
        {
            resetLerp();
            startPosition = Camera.main.transform.position;
        }
        
        if(lerping)
        {
            shouldLerp();
            temp=true;
        }
        else if(!lerping && temp)
        {
            shouldNotLerp();
        }
        
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
                        lerping = true;
                        reset = true;
                        count++;
                    }
                    if(hit.transform.tag == "Left")
                    {
                        count--;
                        if(count<=0)
                        {
                        count=0;
                        }
                        
                        if(count==0)
                        {
                        lerping = false;
                        reset = true;
                        }
                    }
                    if(count== 28)
                        {
                        count=0;
                        lerping = false;
                        reset = true;
                        }
                }    
                }  
        }  
    }

    public void shouldLerp()
    {
        elapsedTime += Time.deltaTime;
        percentageComplete = elapsedTime / desiredDuration;
        camera.transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));
    }

    public void shouldNotLerp()
    { 
        elapsedTime += Time.deltaTime;
        percentageComplete = elapsedTime / desiredDuration;
        camera.transform.position = Vector3.Lerp(startPosition, originalPosition, curve.Evaluate(percentageComplete));
    }

    public void resetLerp()
    {
        elapsedTime=0;
        percentageComplete=0;
        reset=false;
    }
}
