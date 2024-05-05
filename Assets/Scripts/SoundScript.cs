using UnityEngine;

public class SoundScript : MonoBehaviour
{

    public static SoundScript Instance;
    public AudioClip[] PlayerDieSounds;
    public AudioClip[] AttackSounds;
    public AudioClip[] EnemyDieSounds;
    public AudioClip[] UIClickSounds;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void PlaySound(AudioClip sound)
    {
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
    }
    
    public void PlayPlayerDieSound()
    {
        PlaySound(PlayerDieSounds[Random.Range(0, PlayerDieSounds.Length)]);
    }
    
    public void PlayAttackSound()
    {
        PlaySound(AttackSounds[Random.Range(0, AttackSounds.Length)]);
    }
    
    public void PlayEnemyDieSound()
    {
        PlaySound(EnemyDieSounds[Random.Range(0, EnemyDieSounds.Length)]);
    }
    
    public void PlayUIClickSound()
    {
        PlaySound(UIClickSounds[Random.Range(0, UIClickSounds.Length)]);
    }
}
