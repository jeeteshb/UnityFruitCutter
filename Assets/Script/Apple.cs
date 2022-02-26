using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{
    [SerializeField] GameObject splashReference;
    
    Rigidbody2D rb;
    float startForce = 12f;
    float rotationSpeed = 20f;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
        float xRot = Random.Range(-5f, 6f) * Time.deltaTime * rotationSpeed;
        float yRot = Random.Range(-2f, 10f) * Time.deltaTime * rotationSpeed;
        float zRot = Random.Range(-1f, 3f) * Time.deltaTime * rotationSpeed;

        transform.Rotate(xRot, yRot, zRot);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            Camera.main.GetComponent<AudioSource>().Play();
			Destroy(gameObject);

            Instantiate(splashReference, transform.position, Quaternion.identity); //transform.rotation

            /* Update Score */
            GameManager.Instance.UpdateScore();
        }
    }
}