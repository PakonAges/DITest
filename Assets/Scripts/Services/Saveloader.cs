using UnityEngine;
using FlatBuffers;
using System.IO;
using System;
using DITest.Save;

public class Saveloader {

    Player _player;
    CubesHolderSO _cubesHolder;

    public Saveloader(Player player, CubesHolderSO cubesHolderSO) {
        _player = player;
        _cubesHolder = cubesHolderSO;
        LoadProfile();

        _player.IncrementSessionsCounter();

    }

    public void SaveProfile() {
        var builder = new FlatBufferBuilder(1);

        StringOffset saveDate = builder.CreateString(DateTime.Now.ToString());
        var cbs = new Offset<CubeData>[_cubesHolder.Cubes.Count];

        //Cubes Data
        if (_cubesHolder.Cubes.Count != 0) {


            for (int i = _cubesHolder.Cubes.Count - 1; i >= 0; i--) {
                var cubePos = Vec3.CreateVec3(builder, _cubesHolder.Cubes[i].Position.x, _cubesHolder.Cubes[i].Position.y, _cubesHolder.Cubes[i].Position.z);
                var cubesScale = _cubesHolder.Cubes[i].Scale;
                var cubesScr = (short)_cubesHolder.Cubes[i].Scr;

                CubeData.StartCubeData(builder);
                CubeData.AddPosition(builder, cubePos);
                CubeData.AddScale(builder, cubesScale);
                CubeData.AddScr(builder, cubesScr);

                var _cube = CubeData.EndCubeData(builder);
                cbs[i] = _cube;
                builder.Finish(_cube.Value);
            }

        }

        var cubesToSave = PlayerData.CreateCubesVector(builder, cbs);

        //Player Data
        PlayerData.StartPlayerData(builder);
        PlayerData.AddDate(builder, saveDate);
        PlayerData.AddSessions(builder, _player.TotalSessions);
        PlayerData.AddCubes(builder, cubesToSave);

        var playerOffset = PlayerData.EndPlayerData(builder);

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

        for (int i = 0; i < data.CubesLength; i++) {
            var pos = new Vector3(data.Cubes(i).Value.Position.Value.X, data.Cubes(i).Value.Position.Value.Y, data.Cubes(i).Value.Position.Value.Z);
            var scale = data.Cubes(i).Value.Scale;
            var scr = data.Cubes(i).Value.Scr;

            _cubesHolder.Cubes.Add(new CubesHolderSO.CubeData(pos,scale, (SpawnSource)scr));
        }

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
