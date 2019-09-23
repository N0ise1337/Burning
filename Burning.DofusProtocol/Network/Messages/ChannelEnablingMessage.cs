using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChannelEnablingMessage : NetworkMessage
  {
    public const uint Id = 890;
    public uint channel;
    public bool enable;

    public override uint MessageId
    {
      get
      {
        return 890;
      }
    }

    public ChannelEnablingMessage()
    {
    }

    public ChannelEnablingMessage(uint channel, bool enable)
    {
      this.channel = channel;
      this.enable = enable;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.channel);
      writer.WriteBoolean(this.enable);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.channel = (uint) reader.ReadByte();
      if (this.channel < 0U)
        throw new Exception("Forbidden value (" + (object) this.channel + ") on element of ChannelEnablingMessage.channel.");
      this.enable = reader.ReadBoolean();
    }
  }
}
