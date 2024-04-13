using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private List<Transform> enemiesInRange = new List<Transform>();

    public ParticleSystem particleSystem;

    float fearLevel = 0.0f;

    public LayerMask mask = 1 << 3;
    
    //public Transform transform;

    //private ParticleSystem particleSystem;

    void Start() {
        //particleSystem = GetComponent<ParticleSystem>();
        //StartCoroutine("DetermineFearLevelWithDelay", .2f);
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Enemy") {
            enemiesInRange.Add(other.transform);
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Enemy") {
            enemiesInRange.Remove(other.transform);
        }
    }
/*
    IEnumerator DetermineFearLevelWithDelay(float delay) {
        while (true) {
            yield return new WaitForSeconds ( delay );
            FearSimulate();
        }
    }
*/
    void Update ()
    {
        FearSimulate();
    }

    void FearSimulate()
    {
        fearLevel = 0.0f;
        for (int i = 0; i < enemiesInRange.Count; i++) {
            Vector3 direction = enemiesInRange[i].position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast (ray, out raycastHit, 50.0f , ~mask))
            {
                if (enemiesInRange.Contains(raycastHit.collider.transform)) {
                    fearLevel += Vector3.Dot(transform.forward,direction);
                }
            }
        }
        if (particleSystem != null){
            var emission = particleSystem.emission;
            emission.rateOverTime = fearLevel * 30;
        }
    }
}
