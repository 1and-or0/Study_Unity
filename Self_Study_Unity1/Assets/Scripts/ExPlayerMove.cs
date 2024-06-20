using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("ray: " + ray);
            Debug.DrawRay(ray.origin, ray.direction, Color.blue, 2f);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, hit.point);
                Debug.Log("hit!: " + hit.rigidbody.gameObject.name);
                Debug.Log("hit: " + hit.transform.position);
            }
            else
            {
                Debug.Log("감지 불가") ;
            }
        }
    }
}
