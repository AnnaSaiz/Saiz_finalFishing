using UnityEngine;

public class Yoink : MonoBehaviour
{
    public GameObject fishingPole;
    public bool hasBeenClicked;
    public bool fishOn;

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

            if (fishOn == true)
            {
                transform.rotation = Quaternion.Euler(-30, 0, 0);
            }
            
            
            
        }
    }
}
