using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnBecameVisible() // instantiated and added to scene
    {
        rb2d.velocity = Vector2.right * speed;
    }

    private void OnBecameInvisible() // offscreen
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
