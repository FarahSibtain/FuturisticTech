using ReadyPlayerMe.Core;
using UnityEngine;
using ReadyPlayerMe.AvatarCreator;
using ReadyPlayerMe.Samples.QuickStart;
using System.Collections;

public class MetaverseGM : MonoBehaviour
{
    [SerializeField] private AvatarConfig inGameConfig;
    [SerializeField] private ThirdPersonLoader thirdPersonLoader;

    private AvatarObjectLoader avatarObjectLoader;

    public static string AvatarID = "";

    private void Start()    
    {
        StartCoroutine( LoadAvatarFromRPMPlayer());
    }

    private void AvatarFromRPMObjLoader()
    {
        var startTime = Time.time;
        avatarObjectLoader = new AvatarObjectLoader();
        avatarObjectLoader.AvatarConfig = inGameConfig;

        //Load RPM avatar
        avatarObjectLoader.OnCompleted += (sender, args) =>
        {
            AvatarAnimationHelper.SetupAnimator(args.Metadata, args.Avatar);
            Debug.Log("Created avatar loaded " + (Time.time - startTime).ToString());
        };

        if (!string.IsNullOrEmpty(AvatarID))
            avatarObjectLoader.LoadAvatar($"{Env.RPM_MODELS_BASE_URL}/{AvatarID}.glb");
    }

    private IEnumerator LoadAvatarFromRPMPlayer()
    {
        yield return null;
        yield return null;
        yield return null;

        thirdPersonLoader.OnLoadComplete += OnLoadComplete;
        //defaultButtonText = openPersonalAvatarPanelButtonText.text;
        //SetActiveLoading(true, "Loading...");

        thirdPersonLoader.LoadAvatar($"{Env.RPM_MODELS_BASE_URL}/{AvatarID}.glb");
        //personalAvatarPanel.SetActive(false);
        //SetActiveThirdPersonalControls(true);
        //AnalyticsRuntimeLogger.EventLogger.LogPersonalAvatarLoading(avatarUrlField.text);
    }

    private void OnLoadComplete()
    {
        thirdPersonLoader.OnLoadComplete -= OnLoadComplete;
        //SetActiveLoading(false, defaultButtonText);
    }
}
