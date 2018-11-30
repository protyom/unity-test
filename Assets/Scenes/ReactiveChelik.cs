using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveChelik : MonoBehaviour {

    private Rigidbody rb;

    private static Vector3 CountAngles(float angle) {
        //trying to write from zero to 90

        float z = Mathf.Sin(Mathf.PI / 2 - Mathf.Deg2Rad * (30)) * Mathf.Sin(Mathf.PI / 2 - Mathf.Deg2Rad * (30));
        z += Mathf.Sin(Mathf.Deg2Rad * (angle)) * Mathf.Sin(Mathf.Deg2Rad * (angle));
        z = Mathf.Sqrt(z);
        z *= Mathf.Sin(Mathf.Deg2Rad * (30));
        z = Mathf.Asin(z);
        z *= Mathf.Rad2Deg;


        float x = Mathf.Sin(Mathf.PI / 2 - Mathf.Deg2Rad * (30)) * Mathf.Sin(Mathf.PI / 2 - Mathf.Deg2Rad * (30));
        x += Mathf.Sin(Mathf.PI / 2 - Mathf.Deg2Rad * (angle)) * Mathf.Sin(Mathf.PI / 2 - Mathf.Deg2Rad * (angle));
        x = Mathf.Sqrt(x);
        x *= Mathf.Sin(Mathf.Deg2Rad * (30));
        x = Mathf.Asin(x);
        x *= Mathf.Rad2Deg;

        if (angle >= .0f && angle <= 90.0f) {
            z *= -1.0f;
        } else if (angle > 90.0f && angle <= 180.0f) {
            z *= -1.0f;
            x *= -1.0f;
        } else if (angle > 180.0f && angle <= 270.0f) {
            x *= -1.0f;
        }
        return new Vector3(x, 0, z);

        /* Vector3 playerRotation = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad));
         Vector3 yAxe = Vector3.up;
         Vector3 rotationAxe = new Vector3();
         Vector3.OrthoNormalize(ref playerRotation, ref yAxe, ref rotationAxe);

         if((angle>=0.0f && angle<=90.0f) || (angle >= 180.0f && angle <= 270.0f)){
             rotationAxe.x *= -1.0f;
             rotationAxe.y *= -1.0f;
         }

         return rotationAxe;*/
    }

    // Use this for initialization
    void Start() {
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    public void ReactToHit(float angle) {

        WanderingAIchelik wa = GetComponent<WanderingAIchelik>();
        wa.Alive = false;
        rb.useGravity = true;
        StartCoroutine(Die(angle));
    }

    private IEnumerator Die(float angle) {



        transform.localEulerAngles = CountAngles(angle);
        //transform.Rotate(CountAngles(angle), 30.0f,Space.World);
        yield return new WaitForSeconds(1.0f);

        Destroy(this.gameObject);
    }
}


