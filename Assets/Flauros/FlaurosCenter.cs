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
        new Vector3(-0.5f,  (Mathf.Sqrt(6)/3)/2 ,   .2886756f                  -0.5773507f ),//5

        new Vector3(0.5f,   -(Mathf.Sqrt(6)/3)/2 ,   Mathf.Sqrt(3)/2            -0.5773507f ),//6//1
        new Vector3(-0.5f,  -(Mathf.Sqrt(6)/3)/2 ,   Mathf.Sqrt(3)/2            -0.5773507f ),//7//2

        new Vector3(0,      (Mathf.Sqrt(6)/3)/2 ,   (Mathf.Sqrt(3)/2)+.2886756f-0.5773507f ),//8//3
        new Vector3(-0.5f,  (Mathf.Sqrt(6)/3)/2 ,   .2886756f                  -0.5773507f ),//9//5              


    };
    Vector3[] vertices2 =
    {
        new Vector3(0,      -(Mathf.Sqrt(6)/3)/2 ,   0                          -0.5773507f ),//0
        new Vector3(0.5f,   -(Mathf.Sqrt(6)/3)/2 ,   Mathf.Sqrt(3)/2            -0.5773507f ),//1
        new Vector3(-0.5f,  -(Mathf.Sqrt(6)/3)/2 ,   Mathf.Sqrt(3)/2            -0.5773507f ),//2
                                                                                              
        new Vector3(0,      (Mathf.Sqrt(6)/3)/2 ,   (Mathf.Sqrt(3)/2)+.2886756f-0.5773507f ),//3
        new Vector3(0.5f,   (Mathf.Sqrt(6)/3)/2 ,   .2886756f                  -0.5773507f ),//4
        new Vector3(-0.5f,  (Mathf.Sqrt(6)/3)/2 ,   .2886756f                  -0.5773507f ),//5

        new Vector3(0.5f,   -(Mathf.Sqrt(6)/3)/2 ,   Mathf.Sqrt(3)/2            -0.5773507f ),//6//1
        new Vector3(-0.5f,  -(Mathf.Sqrt(6)/3)/2 ,   Mathf.Sqrt(3)/2            -0.5773507f ),//7//2

        new Vector3(0,      (Mathf.Sqrt(6)/3)/2 ,   (Mathf.Sqrt(3)/2)+.2886756f-0.5773507f ),//8//3
        new Vector3(-0.5f,  (Mathf.Sqrt(6)/3)/2 ,   .2886756f                  -0.5773507f ),//9//5     


    };

    int[] triangles = {0,1,2,//ABAJO //0,1,2 //check

         8,4,9,//ARRIBA //TAPADO // 3,5,4 //check

         //de abajo para arriba
         0,4,6,//check//2 //TAPADO // C/check
         2,5,0,//check//3 //TAPADO // B //PERFECTO /check
         7,6,8,//check//5 //TAPADO // D/check

         //de arriba para abajo
         4,8,6,//check//4 //1,4,3/check
         2,3,5,//check//6 //2,3,5// check
         0,5,4//check//7 //0,5,4/check
    };
         
    Vector2[] uvs = {
        new Vector2(  0.489f,0.333f  ),  //0
        new Vector2(  0.611f,0.056f  ),  //1 
        new Vector2(  0.731f,0.333f  ),  //2

        new Vector2(  0.863f,0.622f  ),  //3
        new Vector2(  0.365f,0.625f  ),  //4 
        new Vector2(  0.62f,0.62f  ),  //5
                   
        new Vector2(  0.249f,0.333f  ),  //6 
                   
        new Vector2(  0f,0.33f  ),  //7

        new Vector2(  0.122f,0.627f  ),  //8//N
        new Vector2(  0.251f,0.904f  ),  //9//N
    
    };

    void FlauroCenter()
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
