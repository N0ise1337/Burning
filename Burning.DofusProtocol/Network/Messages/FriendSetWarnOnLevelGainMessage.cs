using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FriendSetWarnOnLevelGainMessage : NetworkMessage
  {
    public const uint Id = 6077;
    public bool enable;

    public override uint MessageId
    {
      get
      {
        return 6077;
      }
    }

    public FriendSetWarnOnLevelGainMessage()
    {
    }

    public FriendSetWarnOnLevelGainMessage(bool enable)
    {
      this.enable = enable;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.enable);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.enable = reader.ReadBoolean();
    }
  }
}
