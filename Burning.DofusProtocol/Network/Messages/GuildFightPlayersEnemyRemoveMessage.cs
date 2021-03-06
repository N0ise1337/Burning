using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildFightPlayersEnemyRemoveMessage : NetworkMessage
  {
    public const uint Id = 5929;
    public double fightId;
    public double playerId;

    public override uint MessageId
    {
      get
      {
        return 5929;
      }
    }

    public GuildFightPlayersEnemyRemoveMessage()
    {
    }

    public GuildFightPlayersEnemyRemoveMessage(double fightId, double playerId)
    {
      this.fightId = fightId;
      this.playerId = playerId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fightId < 0.0 || this.fightId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteDouble(this.fightId);
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightId = reader.ReadDouble();
      if (this.fightId < 0.0 || this.fightId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of GuildFightPlayersEnemyRemoveMessage.fightId.");
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of GuildFightPlayersEnemyRemoveMessage.playerId.");
    }
  }
}
