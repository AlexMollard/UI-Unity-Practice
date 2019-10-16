using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public Camera MainCamera;
    public ButtonManager[] ButtonSet;

    public bool PlayerSelect = false;
    public Vector3 DefaultPosition;
    public Vector3 PlayerSelectPosition;
    public float CameraSpeed = 1.0f;
    private float StartTime = 0.0f;
    private float PlayerSelectionJourneyLength = 0.0f;
    bool FirstFrameTime = false;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        DefaultPosition = MainCamera.transform.position;
        PlayerSelectPosition = new Vector3(DefaultPosition.x, DefaultPosition.y, DefaultPosition.z + 100);

        PlayerSelectionJourneyLength = Vector3.Distance(DefaultPosition, PlayerSelectPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonSet[0].PlayerSelection)
        {
            PlayerSelect = true;
        }
        else
        {
            PlayerSelect = false;
        }

        if (PlayerSelect)
        {
            if (!FirstFrameTime)
            {
                StartTime = Time.time;
            }
            FirstFrameTime = true;
            float distCovered = (Time.time - StartTime) * CameraSpeed;
            float fractionOfJourney = distCovered / PlayerSelectionJourneyLength;

            MainCamera.transform.position = Vector3.Lerp(DefaultPosition, PlayerSelectPosition, fractionOfJourney);

            
        }
        else
        {
            if (FirstFrameTime)
            {
                StartTime = Time.time;
            }
            FirstFrameTime = false;
            float distCovered = (Time.time - StartTime) * CameraSpeed;
            float fractionOfJourney = distCovered / PlayerSelectionJourneyLength;

            MainCamera.transform.position = Vector3.Lerp(PlayerSelectPosition, DefaultPosition, fractionOfJourney);
        }
    }
}
