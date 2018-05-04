﻿using UnityEngine;
using FlatBuffers;
using System.IO;
using System;

public class Saveloader {

    Player _player;

    public Saveloader(Player player) {
        _player = player;
        LoadProfile();

        _player.IncrementSessionsCounter();

    }

    public void SaveProfile() {
        var builder = new FlatBufferBuilder(1);

        StringOffset saveDate = builder.CreateString(DateTime.Now.ToString());

        PlayerData.StartPlayerData(builder);
        PlayerData.AddDate(builder, saveDate);
        PlayerData.AddSessions(builder, _player.TotalSessions);
        var playerOffset = PlayerData.EndPlayerData(builder);

        //builder.Finish(playerOffset.Value);
        PlayerData.FinishPlayerDataBuffer(builder, playerOffset);

        var buf = builder.DataBuffer;

        File.WriteAllBytes("PlayerSave.pron", builder.SizedByteArray());
        Debug.Log("SAVED !");
    }

    public void LoadProfile() {
        if (!File.Exists("PlayerSave.pron")) {
            Debug.Log("New player detected, Creating profile");
            SaveProfile();
        }

        if (!File.Exists("PlayerSave.pron")) throw new Exception("Load failed : 'PlayerSave.pron' not exis, something went wrong");

        ByteBuffer bb = new ByteBuffer(File.ReadAllBytes("PlayerSave.pron"));

        //if (!PlayerData.PlayerDataBufferHasIdentifier(bb)) {
        //    throw new Exception("Identifier test failed, you sure the identifier is identical to the generated schema's one?");
        //}

        PlayerData data = PlayerData.GetRootAsPlayerData(bb);

        _player.TotalSessions = data.Sessions;
        _player.SaveDate = data.Date;

        Debug.Log("Loaded: " + data.Sessions + " sessions");
    }

    public void ResetProfile() {
        if (File.Exists("PlayerSave.pron")) {
            Debug.Log("Should reset Profile now");
            File.Delete("PlayerSave.pron");
        }
        else {
            Debug.Log("I am trying to delete non-existing save-file:(");
        }
    }

}
