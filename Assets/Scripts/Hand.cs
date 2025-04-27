using UnityEngine;

public class Hand : MonoBehaviour
{
    Camera cam;
    Collider groundCollider;
    RaycastHit hit;
    Ray ray;
    Rigidbody rb;

    Vector3 minRange;
    Vector3 maxRange;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        groundCollider = GameObject.Find("ground").GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();

        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    // Update is called once per frame
    void Update()
    { 
        ray = cam.ScreenPointToRay(Input.mousePosition);
        Vector3 targetPosition = transform.position;


        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider == groundCollider)
            {
                targetPosition = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * 20);

                if(targetPosition.y < 0.5f)
                {
                    targetPosition.y = 0.5f;
                }
            }
        }
        else
        {
            Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2));
            targetPosition = Vector3.MoveTowards(transform.position, mouseWorldPosition, Time.deltaTime * 20);
        }
          rb.MovePosition(targetPosition);
    }
}
