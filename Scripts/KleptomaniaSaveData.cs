using UnityEngine;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop;
using DaggerfallWorkshop.Utility;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using System;
using System.Collections.Generic;

namespace Kleptomania
{
    public class StolenMarkerData
    {
        public ulong loadID;
        public Vector3 curPos;
        public int texArc;
        public int texRec;
    }

    [FullSerializer.fsObject("v1")]
    public class KleptomaniaSaveData : IHasModSaveData
    {
        public Dictionary<ulong, StolenMarkerData> StolenMarkers;

        public Type SaveDataType
        {
            get { return typeof(KleptomaniaSaveData); }
        }

        public object NewSaveData()
        {
            KleptomaniaSaveData emptyData = new KleptomaniaSaveData();
            emptyData.StolenMarkers = new Dictionary<ulong, StolenMarkerData>();
            return emptyData;
        }

        public object GetSaveData()
        {
            Dictionary<ulong, StolenMarkerData> markerEntries = new Dictionary<ulong, StolenMarkerData>();

            if (GameManager.Instance.PlayerEnterExit.IsPlayerInsideDungeon || GameManager.Instance.PlayerEnterExit.IsPlayerInsideBuilding)
            {
                KleptomaniaStolenMarker[] allMarkers = GameObject.FindObjectsOfType<KleptomaniaStolenMarker>();
                List<KleptomaniaStolenMarker> validMarkerList = new List<KleptomaniaStolenMarker>();
                for (int i = 0; i < allMarkers.Length; i++)
                {
                    if (allMarkers[i].LoadID > 0 && allMarkers[i].TextureArchive > -1 && allMarkers[i].TextureRecord > -1)
                    {
                        validMarkerList.Add(allMarkers[i]);
                    }
                }

                for (int i = 0; i < validMarkerList.Count; i++)
                {
                    StolenMarkerData marker = new StolenMarkerData
                    {
                        loadID = validMarkerList[i].LoadID,
                        curPos = validMarkerList[i].transform.position,
                        texArc = validMarkerList[i].TextureArchive,
                        texRec = validMarkerList[i].TextureRecord
                    };

                    if (marker != null)
                        markerEntries.Add(marker.loadID, marker);
                }
            }

            KleptomaniaSaveData data = new KleptomaniaSaveData();
            data.StolenMarkers = markerEntries;
            return data;
        }

        public void RestoreSaveData(object dataIn)
        {
            KleptomaniaSaveData data = (KleptomaniaSaveData)dataIn;
            Dictionary<ulong, StolenMarkerData> stolenMarkers = data.StolenMarkers;

            if (GameManager.Instance.PlayerEnterExit.IsPlayerInsideDungeon || GameManager.Instance.PlayerEnterExit.IsPlayerInsideBuilding)
            {
                foreach (KeyValuePair<ulong, StolenMarkerData> marker in stolenMarkers)
                {
                    if (marker.Value.loadID <= 0)
                        continue;

                    AddStolenMarkerToSceneFromSave(marker.Value);

                    // This is here to try and prevent the flat objects that were stolen by the player from respawning when loading saves.
                    List<GameObject> validStolenObjs = new List<GameObject>();
                    Vector3 boxDimVector = new Vector3(0.1f, 1.0f, 0.1f) * 2f;
                    Collider[] overlaps = Physics.OverlapBox(marker.Value.curPos, boxDimVector, new Quaternion(0,0,0,0), KleptomaniaMain.PlayerLayerMask);

                    for (int r = 0; r < overlaps.Length; r++)
                    {
                        GameObject go = overlaps[r].gameObject;

                        if (go == null)
                            continue;

                        if (go.GetComponent<KleptomaniaStolenMarker>()) // Ignore any gameobjects with "KleptomaniaStolenMarker" attached to them
                            continue;

                        if (go.name == "CombinedModels") // Ignore the entire combinedmodels gameobject
                            continue;

                        DaggerfallBillboard billBoard = go.GetComponent<DaggerfallBillboard>(); // Will have to test and eventually account for mods like "Handpainted Models" etc.
                        if (billBoard)
                        {
                            if (marker.Value.texArc != billBoard.Summary.Archive) { continue; }
                            if (marker.Value.texRec != billBoard.Summary.Record) { continue; }
                        }
                        else
                            continue;

                        if (!KleptomaniaMain.WithinMarginOfErrorPos(marker.Value.curPos, billBoard.transform.position, 0.2f, 2.0f, 0.2f))
                            continue;

                        if (!validStolenObjs.Contains(go))
                        {
                            validStolenObjs.Add(go);
                            //Debug.LogFormat("Box overlapped valid GameObject, {0}", go.name);
                        }
                    }

                    if (validStolenObjs.Count > 0)
                    {
                        validStolenObjs[0].SetActive(false); // Disables the first valid gameobject within range and sharing similar properties to the "KleptomaniaStolenMarker"
                    }
                }
            }
        }

        public static void AddStolenMarkerToSceneFromSave(StolenMarkerData data)
        {
            if (data.loadID <= 0)
                return;

            ulong loadID = data.loadID;
            string markerName = "Kleptomania_Marker-" + loadID;
            GameObject go = new GameObject(markerName);
            go.transform.parent = GameObjectHelper.GetBestParent();
            go.transform.position = data.curPos;

            KleptomaniaStolenMarker marker = go.AddComponent<KleptomaniaStolenMarker>();
            marker.LoadID = loadID;
            marker.TextureArchive = data.texArc;
            marker.TextureRecord = data.texRec;
        }
    }
}
