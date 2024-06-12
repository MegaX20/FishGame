using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    GameObject[] ArButton;
    private bool view=false;
    public List<Button> saveButton;
    // Start is called before the first frame update
    void Start()
    {
         ArButton = GameObject.FindGameObjectsWithTag("pauseButton");
        foreach (GameObject i in ArButton)
        {
            
            
            i.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            Debug.Log("escape");
            setMenu();
        }
    }

    public void setMenu()
    {
        if (!view)
        {
            Time.timeScale = 0;
            view = !view;
            foreach(GameObject i in ArButton)
            {
                i.SetActive(true);
            }
        }
        else
        {
            Time.timeScale = 1;
            view = !view;
            foreach (GameObject i in ArButton)
            {
                i.SetActive(false);
            }
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Resstart()
    {
        SceneManager.LoadScene(0);
    }
    
}
