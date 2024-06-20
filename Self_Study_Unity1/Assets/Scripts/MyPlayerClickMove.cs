using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MyPlayerClickMove : MonoBehaviour
{
    public Camera camera1;
    private Vector3 destination;
    public bool isMoving = false;
    public float moveSpeed;
    
    private Animator anim;
    private NavMeshAgent navMeshAgent;

    public Vector3 clickSpot ;
    //Vector3 diraction;
    //Vector3 distance;
    //private bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePoint(Input.GetMouseButtonDown(1));

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.point);
                destination = hit.point;
                isMoving = true;
                
                //MoveTo(hit.point);
            }
        }
        ClickMove();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                navMeshAgent.SetDestination(hit.point);
                if(!navMeshAgent.isStopped)
                { 
                    isMoving = true;
                }
            }
        }

        if(navMeshAgent.isStopped && isMoving) 
        {
            isMoving = false;
        }
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", Vector3.Distance(transform.position, clickSpot));
        Debug.Log(anim.GetFloat("Speed"));

        anim.SetBool("isMoving", isMoving);
        Debug.Log(anim.GetBool("isMoving"));
        //if (isMoving)
        //{
        //    anim.SetBool("isMoving", true);
        //    //anim.Play("Villager@Pickaxe-Mining01");
        //}
        //else  
        //{
        //    anim.SetBool("isMoving", false);
        //    //anim.Play("Villager@Idle01");
        //}
    }


    void GetMousePoint(bool clickDown) 
    {
        if(clickDown) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                clickSpot = hit.point;
            }
        }
    }
    void ClickMove()
    {
        if (isMoving)
        {
            float distance = Vector3.Distance(transform.position, destination);

            if (distance > 0.517f) // 목적지에 아직 도착하지 않은 경우
            {
                Vector3 direction = (destination - transform.position).normalized;
                direction.y = 0f;
                transform.Translate(direction * Time.deltaTime * moveSpeed); // 이동속도 조절
            }
            else // 목적지에 도착한 경우
            {
                isMoving = false;
                Debug.Log("이동 끝");
            }
        }
    }

    /*void MoveTo(Vector3 position)
    {
        Vector3 direction = position - transform.position;
        direction.y = 0;
        direction.Normalize();
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    public void ClickMove()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.collider.gameObject.tag == "Floor")
        {
            Debug.Log("hit.point: " + hit.point);
            // destination = (hit.point);
            // transform.Translate(destination);
            isMove = true;
            distance = (hit.point - transform.position);
            diraction = distance.normalized;
            if (distance.x < 0.1f && distance.y < 0.1f && distance.z < 0.1f && isMove)
            {
                Debug.Log("moving");
                transform.Translate(diraction * moveSpeed * Time.deltaTime);
            }

            Debug.Log("end");
            isMove = false;
            transform.position = hit.point;
        }
    }
    */
}
