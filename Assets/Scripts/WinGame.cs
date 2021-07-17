using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{   
    public GameObject virtualCamera;

    private ConfettiSpawner confettiSpawner;
    private bool isFinished = false;

    private AudioSource audioData;

    #region Singleton

    public static WinGame Instance;

    private void Awake(){
        Instance = this;
    }

    #endregion

    private void Start(){
        confettiSpawner = ConfettiSpawner.Instance;
        audioData = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {   
        if(col.tag == "Player"){
            Debug.Log("GG");
            audioData.Play(0);
            isFinished = true;
            virtualCamera.SetActive(false);
            confettiSpawner.StartTheShow();
        }
    }

    public bool isGameFinished() { return isFinished; }
}