using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour{
    
    public bool[] eggs = { false };

    public void FindEgg(int id) {
        eggs[id] = true;

        //check if this was the last egg and if we won
        if(checkIfAllEggsFound()) {
            EndGame();
        }
    }

    private bool checkIfAllEggsFound() {
        bool allFound = true;

        //one-way toggle. Var starts as true, if it hits a true, nothing happens. if it hits false, its set to false.
        for(int i = 0; i < eggs.Length; i++) {
            if(eggs[i] == false)
                allFound = false;
        }

        return allFound;
    }

    private void EndGame() {
        SceneManager.LoadScene("End");
    }
}
