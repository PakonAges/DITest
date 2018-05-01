using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;
using System.IO;
using System;

public class Saveloader {

    Player _player;

    public Saveloader(Player player) {
        _player = player;
        LoadProfile();

        _player.TotalSessions++;

    }

    public void SaveProfile() {
        var builder = new FlatBufferBuilder(1024);

        PlayerData.StartPlayerData(builder);
        PlayerData.AddSessions(builder, (short)_player.TotalSessions);
        var player = PlayerData.EndPlayerData(builder);

        builder.Finish(player.Value);

        var buf = builder.DataBuffer;
        //byte[] buf = builder.SizedByteArray();

        using (var ms = new MemoryStream(builder.SizedByteArray(), buf.Position, builder.Offset)) {
            File.WriteAllBytes("PlayerSave.pron", ms.ToArray());
            Debug.Log("SAVED !");
        }

        //FlatBufferBuilder fbb = new FlatBufferBuilder(1024);

        //PlayerData.StartPlayerData(fbb);
        //PlayerData.AddSessions(fbb, _player.TotalSessions);
        //Offset<PlayerData> offsetPlayerData = PlayerData.EndPlayerData(fbb);

        //PlayerData.FinishPlayerDataBuffer(fbb, offsetPlayerData);

        ////var buf = fbb.DataBuffer;
        //byte[] buf = fbb.SizedByteArray();

        //using (var ms = new MemoryStream(buf, fbb.DataBuffer.Position, fbb.Offset)) {
        //    File.WriteAllBytes("PlayerSave.pron", ms.ToArray());
        //    Debug.Log("SAVED !");
        //}
    }

    public void LoadProfile() {
        if (!File.Exists("PlayerSave.pron")) {
            Debug.Log("New player detected, Creating profile");
            SaveProfile();
        }
            

        if (!File.Exists("PlayerSave.pron")) throw new Exception("Load failed : 'PlayerSave.pron' not exis, something went wrong");

        ByteBuffer bb = new ByteBuffer(File.ReadAllBytes("PlayerSave.pron"));

        if (!PlayerData.PlayerDataBufferHasIdentifier(bb)) {
            throw new Exception("Identifier test failed, you sure the identifier is identical to the generated schema's one?");
        }

        PlayerData data = PlayerData.GetRootAsPlayerData(bb);
        _player.TotalSessions = data.Sessions;
        Debug.Log("Loaded: " + data.Sessions + " sessions");


        //if (!File.Exists("PlayerSave.pron")) throw new Exception("Load failed : 'PlayerSave.pron' not exis, something went wrong");

        //ByteBuffer bb = new ByteBuffer(File.ReadAllBytes("PlayerSave.pron"));

        //if (!PlayerData.PlayerDataBufferHasIdentifier(bb)) {
        //    throw new Exception("Identifier test failed, you sure the identifier is identical to the generated schema's one?");
        //}

        //PlayerData data = PlayerData.GetRootAsPlayerData(bb);
        //_player.TotalSessions = data.Sessions;
        //Debug.Log("Loaded: " + data.Sessions + " sessions");
    }

}
