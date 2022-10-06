using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public int numberOfPlatforms = 200;
	public GameObject platformPrefab;
	public GameObject BrokenPlatform;
    public GameObject SpringPlatform;
    public GameObject GemStone;
	public float levelWidth = 3f;
	public float minY = .2f;
	public float maxY = 1.5f;
	public float txtminY = 50f;
	public float txtmaxY = 200f;

	// Use this for initialization
	void Start () 
	{
		Vector3 spawnPosition = new Vector3();

		for (int i = 0; i < numberOfPlatforms; i++)
		{
			spawnPosition.y += Random.Range(minY, maxY);
			spawnPosition.x = Random.Range(-levelWidth, levelWidth);

			Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

			platformPrefab.gameObject.name = i.ToString();
			
				var RandomPlatform = Random.Range(1, 30);
				spawnPosition.y += Random.Range(minY, maxY);
				spawnPosition.x = Random.Range(-levelWidth, levelWidth);

            if (RandomPlatform == 10)
            {
                Instantiate(SpringPlatform, spawnPosition, Quaternion.identity);
            }

            if (RandomPlatform == 20)
				{
					Instantiate(BrokenPlatform, spawnPosition, Quaternion.identity);
				}
			}
		}
	}
	
