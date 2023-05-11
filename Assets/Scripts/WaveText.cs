using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveText: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myTextElement;
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var w = go.GetComponent<WaveSpawn>();
        
        myTextElement.text = $"Wave: {w.currWave.ToString()}" + $"<br>Time Remaining: {Mathf.Round(w.waveTimer).ToString()}";
    }
}
