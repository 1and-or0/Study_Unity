using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Progress;
*/

public class Items : MonoBehaviour
{
    static string name;
    int rotateSpeed = 80;
    MeshRenderer meshRenderer;
    static AudioSource audio;

    public AudioClip clip;

    bool isActivate;

    void Awake()
    {
        name = gameObject.name;
        meshRenderer = GetComponent<MeshRenderer>();
        audio = GetComponent<AudioSource>();
        clip = audio.clip;
        isActivate = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (name == "Item2")
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 플레이어와 충돌하면 오브젝트(Item) 비활성화   
        if(other.name == "Player" && isActivate) 
        {
            other.GetComponent<PlayerBall>().nItems += 1;
            //Debug.Log(other.GetComponent<PlayerBall>().nItem);

            // 사운드
            /*
            audio.Play();

            meshRenderer.enabled = false;
            isActivate = false;
            */
            AudioSource.PlayClipAtPoint(clip, transform.position);

            //gameObject.SetActive(false);
        }
    }
}
