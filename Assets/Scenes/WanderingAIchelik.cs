using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAIchelik : MonoBehaviour
{

    private bool alive = true;
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    [SerializeField] private GameObject fireballPrefab;
    private GameObject fireball;

    public bool Alive {
        get {
            return alive;
        }

        set {
            alive = value;
        }
    }

    void Update() {
        if (alive) {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            Ray ray = new Ray(transform.position, transform.right);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<CharacterController>()) {
                    if (fireball == null) {
                        fireball = Instantiate<GameObject>(fireballPrefab);
                        fireball.transform.position = transform.TransformPoint(Vector3.forward);
                        fireball.transform.rotation = transform.rotation;
                    }
                }
                if (hit.distance < obstacleRange) {
                    transform.Rotate(0, 0, Random.Range(-110, 110));
                }
            }
        }
    }
}