using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class OpenningVideoManager : MonoBehaviour
{
    [SerializeField] private RawImage rawImage; // 用于显示视频的 UI 元素
    [SerializeField] private VideoClip[] videoClips; // 存放你的视频剪辑数组

    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;

        // 设置视频输出到 RawImage
        videoPlayer.targetTexture = new RenderTexture((int)rawImage.rectTransform.rect.width, (int)rawImage.rectTransform.rect.height, 24);

        rawImage.texture = videoPlayer.targetTexture;

        // 设置视频剪辑并订阅播放完成事件
        videoPlayer.clip = videoClips[Random.Range(0, videoClips.Length)];
        videoPlayer.loopPointReached += OnVideoEnd;

        // 开始播放视频
        videoPlayer.Play();
    }

    // 播放完成事件处理
    void OnVideoEnd(VideoPlayer vp)
    {
        // 随机选择下一个视频剪辑
        videoPlayer.clip = videoClips[Random.Range(0, videoClips.Length)];
        
        // 重新播放
        videoPlayer.Play();
    }
}
