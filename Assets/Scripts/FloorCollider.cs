using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour
{
    private GameObject lasagna;
    private GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        lasagna = GameObject.FindWithTag("Lasagna");
        bomb = GameObject.FindWithTag("Bomb");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FallObject() {
        GameObject obj = Random.Range(0f, 100f) > 20f ? lasagna : bomb;
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        obj.transform.position = new Vector3(Random.Range(-9.5f, 9.5f), 6.5f, 1);
        rb.velocity = new Vector3(0, 0, 0);
        rb.simulated = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Lasagna" || other.tag == "Bomb") {
            GameObject obj = other.gameObject;
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(0, 0, 0);
            if (other.tag == "Lasagna")
                obj.transform.position = new Vector3(-16f, 0, 1);
            else
                obj.transform.position = new Vector3(-12f, 0, 1);
            rb.simulated = false;

            FallObject();
        }
    }
}
