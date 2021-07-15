using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using TMPro;

public class PortalTeleport : MonoBehaviour
{
    private GameObject player;
    private Tilemap[] tilemaps;
    private List<Transform> toClear = new List<Transform>();
    private TextMeshProUGUI newLevelText;

    private const float portalAnimationTime = 1f;

    private float expToEarn;

    public static int IngameLvl = 1;

    private void Start()
    {
        GetComponent<DifficultyController>().GameLvlChanged(IngameLvl);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement _))
        {
            if (player.GetComponent<PlayerExperience>().AllExperience >= expToEarn)
            {
                collision.GetComponent<Animator>().SetTrigger("portal");

                IngameLvl++;
                newLevelText.text = "Level: " + IngameLvl.ToString();

                StartCoroutine(WaitForAnimationToEndAndTeleport());
            }
            else
            {
                newLevelText.text = player.GetComponent<PlayerExperience>().AllExperience + " / " + expToEarn;
                StartCoroutine(deleteText());
            }
        }
    }

    private IEnumerator WaitForAnimationToEndAndTeleport()
    {
        yield return new WaitForSeconds(portalAnimationTime);

        foreach (Tilemap tilemap in tilemaps)
        {
            tilemap.ClearAllTiles();
        }

        foreach(Transform target in toClear)
        {
            for (int child = 0; child < target.childCount; child++)
            {
                Destroy(target.GetChild(child).gameObject);
            }
        }
        
        player.transform.position = new Vector3();
        player.GetComponent<TerrainGenerator>().Restart();
        player.GetComponent<ObstacleGenerator>().Restart();
        player.GetComponent<PotionGenerator>().Restart();
        player.GetComponent<PortalSpawner>().Spawn();
        player.GetComponent<RoomSpawner>().Spawn();
        newLevelText.text = "";
        Destroy(gameObject);
    }

    private IEnumerator deleteText()
    {
        yield return new WaitForSeconds(portalAnimationTime);

        newLevelText.text = "";
    }

    public void SetExpToEarn(float E) => expToEarn = E;
    public void SetTilemaps(Tilemap[] TM) => tilemaps = TM;
    public void SetPlayer(GameObject P) => player = P;
    public void SetToClear(Transform E) => toClear.Add(E);
    public void SetNewLevelText(TextMeshProUGUI T) => newLevelText = T;
}
