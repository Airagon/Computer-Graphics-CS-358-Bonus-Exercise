using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float animationDelay;

    public void Start() {
        StartCoroutine(playAnimation());
    }
    
    public IEnumerator playAnimation() {
        yield return new WaitForSeconds(animationDelay);
        gameObject.GetComponent<Animator>().Play("PendulumBall");
    }
}