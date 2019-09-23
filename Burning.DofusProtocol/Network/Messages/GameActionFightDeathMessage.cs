using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightDeathMessage : AbstractGameActionMessage
  {
    public new const uint Id = 1099;
    public double targetId;

    public override uint MessageId
    {
      get
      {
        return 1099;
      }
    }

    public GameActionFightDeathMessage()
    {
    }

    public GameActionFightDeathMessage(uint actionId, double sourceId, double targetId)
      : base(actionId, sourceId)
    {
      this.targetId = targetId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameActionFightDeathMessage.targetId.");
    }
  }
}
