using UnityEngine;

public class Yoink : MonoBehaviour
{
    public GameObject fishingPole;
    public bool hasBeenClicked;
    public bool fishOn;
    public Camera see;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fishOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasBeenClicked = true;
            Debug.Log("has been yoinked");

            if(hasBeenClicked == true)
            {
               
                
                
            }
            
            
            
            
            
        }
    }
}
