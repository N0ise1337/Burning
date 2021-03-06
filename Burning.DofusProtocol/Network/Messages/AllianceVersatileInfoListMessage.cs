using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceVersatileInfoListMessage : NetworkMessage
  {
    public List<AllianceVersatileInformations> alliances = new List<AllianceVersatileInformations>();
    public const uint Id = 6436;

    public override uint MessageId
    {
      get
      {
        return 6436;
      }
    }

    public AllianceVersatileInfoListMessage()
    {
    }

    public AllianceVersatileInfoListMessage(List<AllianceVersatileInformations> alliances)
    {
      this.alliances = alliances;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.alliances.Count);
      for (int index = 0; index < this.alliances.Count; ++index)
        this.alliances[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        AllianceVersatileInformations versatileInformations = new AllianceVersatileInformations();
        versatileInformations.Deserialize(reader);
        this.alliances.Add(versatileInformations);
      }
    }
  }
}
