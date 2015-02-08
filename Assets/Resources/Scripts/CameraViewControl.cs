using UnityEngine;
using System.Collections;

/*
 * moves the camera to show either a isometric view of a 2D view
 */

enum CameraPositions
{
    originalPos,
    gameOverPosition,
    swappedPosition

};

public class CameraViewControl : MonoBehaviour {

    private CameraPositions currentPos = CameraPositions.originalPos;
    public Camera camera;
    public Camera swapCamera;
    public Vector3 endPos;
    public Vector3 cameraUpStart = new Vector3(0,1,0);
    public Vector3 cameraUpEnd = new Vector3(-1, -1, -1);
    private Vector3 startPos;
    private Vector3 swapCameraUp;
    private Vector3 swapCameraPos;
    private Vector3 tempUp;
    private Vector3 tempPos;
    private Vector3 swapFocalPoint;
    public Vector3 currentFocalPoint;
    public float gameOverspeed = 1.0f;
    public float swapSpeed = 1.0f;
    private float speed = 1.0f;
    private float startTime;
    
    private bool isMoving = false;
    private Vector3 focalPoint;

    void Awake()
    {
        Plane plane = new Plane(-1 * camera.transform.forward, new Vector3(0, 0, 0));
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            focalPoint = ray.GetPoint(distance);
            currentFocalPoint = focalPoint;
        }
    }

	// Use this for initialization
	void Start () {
        startPos = camera.transform.position;
        swapCameraUp = swapCamera.transform.up;
        swapCameraPos = swapCamera.transform.position;
        swapFocalPoint = swapCamera.GetComponent<CameraViewControl>().focalPoint;
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.G))
        {
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            ReturnToOrigin();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Swap();
        }

        if(isMoving)
            switch (currentPos)
            {
                case CameraPositions.originalPos:
                    speed = gameOverspeed;
                    moveTo(startTime, tempPos, startPos, tempUp, cameraUpStart);
                    break;
                case CameraPositions.gameOverPosition:
                    speed = gameOverspeed;
                    moveTo(startTime, startPos, endPos, cameraUpStart, cameraUpEnd);
                    break;
                case CameraPositions.swappedPosition:
                    speed = swapSpeed;
                    if(currentPos == CameraPositions.originalPos)
                        moveTo(startTime, swapCameraPos, startPos, swapCameraUp, cameraUpStart);
                    else if (currentPos == CameraPositions.swappedPosition)
                        moveTo(startTime, startPos, swapCameraPos, cameraUpStart, -swapCameraUp);
                    break;
            }
	}

    // moves the camera with lerp by using a start time for when the call is started 
    // along with a start and end position and a start and end up vector for the camera
    void moveTo(float startTime, Vector3 startPosition, Vector3 endPosition, Vector3 cameraUpStart, Vector3 cameraUpEnd)
    {
        if (camera.transform.position == endPosition)
        {
            isMoving = false;
            return;
        }
        
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / Vector3.Distance(startPosition, endPosition);
        float qfracJourney = (Time.time - startTime) * speed / Vector3.Distance(cameraUpStart, cameraUpEnd);
        camera.transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);
        Vector3 newUp = Vector3.Lerp(cameraUpStart, cameraUpEnd, qfracJourney);
        camera.transform.LookAt(currentFocalPoint, newUp);
    }

    public void Swap()
    {
        if (!isMoving && currentPos != CameraPositions.gameOverPosition)
        {
            startTime = Time.time;
            if (currentPos == CameraPositions.originalPos)
            {
                currentFocalPoint = swapFocalPoint;
                currentPos = CameraPositions.swappedPosition;
            }
            else if (currentPos == CameraPositions.swappedPosition)
            {
                currentFocalPoint = focalPoint;
                currentPos = CameraPositions.originalPos;
            }
            isMoving = true;
        }
    }

    public void ReturnToOrigin()
    {
        if (!isMoving && currentPos != CameraPositions.originalPos)
        {
            currentFocalPoint = focalPoint;
            tempPos = camera.transform.position;
            tempUp = camera.transform.up;
            startTime = Time.time;
            currentPos = CameraPositions.originalPos;
            isMoving = true;
        }
    }

    public void GameOver()
    {
        if (!isMoving && currentPos != CameraPositions.gameOverPosition)
        {
            currentFocalPoint = focalPoint;
            startTime = Time.time;
            currentPos = CameraPositions.gameOverPosition;
            isMoving = true;
        }
    }
}
