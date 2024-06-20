using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    public int totalItems;
    public int stage;

    public Text stageItemsText;
    public Text playerItemsText;

    public PlayerBall player;

    void Awake()
    {
        totalItems = 4;
        stage = 0;

        stageItemsText.text = "/" + totalItems + " ";
    }

    public void GetItemN(int numItems)
    {
        playerItemsText.text = " "+numItems.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
