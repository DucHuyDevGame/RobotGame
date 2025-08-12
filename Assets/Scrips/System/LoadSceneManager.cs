using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class LoadSceneManager : BYSingletonMono<LoadSceneManager>
{
    public GameObject ui_object;
    public Image image_progress;
    public Text progress_lb;
    public float time_delay = 0.1f;
    public float width = 1980;
    public float totalDuration = 3.5f;
    public float activationDuration = 1.5f;
    public float maxStepPerTick = 0.02f;
    public float epsilon = 0.004f;
    public void LoadSceneByName(string scene_name, bool useUI ,Action<bool> callback)
    {
        StartCoroutine(LoadSceneByNameProgress(scene_name, useUI ,callback));
    }

    IEnumerator LoadSceneByNameProgress(string sceneKey, bool useUI, Action<bool> callback)
    {
        if (useUI)
        {
            ui_object.SetActive(true);
            yield return null;

            var wait = new WaitForSecondsRealtime(Mathf.Max(0.01f, time_delay));
            var handle = Addressables.LoadSceneAsync(sceneKey, UnityEngine.SceneManagement.LoadSceneMode.Single, false);

            float shown = 0f;
            float plannedStep = time_delay / Mathf.Max(0.1f, totalDuration);

            while (!handle.IsDone)
            {
                var dl = handle.GetDownloadStatus();
                float downloadPct = dl.TotalBytes > 0 ? dl.Percent : 1f;
                float loadPctNorm = Mathf.Clamp01(handle.PercentComplete / 0.9f);
                float real = Mathf.Clamp01(0.3f * downloadPct + 0.7f * loadPctNorm);

                float planned = Mathf.Clamp01(shown + plannedStep);

                float target = Mathf.Min(planned, real - epsilon, 0.95f);

                shown = Mathf.MoveTowards(shown, target, plannedStep);

                if (ui_object && progress_lb && image_progress)
                {
                    progress_lb.text = $"{Mathf.RoundToInt(shown * 100f)}%";
                    image_progress.rectTransform.sizeDelta = new Vector2(width * shown, 42);
                }

                yield return wait;
            }

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError($"[Loader] Failed to load scene: {sceneKey}");
                if (ui_object) 
                    ui_object.SetActive(false);
                callback?.Invoke(false);
                yield break;
            }

            var activateOp = handle.Result.ActivateAsync();
            float actElapsed = 0f;

            while (!activateOp.isDone)
            {
                actElapsed += time_delay;

                float timeGate = 0.95f + 0.04f * Mathf.Clamp01(actElapsed / Mathf.Max(0.1f, activationDuration));

                float real = 0.95f + 0.05f * activateOp.progress;

                float target = Mathf.Min(timeGate, real, 0.99f);

                shown = Mathf.MoveTowards(shown, target, maxStepPerTick);

                if (ui_object && progress_lb && image_progress)
                {
                    progress_lb.text = $"{Mathf.RoundToInt(shown * 100f)}%";
                    image_progress.rectTransform.sizeDelta = new Vector2(width * shown, 42);
                }

                yield return wait;
            }

            float finishElapsed = 0f, finishDuration = 0.25f;
            while (shown < 1f)
            {
                finishElapsed += time_delay;
                float finishGate = 0.99f + 0.01f * Mathf.Clamp01(finishElapsed / Mathf.Max(0.05f, finishDuration));
                shown = Mathf.MoveTowards(shown, finishGate, maxStepPerTick);

                if (ui_object && progress_lb && image_progress)
                {
                    progress_lb.text = $"{Mathf.RoundToInt(shown * 100f)}%";
                    image_progress.rectTransform.sizeDelta = new Vector2(width * shown, 42);
                }
                yield return wait;
            }

            yield return wait;

            if (ui_object)
                ui_object.SetActive(false);
            callback?.Invoke(true);
        }
        else
        {
            var handle = Addressables.LoadSceneAsync(sceneKey, UnityEngine.SceneManagement.LoadSceneMode.Single, false);

            yield return handle;

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                callback?.Invoke(false);
                yield break;
            }

            var activateOp = handle.Result.ActivateAsync();
            yield return activateOp;

            yield return null;

            callback?.Invoke(true);
        }
    }
}
