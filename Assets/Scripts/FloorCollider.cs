using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Lasagna" || other.tag == "Bomb") {
            GameObject obj = other.gameObject;
            obj.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            obj.transform.position = new Vector3(Random.Range(-7.0f, 7.0f), 8.0f, 5);
        }
    }
}
