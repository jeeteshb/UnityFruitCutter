using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{
    [SerializeField] GameObject splashReference;
    
    Rigidbody2D rb;
    float startForce = 12f;
    float rotationSpeed = 20f;
    float xRot, yRot, zRot;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    void OnEnable()
    {
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);

        xRot = Random.Range(-5f, 6f) * Time.deltaTime * rotationSpeed;
        //yRot = Random.Range(-2f, 10f) * Time.deltaTime * rotationSpeed;
        //zRot = Random.Range(-1f, 3f) * Time.deltaTime * rotationSpeed;
    }

    private void Update()
    {
        transform.Rotate(xRot, 0, 0);
        if(transform.position.y < -10)
        {
            DestroyFruit();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            Camera.main.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
            //Destroy(gameObject);

            Instantiate(splashReference, transform.position, Quaternion.identity); //transform.rotation

            /* Update Score */
            GameManager.Instance.UpdateScore();
        }
    }
    void DestroyFruit()
    {
        gameObject.SetActive(false);
    }

}