using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectsAddedMessage : NetworkMessage
  {
    public List<ObjectItem> @object = new List<ObjectItem>();
    public const uint Id = 6033;

    public override uint MessageId
    {
      get
      {
        return 6033;
      }
    }

    public ObjectsAddedMessage()
    {
    }

    public ObjectsAddedMessage(List<ObjectItem> @object)
    {
      this.@object = @object;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.@object.Count);
      for (int index = 0; index < this.@object.Count; ++index)
        this.@object[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectItem objectItem = new ObjectItem();
        objectItem.Deserialize(reader);
        this.@object.Add(objectItem);
      }
    }
  }
}
