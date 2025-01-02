using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class HandCards : MonoBehaviour
{
    [Header("Parameters")]
    public float RotationStep = 3f;
    public float DefaultRotation = 90f;
    public float SpacingStepX = 0.04f;
    public float SpacingStepZ = 0.001f;
    public float DefaultPosition = 0;
    public float Speed = 0.1f;

    [Header("Hand Positions")]
    public GameObject HandPositionRaised;
    public GameObject HandPositionDefault;
    public GameObject HandPositionLowered;
    

    public float transitionSpeed = 0.2f;

    public List<GameObject> Cards = new List<GameObject>();

    void Start()
    {
        RecalculateCardRotation();
        RecalculateCardSpacing();
    }

    public void onStateChangeRaised(object data)
    {
        if (data is string)
        {
            string state = (string)data;
            switch (state)
            {
                case "default":
                    transform.DOMove(HandPositionDefault.transform.position, transitionSpeed);
                    break;
                case "hand":
                    transform.DOMove(HandPositionRaised.transform.position, transitionSpeed);
                    break;
                case "deck":
                case "overhead":
                    transform.DOMove(HandPositionLowered.transform.position, transitionSpeed);
                    break;
            }
        }
    }

    public void ApplyCardRotation(float rotation)
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            Cards[i].transform.DORotate(new Vector3(rotation + i * RotationStep, 90, -90), Speed);           
        }
    }

    public void ApplyCardSpacing(float position)
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            Cards[i].transform.DOMoveX(position + i * SpacingStepX, Speed);  
        }
    }

    public void RecalculateCardRotation()
    {
        if (Cards.Count % 2 == 0)
        {
            float firstRotation = DefaultRotation - ((Cards.Count / 2) - 1) * RotationStep - RotationStep / 2;
            ApplyCardRotation(firstRotation);
        }
        else
        {
            float firstRotation = DefaultRotation - (float)(Math.Floor(Cards.Count / 2f) * RotationStep);
            ApplyCardRotation(firstRotation);
        }
    }

    public void RecalculateCardSpacing()
    {
        if (Cards.Count % 2 == 0)
        {
            float firstPosition = DefaultPosition - ((Cards.Count / 2) - 1) * SpacingStepX - SpacingStepX / 2;
            ApplyCardSpacing(firstPosition);
        }
        else
        {
            float firstPosition = DefaultPosition - (float)(Math.Floor(Cards.Count / 2f) * SpacingStepX);
            ApplyCardSpacing(firstPosition);
        }
    }
}
