using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixMovement : MonoBehaviour
{
    public MatrixMult mm;
    public GameObject objec;

    void Start()
    {
        
        StartCoroutine(mov());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        objec.transform.position = mm.Mult(objec.transform.position, new Vector3(0.08f,0,0.02f));
    }

    IEnumerator mov()
    {

        yield return new WaitForSeconds(2);
        objec.transform.position = objec.transform.position + mm.result;
        StartCoroutine(mov());
    }
        //mm.Mult(objec.transform.position, new Vector4(8, 0, 2, 1));
}
