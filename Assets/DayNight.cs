using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public GameObject light;
    private Vector3 rotasion;
    // Start is called before the first frame update
    void Start()
    {
        
        //rotasion = light.transform.rotation.eulerAngles;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*rotasion.x += Time.deltaTime;
        light.transform.rotation = rotasion;/*/
    }
}
