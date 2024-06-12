using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    // Update is called once per frame
    public float fallZone = -10f; 
    void Update()
    {
        if (player.transform.position.y < fallZone) //Assuming its a 2D game
        {
            SceneManager.LoadScene(0);
            //player.transform.position = playerSpawnPoint.position;
        }
    }
}
