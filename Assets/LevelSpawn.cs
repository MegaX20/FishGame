using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] eaters;
    public GameObject[] background; //Trees, outher animals and background elements
    public GameObject Ground; //Here will have the ground in the sides of the revier
    public GameObject Water; //Here will put the item of the water
    public GameObject coin;
    public float defTimetoSpawn = 2.7f;
    public float MapSpawn = 5;

    // Update is called once per frame
    private float timetospawn;
    private Vector3 pos;

    private void Start()
    {
        pos = transform.position;
        water_relocation();
    }
    void Update()
    {

        if (timetospawn <= 0)
        {
            int rand = Random.Range(0, eaters.Length); //Creates a random number that at this time is used to decide what eater will be spawn
            // Making coin's random cordination
            float coin_x = Random.Range(-44.5f, 42.5f); 
            float coin_y = Random.Range(0.7f, 6.5f);
            float coin_z = Random.Range(-12.5f, 11.5f);
            // end
            Instantiate(eaters[rand], transform.position, Quaternion.identity); //Creates a new object at a spasfied position
            Instantiate(coin, new Vector3(coin_x, coin_y, coin_z), Quaternion.identity); // Create coin in random location
            timetospawn = defTimetoSpawn; //Restart timer to time for next respawn
        }
        else
            timetospawn -= Time.deltaTime;
    }

    void water_relocation()
    {
        Vector3 temp = pos;
        temp.y -= 3.5f;
        Instantiate(Water, temp, Quaternion.identity);
    }
}
