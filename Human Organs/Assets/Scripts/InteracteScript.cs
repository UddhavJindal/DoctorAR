using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracteScript : MonoBehaviour
{
    [SerializeField] Vector3 rotateAxis;
    [SerializeField] float speed;
    private Vector3 sideways;
    void Start()
    {
        sideways = new Vector3(0, 1, 0);
    }

    public void RotateLeft()
    {
        transform.Rotate(sideways * 45);
    }
    public void RotateRight()
    {
        transform.Rotate(-sideways * 45);
    }
    /*public void ScaleInc()
    {
        transform.localScale += new Vector3(1, 1, 1);
    }
    public void ScaleDec()
    {
        if (this.gameObject.transform.localScale.y > 1f)
        {
            transform.localScale -= new Vector3(1, 1, 1);
        }
    }*/
}
