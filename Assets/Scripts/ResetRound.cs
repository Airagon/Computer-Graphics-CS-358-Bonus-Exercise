using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRound : MonoBehaviour
{
    public GameObject Player;

    public GameObject heart0;
    public GameObject heart1;
    public GameObject heart2;

    public GameObject Seesaw0;
    public GameObject Seesaw1;
    public GameObject Seesaw2;

    public Rigidbody rs0;
    public Rigidbody rs1;
    public Rigidbody rs2;

    private WinGame winGame;

    private AudioSource audioData;

    private int lifesLeft = 3;

    private void Start(){
        winGame = WinGame.Instance;
        audioData = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject == Player && !winGame.isGameFinished()){

            lifesLeft--;

            // Lazy HUD managment
            if(lifesLeft == 2){
                audioData.Play(0);
                heart2.SetActive(false);
            } 
            else if (lifesLeft == 1){
                audioData.Play(0);
                heart1.SetActive(false);
            } 
            else if (lifesLeft == 0){
                heart0.SetActive(false);
                // Freeze scene
                Time.timeScale = 0f;
                return;
            }


            // Get ball to the starting position (hardcoded here)
            Player.transform.position = new Vector3(-23.16f, 4.4f,-13.2f);

            // Reset rotation os seesaws (trampales)
            rs0.isKinematic = true;
            rs1.isKinematic = true;
            rs2.isKinematic = true;

            Seesaw0.transform.rotation = Quaternion.Euler(0, 0, 0);
            Seesaw1.transform.rotation = Quaternion.Euler(0, 0, 0);
            Seesaw2.transform.rotation = Quaternion.Euler(0, 0, 0);

            rs0.isKinematic = false;
            rs1.isKinematic = false;
            rs2.isKinematic = false;
        }
    }
}
