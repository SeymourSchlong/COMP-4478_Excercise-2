using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Garfield : MonoBehaviour
{
    [SerializeField]
    public float acceleration = 2;
    public float maxSpeed = 5;
    private float speed = 0;

    private GameObject lasagna;
    private GameObject bomb;
    ///private GameObject score;
    private Text score;

    private int scoreVal = 0;

    // Start is called before the first frame update
    void Start()
    {
        lasagna = GameObject.FindWithTag("Lasagna");
        bomb = GameObject.FindWithTag("Bomb");
        score = GameObject.Find("Text").GetComponent<Text>();
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

    private void FallObject() {
        GameObject obj = Random.Range(0f, 100f) > 20f ? lasagna : bomb;
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        obj.transform.position = new Vector3(Random.Range(-9.5f, 9.5f), 6.5f, 1);
        rb.velocity = new Vector3(0, 0, 0);
        rb.simulated = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Lasagna") {
            GameObject obj = other.gameObject;
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            obj.transform.position = new Vector3(-16f, 0, 1);
            rb.simulated = false;
            // increment score
            FallObject();
            score.text = "Score: " + ++scoreVal;
        } else if (other.tag == "Bomb") {
            // handle bomb
            SceneManager.LoadScene("GameOver");
        }
    }
}
