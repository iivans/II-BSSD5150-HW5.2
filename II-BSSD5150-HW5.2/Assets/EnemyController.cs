using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int health = 2;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code if needed
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Disable the projectile (set it inactive)
            collision.gameObject.SetActive(false);

            // Decrease health
            health--;

            if (health == 0)
            {
                // If health is zero, destroy the parent object
                FindObjectOfType<GameController>().UpdateScore();
                Destroy(transform.parent.gameObject);
            }
            else
            {
                // If not dead yet, lose shield 
                Destroy(GetComponentInChildren<SpriteMask>());
            }
        }
    }
}
