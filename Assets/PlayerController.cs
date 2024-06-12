using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Rigidbody m_Rigidbody;
    public float m_Speed = 10.0f;
    public int JumpFouce = 10;
    bool Whitemancantjump = true;
    public AudioClip impact;
    public AudioSource audioSource;
    public Text lettering;
    private int coinsAmounts=0;
    private ParticleSystem PS;
    public bool notDead = true;

    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 1;
        lettering.text = "0";
        PS = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Whitemancantjump && notDead)
            {
                m_Rigidbody.AddForce(new Vector3(0, JumpFouce, 0), ForceMode.Impulse);
                Whitemancantjump = false;
            }
            startOver();
        }
        if (notDead)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * m_Speed);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Rotate the sprite about the Y axis in the positive direction
                transform.Translate(Vector3.right * Time.deltaTime * m_Speed);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //Rotate the sprite about the Y axis in the negative direction
                transform.Translate(Vector3.left * Time.deltaTime * m_Speed);
            }
        }

    }

   

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "water")
        {
            Whitemancantjump = true;

        }
        if (collision.gameObject.tag == "bear" || collision.gameObject.tag == "beaver")
        {
            //Time.timeScale = 0;
            notDead = false;
            PS.Play();
        }
        /*if (collision.gameObject.tag == "coin")
        {
            coinsAmounts++;
            lettering.text = coinsAmounts.ToString();
            Destroy(collision.gameObject);
        }*/

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            Debug.Log("entered");
            coinsAmounts++;
            lettering.text = coinsAmounts.ToString();
            Destroy(other.gameObject);
        }
    }

    void startOver()
    {
        if (!notDead)
            SceneManager.LoadScene(0);
    }
}
