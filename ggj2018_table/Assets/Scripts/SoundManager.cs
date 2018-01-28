using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    // BGM用
    [SerializeField]
    public AudioSource _bgSource;

    // 正解音
    [SerializeField]
    private AudioSource _correctSource;

    // 成功ジングル
    [SerializeField]
    private AudioSource _successJingleSource;

    // 失敗音
    [SerializeField]
    private AudioSource _wrongSource;

    public List<AudioClip> _seAudioClip = new List<AudioClip>();

    public void PlayBGM()
    {
        if(_bgSource != null)
        {
            _bgSource.loop = true;
            _bgSource.Play();
        }
    }

    public void PlaySEByIndex(int index)
    {
        switch (index)
        {
            case 0:
                PlaySECorrect();
                break;
            case 1:
                PlaySESuccessJingleSource();
                break;
            case 2:
                PlaySEWrong();
                break;
            case 3:
                break;
        }
    }

    public void PlaySECorrect()
    {
        if (_correctSource != null)
        {
            _correctSource.loop = false;
            _correctSource.Play();
        }
    }

    public void PlaySESuccessJingleSource()
    {
        if (_successJingleSource != null)
        {
            _successJingleSource.loop = false;
            _successJingleSource.Play();
        }
    }

    public void PlaySEWrong()
    {
        if (_wrongSource != null)
        {
            _wrongSource.loop = false;
            _wrongSource.Play();
        }
    }

    // Use this for initialization
    void Start () {
        _correctSource = gameObject.AddComponent<AudioSource>();
        _correctSource.clip = _seAudioClip[0];
        _successJingleSource = gameObject.AddComponent<AudioSource>();
        _successJingleSource.clip = _seAudioClip[1];
        _wrongSource = gameObject.AddComponent<AudioSource>();
        _wrongSource.clip = _seAudioClip[2];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
