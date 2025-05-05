using System.Collections.Generic;
using UnityEngine;
public enum Level
{
    One,
    Two,
    Three,
    Four

}
public class SpawnInFish : MonoBehaviour
{ 
    
    public GameObject smallFry;
    public GameObject plainOlFish;
    public GameObject nibbler;
    public GameObject touchyFish;

    public GameObject kingOfPond;
    public GameObject mysteryFish;

    Vector3 randomRange;
    public int randomNumberMin = 1;
    public int randomNumberMax = 3;

    public Vector3 minEdge;
    public Vector3 maxEdge;

    public int fishSpeed = 10;
    public bool isMoving;



    private List<fishCounting> fishlist = new List<fishCounting>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnFishIn(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            foreach (var fishy in fishlist)
            {
                fishy.Move(fishSpeed);
            }
        }
    }

    public void SpawnFishIn()
    {
        //need a variable for random amount, random range and random size
        int fishCount = Random.Range(randomNumberMin, randomNumberMax);
        for (int i = 0; i < fishCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(minEdge.x, maxEdge.x),
                Random.Range(minEdge.y, maxEdge.y),
                Random.Range(minEdge.z, maxEdge.z)
            );

            GameObject go = Instantiate(smallFry,randomPosition, Quaternion.identity);

            Vector3 randomDirection = new Vector3(
               Random.Range(-1f, 1f),
               Random.Range(-1f, 1f),
               Random.Range(-1f, 1f)
           ).normalized;

            fishlist.Add(new fishCounting(go, randomDirection));
        }

   
    }
    public class fishCounting
    {
        public GameObject objectMove;
        public Vector3 direction;

        public fishCounting(GameObject targetObject, Vector3 dir)
        {
            objectMove = targetObject;
            direction = dir;
        }
        public void Move(float speed)
        {
            objectMove.transform.Translate(direction * speed * Time.deltaTime);
        }
    }
    
    
    
}
