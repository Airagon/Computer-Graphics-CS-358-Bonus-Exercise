using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiSpawner : MonoBehaviour
{   
    private ObjectPooler objectPooler;

    private int cubesSpawned;

    #region Singleton

    public static ConfettiSpawner Instance;

    private void Awake(){
        Instance = this;
    }

    #endregion

    private void Start(){
        objectPooler = ObjectPooler.Instance;

        // Making the number bigger than allowed so it doesn't spawn before trigger
        cubesSpawned = objectPooler.pools[0].size + 10;
    }

    void FixedUpdate() {
        if(cubesSpawned < objectPooler.pools[0].size){
            objectPooler.SpawnFromPool("Cube", transform.position, Quaternion.identity);
            cubesSpawned++;
            
            Debug.Log(cubesSpawned);
            // We don't need to call FixedUpdate anymore when all cubes spawned
            if(cubesSpawned > objectPooler.pools[0].size) return;
        }
    }

    public void StartTheShow(){
        cubesSpawned = 0;
    }
}
