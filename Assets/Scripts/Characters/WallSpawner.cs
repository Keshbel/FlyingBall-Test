using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public bool isOn;
    
    public GameObject wallPrefab;

    public List<GameObject> walls;

    public IEnumerator Spawning()
    {
        var hardMode = GameManager.HardMode;
        var spawnDelay = 4f / hardMode;
        
        while (isOn)
        {
            var randCount = Random.Range(1f, GameManager.HardMode); //количество стенок

            for (int i = 0; i < randCount; i++)
            {
                var randYPosition = Random.Range(-4f, 4f); //высота по Y
                var randHeight = Random.Range(hardMode/2, 3); //высота в тайлах
                
                var wall = Instantiate(wallPrefab, new Vector3(Camera.main.transform.position.x + 10, randYPosition, 0), Quaternion.identity);
                var spriteRenderer = wall.GetComponent<SpriteRenderer>();
                spriteRenderer.size = new Vector2(spriteRenderer.size.x, randHeight);
                
                StartCoroutine(DestroyWall(wall, 20));
            }
            
            yield return new WaitForSeconds(spawnDelay); //задержка
        }
    }

    private IEnumerator DestroyWall(GameObject wall, float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (!walls.Contains(wall)) yield break;
        
        walls.Remove(wall);
        Destroy(wall);
    }

    public void DestroyWalls()
    {
        foreach (var wall in walls)
        {
            Destroy(wall);
        }
        
        walls.Clear();
    }
}
