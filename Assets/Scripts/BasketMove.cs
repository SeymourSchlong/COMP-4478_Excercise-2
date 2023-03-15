using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMove : MonoBehaviour
{
    [SerializeField]
    public float acceleration = 2;
    public float maxSpeed = 5;
    public float speed = 0;
    public float maxX = 10;
    public float minX = -10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rawHorizAxis = Input.GetAxisRaw("Horizontal");

        Vector3 dir = Vector3.zero;
        dir.x = rawHorizAxis;

        if (dir.x == 0) {
            speed -= acceleration*2;
            if (speed < 0) speed = 0;
        } else {
            speed += acceleration;
            if (speed > maxSpeed) speed = maxSpeed;
        }

        transform.Translate(dir * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Lasagna") {
            GameObject obj = other.gameObject;
            obj.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            obj.transform.position = new Vector3(Random.Range(-7.0f, 7.0f), 8.0f, 5);
        } else if (other.tag == "Bomb") {
            // handle bomb
        }
    }
}
