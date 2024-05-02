using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class FlaurosCenter : MonoBehaviour
{
    public Material material;
    public MatrixMult matrixMult;
    Vector3[] vertices =
    {
        new Vector3(0,      -(Mathf.Sqrt(6)/3)/2 ,   0                          -0.5773507f ),//0
        new Vector3(0.5f,   -(Mathf.Sqrt(6)/3)/2 ,   Mathf.Sqrt(3)/2            -0.5773507f ),//1
        new Vector3(-0.5f,  -(Mathf.Sqrt(6)/3)/2 ,   Mathf.Sqrt(3)/2            -0.5773507f ),//2                     
        new Vector3(0,      (Mathf.Sqrt(6)/3)/2 ,   (Mathf.Sqrt(3)/2)+.2886756f-0.5773507f ),//3
        new Vector3(0.5f,   (Mathf.Sqrt(6)/3)/2 ,   .2886756f                  -0.5773507f ),//4
        new Vector3(-0.5f,  (Mathf.Sqrt(6)/3)/2 ,   .2886756f                  -0.5773507f )//5

        /*
        //V2
        new Vector3(0,      -(Mathf.Sqrt(6)/3)/2,       -.5773502691896f),//0
        new Vector3(0.5f,   -(Mathf.Sqrt(6)/3)/2,       Mathf.Sqrt(3)/6),//1
        new Vector3(-0.5f,  -(Mathf.Sqrt(6)/3)/2,        Mathf.Sqrt(3)/6),//2

        new Vector3(0,      Mathf.Sqrt(6)/3/2,       -.5773502691896f),//0
        new Vector3(0.5f,   Mathf.Sqrt(6)/3/2,       (Mathf.Sqrt(3)/6) +.5773502691896f),//1
        new Vector3(-0.5f,  Mathf.Sqrt(6)/3/2,       (Mathf.Sqrt(3)/6) +.5773502691896f),//2
        */


    };
    Vector3[] vertices2 =
    {
        new Vector3(0,      -(Mathf.Sqrt(6)/3)/2 ,   0                          -0.5773507f ),//0
        new Vector3(0.5f,   -(Mathf.Sqrt(6)/3)/2 ,   Mathf.Sqrt(3)/2            -0.5773507f ),//1
        new Vector3(-0.5f,  -(Mathf.Sqrt(6)/3)/2 ,   Mathf.Sqrt(3)/2            -0.5773507f ),//2                     
        new Vector3(0,      (Mathf.Sqrt(6)/3)/2 ,   (Mathf.Sqrt(3)/2)+.2886756f-0.5773507f ),//3
        new Vector3(0.5f,   (Mathf.Sqrt(6)/3)/2 ,   .2886756f                  -0.5773507f ),//4
        new Vector3(-0.5f,  (Mathf.Sqrt(6)/3)/2 ,   .2886756f                  -0.5773507f )//5

    };

    int[] triangles = {0,1,2,//check //0
                       3,4,5,//check
                       0,4,1,//check
                       2,5,0,//check
                       1,4,3,//check
                       1,3,2,//check
                       2,3,5,//check
                       0,5,4//check
    };
    void FlauroCenter()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = material;
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.Optimize();
        mesh.RecalculateNormals();

    }
    void Awake()
    {
        FlauroCenter();
        transform.rotation = new Quaternion(0, 180, 0, 0);
    }
    public void Rotate()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);

    }

    public void Rotate(Vector3 _rotationAngle)
    {
        Vector3 vector3 = _rotationAngle - transform.position;
        Debug.Log(vector3);


        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = matrixMult.RotX(vertices[i], vector3.x);
        }
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = matrixMult.RotY(vertices[i], vector3.y);
        }
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = matrixMult.RotZ(vertices[i], vector3.z);
        }
        
        FlauroCenter();

    }
    public void RotateBack(Vector3 _rotationAngle)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vector3 = _rotationAngle - vertices2[i];

            vertices2[i] = matrixMult.RotX(vertices2[i], vector3.x);
            vertices[i] = vertices2[i];

        }
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vector3 = _rotationAngle - vertices2[i];

            vertices2[i] = matrixMult.RotY(vertices2[i], vector3.y);
            vertices[i] = vertices2[i];

        }
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vector3 = _rotationAngle - vertices2[i];

            vertices2[i] = matrixMult.RotZ(vertices2[i], vector3.z);
            vertices[i] = vertices2[i];
        }
        
        FlauroCenter();

    }

}
