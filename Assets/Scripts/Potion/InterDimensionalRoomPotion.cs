using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterDimensionalRoomPotion : MonoBehaviour, AbstractPotion
{
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float timeOfAction;

    private GameObject player;
    private Vector3 playerPosBeforeTeleport;
    private GameObject portal;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosBeforeTeleport = player.transform.position;

        portal = GameObject.FindGameObjectWithTag("Portal");
    }

    public void Use()
    {
        player.transform.position = new Vector3(x, y, 0);
        if (portal != null) portal.GetComponent<EnemySpawner>().enabled = false;

        transform.SetParent(null);

        StartCoroutine(teleportBack());
    }

    private IEnumerator teleportBack()
    {
        yield return new WaitForSeconds(timeOfAction);

        player.transform.position = playerPosBeforeTeleport;
        if (portal != null) portal.GetComponent<EnemySpawner>().enabled = true;

        Destroy(gameObject);
    }
}
