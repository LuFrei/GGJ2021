using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableEgg : MonoBehaviour
{
    [SerializeField]private GameManager gm;

    public int id;

    //I'd probably make an event here when this is collected to set off GameMAnager.FindEgg(), but I'm unwise and  ihave less than 24 hours ,so I'll wing it now, fix it later.
    //for now, we'll just store the egg's id to be searched in FindEgg()
    public void PickUp() {
        gm.FindEgg(id);
        Destroy(gameObject);
    }
}
