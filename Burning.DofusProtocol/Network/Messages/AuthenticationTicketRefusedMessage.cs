using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AuthenticationTicketRefusedMessage : NetworkMessage
  {
    public const uint Id = 112;

    public override uint MessageId
    {
      get
      {
        return 112;
      }
    }

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
  }
}
