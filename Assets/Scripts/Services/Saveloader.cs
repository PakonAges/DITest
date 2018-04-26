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
    }

    public void SaveProfile() {
        FlatBufferBuilder fbb = new FlatBufferBuilder(1);

        PlayerData.StartPlayerData(fbb);
        PlayerData.AddSessions(fbb, _player.TotalSessions);
        Offset<PlayerData> offsetPlayerData = PlayerData.EndPlayerData(fbb);

        PlayerData.FinishPlayerDataBuffer(fbb, offsetPlayerData);

        using (var ms = new MemoryStream(fbb.SizedByteArray(), fbb.DataBuffer.Position, fbb.Offset)) {
            File.WriteAllBytes("PlayerSave.pron", ms.ToArray());
            Debug.Log("SAVED !");
        }
    }

    public void LoadProfile() {
        if (!File.Exists("PlayerSave.pron")) throw new Exception("Load failed : 'PlayerSave.pron' not exis, something went wrong");

        ByteBuffer bb = new ByteBuffer(File.ReadAllBytes("PlayerSave.pron"));

        if (!PlayerData.PlayerDataBufferHasIdentifier(bb)) {
            throw new Exception("Identifier test failed, you sure the identifier is identical to the generated schema's one?");
        }

        PlayerData data = PlayerData.GetRootAsPlayerData(bb);
        _player.TotalSessions = data.Sessions;
        Debug.Log("Loaded: " + data.Sessions + " sessions");
    }
	
}
