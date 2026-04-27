using UnityEngine;

public class SceneOpenOnC : SceneOpener
{
    public string NextLevelName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OpenScene(NextLevelName);
    }
}
