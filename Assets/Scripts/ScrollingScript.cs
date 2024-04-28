using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);
    public bool isLinkedToCamera = false;
    public bool isLooping = false;
    private List<SpriteRenderer> _backgroundPart;

    void Start()
    {
        if (isLooping)
        {
            _backgroundPart = new List<SpriteRenderer>();

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                SpriteRenderer r = child.GetComponent<SpriteRenderer>();

                if (r != null)
                {
                    _backgroundPart.Add(r);
                }
            }

            _backgroundPart = _backgroundPart.OrderBy(
                t => t.transform.position.x
            ).ToList();
        }
    }

    void Update()
    {
        Vector3 movement = new Vector3(
            speed.x * direction.x,
            speed.y * direction.y,
            0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }

        if (!isLooping)
        {
            return;
        }

        SpriteRenderer firstChild = _backgroundPart.FirstOrDefault();

        if (firstChild)
        {
            if (firstChild.transform.position.x < Camera.main.transform.position.x)
            {
                if (firstChild.IsVisibleFrom(Camera.main) == false)
                {
                    SpriteRenderer lastChild = _backgroundPart.LastOrDefault();

                    if (lastChild)
                    {
                        Vector3 lastPosition = lastChild.transform.position;
                        Vector3 lastSize = (lastChild.bounds.max - lastChild.bounds.min);

                        firstChild.transform.position = new Vector3(lastPosition.x + lastSize.x,
                            firstChild.transform.position.y, firstChild.transform.position.z);
                    }

                    _backgroundPart.Remove(firstChild);
                    _backgroundPart.Add(firstChild);
                }
            }
        }
    }
}