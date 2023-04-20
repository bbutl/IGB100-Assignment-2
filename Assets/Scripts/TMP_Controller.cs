using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TMP_Controller : MonoBehaviour
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
        var h = go.GetComponent<Health>();
        myTextElement.text = $"Bonsai Health:{h.health.ToString()}";
       
    }
}
