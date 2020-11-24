using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    public GameObject coin;
    public Vector3 rotation;

    //private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        transform.Rotate(rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //player.coinCounter++;
            Destroy(coin);
            FindObjectOfType<AudioManager>().PlaySound("Coin");
        }
    }
}
