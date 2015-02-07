using UnityEngine;
using System.Collections;

public class CameraReveal : MonoBehaviour {

    public Camera camera;
    public Vector3 endPos;
    public Vector3 up = new Vector3(0,1,0);
    private Vector3 startPos;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    private bool reveal = false;
    private Vector3 focalPoint;

	// Use this for initialization
	void Start () {
        startPos = camera.transform.position;
        journeyLength = Vector3.Distance(startPos, endPos);
        

        Plane plane = new Plane(new Vector3(1, 0, 0), new Vector3(0, 0, 0));
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        float distance;
        if(plane.Raycast(ray,out distance))
        {
            focalPoint = ray.GetPoint(distance);
        }


	}
	
	// Update is called once per frame
	void Update () {

        if (reveal)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            camera.transform.position = Vector3.Lerp(startPos,endPos,fracJourney);
            camera.transform.LookAt(focalPoint,up);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            startTime = Time.time;
            reveal = true;
        }

        if (camera.transform.position == endPos)
        {
            reveal = false;
        }
	}

    void Reveal()
    {
        reveal = true;
    }    
}
