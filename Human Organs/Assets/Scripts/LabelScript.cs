using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
public class LabelScript : MonoBehaviour
{
    public Text label;
    void Update()
    {
        Vector3 newPos = Camera.main.WorldToScreenPoint(this.transform.position);
        label.transform.position = newPos;
    }
}
