using System.Collections.Generic;
using UnityEngine;
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
        if (isMoving)
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
                0f,
                Random.Range(minEdge.z, maxEdge.z)
            );

            GameObject selectedFish = GetRandomFish();

            GameObject go = Instantiate(selectedFish, randomPosition, Quaternion.Euler(90, Random.Range(0f, 360f), 0));

            Rigidbody rb = go.GetComponent<Rigidbody>();
            if (rb != null )
            {
                rb.constraints = RigidbodyConstraints.FreezePositionY |
                    RigidbodyConstraints.FreezeRotationX |
                    RigidbodyConstraints.FreezeRotationZ;
            }

            Vector3 randomDirection = new Vector3(
               Random.Range(-1f, 1f),
               0f,
               Random.Range(-1f, 1f)
           ).normalized;

            fishlist.Add(new fishCounting(go, randomDirection));
        }


    }
    GameObject GetRandomFish()
    {
        int smallChance = Random.Range(0, 100);

        if(smallChance < 5)
        {
            return kingOfPond;
        }
        else if (smallChance >= 5 && smallChance < 10)
        {
            return mysteryFish;
        }


        int fishIndex = Random.Range(0, 4);
        if (fishIndex == 0)
        {
            return smallFry;
        }
        else if (fishIndex == 1)
        {
            return plainOlFish;
        }
        else if (fishIndex == 2)
        {
            return nibbler;
        }
        else if(fishIndex == 3)
        {
            return touchyFish;
        }
        return smallFry;
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
            Rigidbody rb = objectMove.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 movement = new Vector3(direction.x, 0f, direction.z) * speed * Time.deltaTime;
                rb.MovePosition(objectMove.transform.position + movement);
            }
        
        }
    }



}
