using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickMove : MonoBehaviour
{
    public Camera camera1; // 카메라(메인)
    public float maxMoveSpeed; // 최대 속도
    public float accelerate; // 가속도

    private float currentSpeed; // 현재 속도
    private Vector3 diration;  // 방향
    private bool isMove;

    void Awake()
    {
        isMove = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)) 
        {
            //isMove = true;
            Ray ray = camera1.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity) /*&& isMove*/) 
            {
                //Debug.DrawRay(ray.origin, hit.point, Color.yellow, 5);
                Vector3 targetPos = new Vector3(hit.point.x - transform.position.x,
                    0, hit.point.y - transform.position.y);
                currentSpeed = Mathf.Clamp(currentSpeed += accelerate*Time.deltaTime, 0, maxMoveSpeed);
                // diration = hit.normal;
                diration = targetPos.normalized; // 방향설정, 단위벡터화
                Debug.Log("targetPos: "+targetPos);
                Debug.Log("hit.point: "+hit.point);
                Debug.Log("hit.point.x - transform.position.x: " + (hit.point.x - transform.position.x));
                Debug.Log("hit.point.y - transform.position.y: " + (hit.point.y - transform.position.y));
                Debug.Log("hit.transform.position: "+hit.transform.position);
                Debug.Log("ray.origin: "+ray.origin);
                Debug.Log("ray.direction: " + ray.direction);
                Debug.Log("diration: " + diration);
            }
        }
        else
        {
            //isMove = false;
            currentSpeed = 0; // 정지
            // 감속
            // currentSpeed = Mathf.Clamp(currentSpeed -= accelerate*Time.deltaTime, 0, maxMoveSpeed);
        }

        // 이동
        transform.Translate(diration*currentSpeed*Time.deltaTime, Space.World);
    }
}
