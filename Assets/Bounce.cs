using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {

    void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.name == "Floor") 
        {
            Vector3 tempScale = gameObject.transform.localScale;
            tempScale.y = 0.5f;
            gameObject.transform.localScale = tempScale;


            
        }

        else
        {
            Vector3 tempScale = gameObject.transform.localScale;
            tempScale.x = 0.5f;
            gameObject.transform.localScale = tempScale;

        } 

    
    }
}
