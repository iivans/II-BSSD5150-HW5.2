using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Transform projectileSpawnPoint;
    Rigidbody2D m_Rigidbody;
    bool walled = false;

    public float m_Speed = 5f;

    void Start()
    {
        // Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(Resources.Load("Projectile"), //make a new instance of this object
                projectileSpawnPoint.transform.position, //at this position
                Quaternion.identity); //with no rotation
        }
        else
        {
            //
        }
    }

    void FixedUpdate()
    {
        // Get horizontal input
        float h = Input.GetAxis("Horizontal");

        // Get vertical input
        float v = Input.GetAxis("Vertical");

        if(walled && h > 0)
        {
            h = 0;
        }

        // Create a Vector3 with the input values
        Vector3 m_Input = new Vector3(h, v, 0);

        // Move the Rigidbody's position based on input and speed
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.fixedDeltaTime * m_Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            walled = true;
        }

        if (collision.gameObject.CompareTag("Planet"))
        {
            SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        }
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            walled = false;
        }
    }

    //private void OnBecameInvisible()
    //{
        //SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
    //}
}
