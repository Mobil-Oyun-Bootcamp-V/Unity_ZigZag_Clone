using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    void OnTriggerExit(Collider other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (pc)
        {
            int rnd = Random.Range(0, 2);
            TileSpawner.Instance.Spawn(rnd);
            StartCoroutine(FallTile());
        }
    }

    IEnumerator FallTile()
    {
        yield return new WaitForSeconds(1.5f);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        yield return new WaitForSeconds(1.5f);
        Destroy(rb.gameObject);
    }
}
