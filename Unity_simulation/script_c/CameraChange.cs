using System.Collections;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject FirstCam;
    public GameObject ThirdCam;
    public int CamMode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if (CamMode == 1)
            {
                CamMode = 0;
            }
            else
            {
                CamMode += 1;
            }
            StartCoroutine(CamChange());
        }
    }
    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0)
        {
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);
        }
         if (CamMode == 1)
        {
            ThirdCam.SetActive(false);
            FirstCam.SetActive(true);
        }
    }
}


