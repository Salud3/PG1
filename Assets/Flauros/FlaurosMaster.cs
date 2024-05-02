using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaurosMaster : MonoBehaviour
{
    [SerializeField] FlaurosPiramid[] piramids = new FlaurosPiramid[4];
    /*[SerializeField] FlaurosPiramid p1;
    [SerializeField] FlaurosPiramid p2;
    [SerializeField] FlaurosPiramid p3;
    [SerializeField] FlaurosPiramid p4;*/
    [SerializeField] FlaurosCenter Flauros;

    public MatrixMult matrix;

    private void Start()
    {
        for (int i = 0; i < piramids.Length; i++)
        {
            piramids[i].transform.parent = Flauros.transform;
        }
        Flauros.Rotate();
            StartCoroutine(Anim1());
    }

    IEnumerator Anim1()
    {
        if (Flauros.transform.position.y <= 1.5)
        {
            Flauros.transform.position = matrix.Move(Flauros.transform.position,new Vector4(0,0.1f,0,0));    
            yield return new WaitForSeconds(.1f);
            StartCoroutine(Anim1());
        }
        else
        {
            Debug.Log("Anim1 finished");
            StartCoroutine(Anim2());
        }
    }

        int it = 0;
    public int itc;
    float altura;
    public float mov;
    IEnumerator Anim2()
    {
        altura = (mov / 3)/itc;
        if (it <=itc)
        {
            float movreal = mov / itc;
            
            for (int i = 0; i < piramids.Length; i++)
            {
                if (i != piramids.Length - 1)
                {
                    piramids[i].transform.position = matrix.Move(piramids[i].transform.position, new Vector4(movreal, -altura, movreal, 0));
                }
                else
                {
                    piramids[i].transform.position = matrix.Move(piramids[i].transform.position, new Vector4(0, altura, 0, 0));

                }
            }
            yield return new WaitForSeconds(.1f);
            StartCoroutine(Anim2());
            it++;
        }
        else
        {
            Debug.Log("Anim2 finished");
            StartCoroutine(Anim3());
            it = 0;
            Debug.Log(it);

        }


    }
    [SerializeField] Vector3 rotationFinal = new Vector3(153, 55, 55);//1y-//2z-
    [SerializeField] Vector3 rotation1 = new Vector3(-120, 180, 0);
    [SerializeField] Vector3 rotation4 = new Vector3(0,0, 0);

    IEnumerator Anim3 ()
    {
        if (it<=itc)
        {
            Debug.Log(it);
            piramids[0].rotate(rotationFinal / itc,0);
            piramids[1].rotate(rotationFinal / itc, 1);
            piramids[2].rotate(rotation1 / itc, 2);
            piramids[3].rotate(rotation4 / itc, 3);
        
        yield return new WaitForSeconds(0.1f);
            it++;
        StartCoroutine (Anim3());
        }
        else
        {
            Debug.Log("Anim3 Finished");
        }
    }

    

}
