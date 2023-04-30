using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenes : MonoBehaviour
{
    public GameObject bonsai;

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
        }
        
    }
    public void MoveToScene(string input)
    {
        SceneManager.LoadScene($"{input}");
    }
}
