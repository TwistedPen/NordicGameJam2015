using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    Quaternion originRotation;

    public float intensity;
    public float decay;

    float shake_decay;
    float shake_intensity;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartShake();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            StopShake();
        }

         if(shake_intensity > 0)
        {
            transform.rotation = new Quaternion(
                            originRotation.x + Random.Range(-shake_intensity, shake_intensity) * .2f,
                            originRotation.y + Random.Range(-shake_intensity, shake_intensity) * .2f,
                            originRotation.z + Random.Range(-shake_intensity, shake_intensity) * .2f,
                            originRotation.w + Random.Range(-shake_intensity, shake_intensity) * .2f);
        }
    }

    public void StartShake()
    {
        originRotation = transform.rotation;
        shake_intensity = intensity;
    }

    public void StopShake()
    {
        shake_intensity = 0;
        transform.rotation = originRotation;
    }

    public void GameOver()
    {
        StopShake();
    }

    public void Swap()
    {
        StopShake();
    }
}
