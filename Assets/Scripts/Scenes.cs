using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenes : MonoBehaviour
{
    public GameObject bonsai;
    public GameObject waveSpawn;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Health bHealth = bonsai.GetComponent<Health>();
        if (bHealth.health <= 0)
        {
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            bHealth.health = 1000;
        }
        
    }
    public void MoveToScene(string input)
    {
       Health bHealth = bonsai.GetComponent<Health>();
        bHealth.health = 1000;
        
        SceneManager.LoadScene($"{input}");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    
}
