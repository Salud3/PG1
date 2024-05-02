using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class FlaurosPiramid : MonoBehaviour
{
    public Material material;
    public MatrixMult matrixMult;

    public enum Rotation { X, Y, Z };
    public Rotation rotation;
    public float rotationAngle;

    Vector3[] vertices =
    {
        /*
        new Vector3(0,0,0),//0
        new Vector3(0.5f,0,Mathf.Sqrt(3)/2),//1
        new Vector3(-0.5f,0,Mathf.Sqrt(3)/2),//2
        new Vector3(0,Mathf.Sqrt(6)/3,.5773502691896f),//3
        */
        //V2
        new Vector3(0,      -(Mathf.Sqrt(6)/3)/2,       -.5773502691896f),//0
        new Vector3(0.5f,   -(Mathf.Sqrt(6)/3)/2,       Mathf.Sqrt(3)/6),//1
        new Vector3(-0.5f,  -(Mathf.Sqrt(6)/3)/2,        Mathf.Sqrt(3)/6),//2
        new Vector3(0,      Mathf.Sqrt(6)/3/2,          0),//3
        new Vector3(0,      Mathf.Sqrt(6)/3/2,          0),//4
        new Vector3(0,      Mathf.Sqrt(6)/3/2,          0),//5
        new Vector3(0,      Mathf.Sqrt(6)/3/2,          0),//6


    };
    Vector3[] vertices2 =
    {
        //V2
        new Vector3(0,      -(Mathf.Sqrt(6)/3)/2,       -.5773502691896f),//0
        new Vector3(0.5f,   -(Mathf.Sqrt(6)/3)/2,       Mathf.Sqrt(3)/6),//1
        new Vector3(-0.5f,  -(Mathf.Sqrt(6)/3)/2,        Mathf.Sqrt(3)/6),//2
        new Vector3(0,      Mathf.Sqrt(6)/3/2,          0),//3
        new Vector3(0,      Mathf.Sqrt(6)/3/2,          0),//4
        new Vector3(0,      Mathf.Sqrt(6)/3/2,          0),//5
        new Vector3(0,      Mathf.Sqrt(6)/3/2,          0),//6

    };

    int[] triangles = {0,1,2,//check //0
                       0,3,1,//check //1
                       1,4,2,//check //2
                       2,5,0 //check //3
                       
    };

    Vector2[] uvs = {
            new Vector2(0, 0.35f),      //0
            new Vector2(0.25f, 0.66f),  //1
            new Vector2(0, 0.33f),      //2
            new Vector2(0.25f, 0.33f),  //3
            new Vector2(0.25f, 0.66f),  //4
            new Vector2(0, 0.33f),      //5
            new Vector2(0.25f, 0.33f),  //6
        };
    void Piramide()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = material;
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.Optimize();
        mesh.RecalculateNormals();


    }

    private void Start()
    {

        Piramide();
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Debug.Log(mesh.uv.Length);
    }

    public void Rotate(Vector3 _rotationAngle,int id)
    {

        Vector3 vector3 = _rotationAngle - transform.position;
        Debug.Log(vector3);

        if (id == 2)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = matrixMult.RotX(vertices[i], vector3.x);
            }
        }
        else
        {

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
        
        }
            Piramide();
        
    }
    public void RotateBack()
    {
        for (int i = 0; i < vertices.Length; i++)
        {

            vertices[i] = vertices2[i];

        }
        Piramide();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            
            Piramide();

        }


    }
}
