using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NextLevel : MonoBehaviour
{
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    private void OnTriggerEnter(Collider collider) 
    {
        if(collider.tag == "Player")
        {
            Application.LoadLevel(level);
        }
    }
}
