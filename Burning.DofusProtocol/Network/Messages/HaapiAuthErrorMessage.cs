using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HaapiAuthErrorMessage : NetworkMessage
  {
    public const uint Id = 6768;
    public uint type;

    public override uint MessageId
    {
      get
      {
        return 6768;
      }
    }

    public HaapiAuthErrorMessage()
    {
    }

    public HaapiAuthErrorMessage(uint type)
    {
      this.type = type;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.type);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.type = (uint) reader.ReadByte();
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element of HaapiAuthErrorMessage.type.");
    }
  }
}
