using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class diffB : MonoBehaviour
{
    public Button b;
    private GManager gManager;
    public int diff;

    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.Find("GManager").GetComponent<GManager>();

        b = GetComponent<Button>();
        b.onClick.AddListener(sDiff);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void sDiff()
    {
        gManager.StartGame(diff);
        Debug.Log(gameObject.name + "was clicked");
    }
}
