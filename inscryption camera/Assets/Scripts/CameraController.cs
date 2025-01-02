using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    string currentState;
    public float transitionSpeed = 0.1f;

    [Header("Camera Positions")]
    public GameObject defaultPosition;
    public GameObject overheadPosition;
    public GameObject deckPosition;
    public GameObject handPosition;

    [Header("Events")]
    public GameEvent StateChanged;


    void Start()
    {
        this.transform.position = defaultPosition.transform.position;
        this.transform.rotation = defaultPosition.transform.rotation;
        currentState = "default";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                HandleState(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
            }
        }
    }

    void ChangePosition (GameObject destination)
    {
        transform.DOMove(destination.transform.position, transitionSpeed);
        transform.DORotate(destination.transform.rotation.eulerAngles, transitionSpeed);
    }

    void ChangeState (string newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
            switch (currentState)
            {
                case "default":
                    ChangePosition(defaultPosition);
                    break;
                case "overhead":
                    ChangePosition(overheadPosition);
                    break;
                case "hand":
                    ChangePosition(handPosition);
                    break;
                case "deck":
                    ChangePosition(deckPosition);
                    break;
            }
            StateChanged.Raise(newState);
        }
    }

    void HandleState(float inputVert, float inputHor)
{
    switch (currentState)
    {
        case "default":
            if (inputVert > 0)
            {
                ChangeState("overhead");
            }
            else if (inputHor > 0)
            {
                ChangeState("deck");
            }
            else if (inputVert < 0)
            {
                ChangeState("hand");
            }
            break;

        case "overhead":
            if (inputVert < 0)
            {
                ChangeState("default");
            }
            else if (inputHor > 0)
            {
                ChangeState("deck");
            }
            break;

        case "deck":
            if (inputHor < 0)
            {
                ChangeState("default");
            }
            if (inputVert < 0)
            {
                ChangeState("default");
            }
            if (inputVert > 0)
            {
                ChangeState("overhead");
            }
            break;

        case "hand":
            if (inputVert > 0)
            {
                ChangeState("default");
            }
            break;
    }
}
}
