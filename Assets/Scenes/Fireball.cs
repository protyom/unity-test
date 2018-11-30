using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    [SerializeField] public GameObject firePrefab;
    private GameObject fire;

    public float speed = 10.0f;
    public int damage = 1;


    private void Start() {
        fire = Instantiate<GameObject>(firePrefab);
        fire.transform.rotation = transform.rotation;
        //fire.transform.localRotation = Quaternion.Euler(Vector3.back);
        fire.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(0, 0, Time.deltaTime * speed);
        fire.transform.Translate(0, 0, Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other){
        PlayerCharacter pc = other.GetComponent<PlayerCharacter>();
        if (pc != null) {
            Debug.Log("hit");
        }
        Destroy(this.gameObject);
        Destroy(fire);


    }
}
