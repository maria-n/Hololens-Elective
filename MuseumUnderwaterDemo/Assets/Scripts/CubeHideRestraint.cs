using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHideRestraint : MonoBehaviour {

    public Vector3 startlocation;
    public Vector3 startScale;

    private float xDisplacementEnd = 1.65f;

	void Start () {
        startlocation = Vector3.zero;
        startScale = transform.localScale;
      //  transform.position = new Vector3(startlocation.x + xDisplacementEnd / 2, startlocation.y, startlocation.z);
        transform.localPosition = new Vector3(xDisplacementEnd / 2, 0, 0);
    }

    void LateUpdate () {

        //let us be able to adjust the X position but not the others
        transform.localPosition = new Vector3(transform.localPosition.x, 0, 0);
        if(transform.localPosition.x < 0f)
        {
            transform.localPosition = startlocation;
        }
        else if(transform.localPosition.x > xDisplacementEnd)
        {
            transform.localPosition = new Vector3(xDisplacementEnd, transform.localPosition.y, transform.localPosition.z);
        }
        /*float xScale = Mathf.Lerp(3, 0, transform.position.x / 1.65f);
        transform.localScale = new Vector3(xScale, startScale.y, startScale.z);*/
    }
}
