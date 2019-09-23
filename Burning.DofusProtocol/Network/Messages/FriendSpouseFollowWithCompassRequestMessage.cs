using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FriendSpouseFollowWithCompassRequestMessage : NetworkMessage
  {
    public const uint Id = 5606;
    public bool enable;

    public override uint MessageId
    {
      get
      {
        return 5606;
      }
    }

    public FriendSpouseFollowWithCompassRequestMessage()
    {
    }

    public FriendSpouseFollowWithCompassRequestMessage(bool enable)
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
