using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject wall;
    private int score = 0;
    private int target = 3; // Number of enemies you have to make

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code if needed
    }

    public void UpdateScore()
    {
        score++;

        if (score >= target)
        {
            // You reached the target score
            Debug.Log("You Win");
            Destroy(wall);
        }
    }
}

