using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class MakeCube : MonoBehaviour
{
    public Material material;
    public MatrixMult matrixMult;

    public enum Rotation { X, Y, Z };
    public Rotation rotation;

    public Vector3[] vertices = { 
        
        /* VERSION 1
        //C1
        new Vector3 (0,0,0), //0
        new Vector3 (0,1,0), //1
        new Vector3 (1,1,0), //2
        new Vector3 (1,0,0), //3
        //C2
        new Vector3 (1,1,1),//4
        new Vector3 (1,0,1),//5
        //C3
        new Vector3 (0,1,1),//6
        new Vector3 (0,0,1),//7123
        */

        //C1
        new Vector3 (-.5f,-.5f,-0.5f), //0
        new Vector3 (-.5f,.5f,-0.5f), //1
        new Vector3 (.5f,.5f,-.5f), //2
        new Vector3 (.5f,-.5f,-.5f), //3
        //C2
        new Vector3 (.5f,.5f,.5f),//4
        new Vector3 (.5f,-0.5f,.5f),//5
        //C3
        new Vector3 (-0.5f,.5f,.5f),//6
        new Vector3 (-.5f,-.5f,.5f),//7

        
    };

    int[] triangles = {0,1,2,
                       0,2,3,
                       3,2,4,
                       3,4,5,
                       5,4,6,
                       5,6,7,
                       7,6,1,//1 u 8
                       7,1,0,//1 u 8
                       1,6,4,
                       1,4,2,
                       7,0,3,//0 u 9
                       7,3,5

    };

    void Cube()
    {
        Mesh mesh= GetComponent<MeshFilter>().mesh;
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = material;
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.Optimize();
        mesh.RecalculateNormals();

       


    }

    private void Start()
    {
        Cube();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            switch(rotation)
            {
                case Rotation.X:
                        for (int i = 0; i < vertices.Length; i++)
                        {
                            vertices[i] = matrixMult.RotX(vertices[i], 30);
                        }
                    break;
                case Rotation.Y:
                        for (int i = 0; i < vertices.Length; i++)
                        {
                            vertices[i] = matrixMult.RotY(vertices[i], 30);
                        }
                        break;
                case Rotation.Z:
                        for (int i = 0; i < vertices.Length; i++)
                        {
                            vertices[i] = matrixMult.RotZ(vertices[i], 30);
                        }
                        break;
            }
            Cube();

        }


    }
}
