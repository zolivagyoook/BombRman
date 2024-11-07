/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{

    public class BombPlace : MonoBehaviour
    {
        public GameObject bombPrefab;
        public GameObject entity;
        public GameObject explosionPrefab;
        public float bombCooldown = 6f;
        public float nextBombTime = 0f;
        public int bombCount = 1;
        public int currentBombCount;
        public bool isInTestMode = false;

        public List<GameObject> bombs = new List<GameObject>();
        public bool detonator = false;

         public void Start()
        {
            currentBombCount = bombCount;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                detonator = true;
            }
            if (Input.GetKeyDown(KeyCode.F) && currentBombCount > 0)
            {
                if (detonator)
                {
                    PlaceBombDetonator();
                }
                else
                {
                    PlaceBomb();
                }
                nextBombTime = Time.time + bombCooldown;
                currentBombCount--;
            }

            if (Time.time >= nextBombTime && currentBombCount + bombs.Count < bombCount)
            {
                currentBombCount++;
                nextBombTime = Time.time + bombCooldown;
            }
            if (Input.GetKeyDown(KeyCode.R) && detonator)
            {
                ExplodeDetonator();
            }

        }

        public void PlaceBomb()
        {
            if (bombPrefab != null)
            {

                Vector3 originalPosition = entity.transform.position;

                Vector3 roundedPosition = new Vector3(
                    Mathf.RoundToInt(originalPosition.x),
                    Mathf.RoundToInt(originalPosition.y),
                    Mathf.RoundToInt(originalPosition.z)
                );


                GameObject bomb = Instantiate(bombPrefab, roundedPosition, Quaternion.identity);
                BombExplosion bombExplosion = bomb.AddComponent<BombExplosion>();
                bombExplosion.bomb = bomb;
                bombExplosion.explosionPrefab = explosionPrefab;
                bombExplosion.playerWhoPlacedTheBomb = entity;
                if (!isInTestMode)
                {
                    Destroy(bomb, 4f);
                }
                Physics.IgnoreCollision(bomb.GetComponent<Collider>(), entity.GetComponent<Collider>());
            }
        }
        public void PlaceBombDetonator()
        {
            if (bombPrefab != null)
            {
                GameObject bomb = Instantiate(bombPrefab, entity.transform.position, Quaternion.identity);
                bombs.Add(bomb);
            }
        }

        public void ExplodeDetonator()
        {
            foreach (GameObject bomb in bombs)
            {
                if (bomb != null)
                {
                    BombExplosion bombExplosion = bomb.AddComponent<BombExplosion>();
                    bombExplosion.bomb = bomb;
                    bombExplosion.explosionPrefab = explosionPrefab;
                    bombExplosion.Invoke("Explode", 2f);
                    bombExplosion.playerWhoPlacedTheBomb = entity;
                    if (!isInTestMode)
                    {
                        Destroy(bomb);
                    }
                }
            }
            bombs.Clear();
        }
    }
}*/