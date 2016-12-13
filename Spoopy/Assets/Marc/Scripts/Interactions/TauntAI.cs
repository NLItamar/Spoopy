using UnityEngine;
using System.Collections;

public class TauntAI : MonoBehaviour {

	public void TriggerInvestigate(Vector3 target)
    {

        GetComponent<residentMovement>().investigate(target);
    }
}
