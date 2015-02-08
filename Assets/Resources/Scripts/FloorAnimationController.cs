using UnityEngine;
using System.Collections;

public class FloorAnimationController : MonoBehaviour {

    public float floorSpeed = 1.0f;

	// Use this for initialization
	void Start () {
        ChangeAnimationSpeed(floorSpeed);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void StartAnimation()
    {
        ChangeAnimationSpeed(floorSpeed);
    }


    public void StopAnimation()
    {
        ChangeAnimationSpeed(0);
    }

    public void SetFloorSpeed(float newSpeed)
    {
        floorSpeed = newSpeed;
    }

    void ChangeAnimationSpeed(float newSpeed)
    {   
        Animator[] animations = this.gameObject.GetComponentsInChildren<Animator>();
        foreach(Animator anim in animations)
        {
            anim.speed = newSpeed;
        }
        TandhjulRoter[] hjul = this.gameObject.GetComponentsInChildren<TandhjulRoter>();
        foreach (TandhjulRoter h in hjul)
        {
             h.SetRetning(newSpeed);
        }
    }
        
}
