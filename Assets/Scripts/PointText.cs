using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointText : MonoBehaviour
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
        var p = go.GetComponent<PointManager>();
        myTextElement.text = $"{p.points.ToString()}";
    }
}
