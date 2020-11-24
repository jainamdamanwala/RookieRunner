using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    //public GameObject coinDetectorObj;
    public Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        //coinDetectorObj = GameObject.FindGameObjectWithTag("CoinDetector");
        //coinDetectorObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //StartCoroutine(ActiveCoin());
            Destroy(gameObject);
        }
    }

/*    IEnumerator ActiveCoin()
    {
        coinDetectorObj.SetActive(true);
        yield return new WaitForSeconds(1f);
        coinDetectorObj.SetActive(false);
    }*/
}
