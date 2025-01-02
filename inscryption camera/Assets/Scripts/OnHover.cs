using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHover : MonoBehaviour
{
    void OnMouseOver()
    {
        Debug.Log($"Mousing over {this.name}");
    }
}
