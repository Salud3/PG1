using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixMovement : MonoBehaviour
{
    public MatrixMult mm;
    public GameObject objec;
    public enum Rotation { X, Y, Z };
    public Rotation rotation;
    void Start()
    {
        

        


        //StartCoroutine(mov());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //objec.transform.position = mm.Mult(objec.transform.position, new Vector3(0.08f,0,0.02f));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (rotation)
            {
                case Rotation.X:

                    objec.transform.position = mm.RotX(objec.transform.position, 30);

                    break;

                case Rotation.Y:
                    objec.transform.position = mm.RotY(objec.transform.position, 30);
                    break;

                case Rotation.Z:
                    objec.transform.position = mm.RotZ(objec.transform.position, 30);

                    break;

                default:

                    break;
            }
        }
    }

    IEnumerator mov()
    {

        yield return new WaitForSeconds(2);
        objec.transform.position = objec.transform.position + mm.result;
        StartCoroutine(mov());
    }
        //mm.Mult(objec.transform.position, new Vector4(8, 0, 2, 1));
}
