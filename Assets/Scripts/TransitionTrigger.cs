using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionTrigger : MonoBehaviour{
    public int transitionTo;

    public void Transition() {
        SceneManager.LoadScene(transitionTo);
    }
}
