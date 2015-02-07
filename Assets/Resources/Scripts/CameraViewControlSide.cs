using UnityEngine;
using System.Collections;

/*
 * moves the camera to show either a isometric view of a 2D view
 */

public class CameraViewControlSide : MonoBehaviour {

    public Camera camera;
    public Vector3 endPos;
    public Vector3 cameraUp = new Vector3(0,1,0);
    private Vector3 startPos;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    private bool displayIsometric = false;
    private bool display2D = false;
    private Vector3 focalPoint;

	// Use this for initialization
	void Start () {
        startPos = camera.transform.position;
        journeyLength = Vector3.Distance(startPos, endPos);

        Plane plane = new Plane(-1*camera.transform.forward, new Vector3(0, 0, 0));
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        float distance;
        if(plane.Raycast(ray,out distance))
        {
            focalPoint = ray.GetPoint(distance);
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.G) && !displayIsometric)
        {
            startTime = Time.time;
            displayIsometric = true;
        }
        if (Input.GetKeyDown(KeyCode.H) && !display2D)
        {
            startTime = Time.time;
            display2D = true;
        }
        if (displayIsometric)
        {
            moveIsometric();
        }
        if (display2D)
        {
            move2D();
        }
	}

    // moves the camera to display a isometric view
    void moveIsometric()
    {
        if (camera.transform.position == endPos)
        {
            displayIsometric = false;
        }
        
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        camera.transform.position = Vector3.Lerp(startPos, endPos, fracJourney);
        camera.transform.LookAt(focalPoint, cameraUp);
        
    }
    // move the camera to display a 2D view
    void move2D()
    {
        if (camera.transform.position == startPos)
        {
            display2D = false;
        }
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        camera.transform.position = Vector3.Lerp(endPos, startPos, fracJourney);
        camera.transform.LookAt(focalPoint, cameraUp);
    }
}
