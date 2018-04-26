// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::FlatBuffers;

public struct PlayerData : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static PlayerData GetRootAsPlayerData(ByteBuffer _bb) { return GetRootAsPlayerData(_bb, new PlayerData()); }
  public static PlayerData GetRootAsPlayerData(ByteBuffer _bb, PlayerData obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public static bool PlayerDataBufferHasIdentifier(ByteBuffer _bb) { return Table.__has_identifier(_bb, "PRON"); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public PlayerData __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public short Sessions { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetShort(o + __p.bb_pos) : (short)0; } }

  public static Offset<PlayerData> CreatePlayerData(FlatBufferBuilder builder,
      short sessions = 0) {
    builder.StartObject(1);
    PlayerData.AddSessions(builder, sessions);
    return PlayerData.EndPlayerData(builder);
  }

  public static void StartPlayerData(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddSessions(FlatBufferBuilder builder, short sessions) { builder.AddShort(0, sessions, 0); }
  public static Offset<PlayerData> EndPlayerData(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<PlayerData>(o);
  }
  public static void FinishPlayerDataBuffer(FlatBufferBuilder builder, Offset<PlayerData> offset) { builder.Finish(offset.Value, "PRON"); }
  public static void FinishSizePrefixedPlayerDataBuffer(FlatBufferBuilder builder, Offset<PlayerData> offset) { builder.FinishSizePrefixed(offset.Value, "PRON"); }
};
