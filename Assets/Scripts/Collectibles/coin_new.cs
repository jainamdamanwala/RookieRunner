using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_new : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 17f;

    coin_Move coinMoveScript;
    // Start is called before the first frame update
    void Start()
    {
        coinMoveScript = gameObject.GetComponent<coin_Move>();
        coinMoveScript.enabled = false;
    }
    private void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CoinDetector")
        {
            coinMoveScript.enabled = true;
        }
    }
}
