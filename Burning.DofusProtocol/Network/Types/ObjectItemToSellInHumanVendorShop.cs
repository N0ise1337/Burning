using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectItemToSellInHumanVendorShop : Item
  {
    public List<ObjectEffect> effects = new List<ObjectEffect>();
    public new const uint Id = 359;
    public uint objectGID;
    public uint objectUID;
    public uint quantity;
    public double objectPrice;
    public double publicPrice;

    public override uint TypeId
    {
      get
      {
        return 359;
      }
    }

    public ObjectItemToSellInHumanVendorShop()
    {
    }

    public ObjectItemToSellInHumanVendorShop(
      uint objectGID,
      List<ObjectEffect> effects,
      uint objectUID,
      uint quantity,
      double objectPrice,
      double publicPrice)
    {
      this.objectGID = objectGID;
      this.effects = effects;
      this.objectUID = objectUID;
      this.quantity = quantity;
      this.objectPrice = objectPrice;
      this.publicPrice = publicPrice;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element objectGID.");
      writer.WriteVarShort((short) this.objectGID);
      writer.WriteShort((short) this.effects.Count);
      for (int index = 0; index < this.effects.Count; ++index)
      {
        writer.WriteShort((short) this.effects[index].TypeId);
        this.effects[index].Serialize(writer);
      }
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element objectUID.");
      writer.WriteVarInt((int) this.objectUID);
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element quantity.");
      writer.WriteVarInt((int) this.quantity);
      if (this.objectPrice < 0.0 || this.objectPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.objectPrice + ") on element objectPrice.");
      writer.WriteVarLong((long) this.objectPrice);
      if (this.publicPrice < 0.0 || this.publicPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.publicPrice + ") on element publicPrice.");
      writer.WriteVarLong((long) this.publicPrice);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.objectGID = (uint) reader.ReadVarUhShort();
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element of ObjectItemToSellInHumanVendorShop.objectGID.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectEffect instance = ProtocolTypeManager.GetInstance<ObjectEffect>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.effects.Add(instance);
      }
      this.objectUID = reader.ReadVarUhInt();
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element of ObjectItemToSellInHumanVendorShop.objectUID.");
      this.quantity = reader.ReadVarUhInt();
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element of ObjectItemToSellInHumanVendorShop.quantity.");
      this.objectPrice = (double) reader.ReadVarUhLong();
      if (this.objectPrice < 0.0 || this.objectPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.objectPrice + ") on element of ObjectItemToSellInHumanVendorShop.objectPrice.");
      this.publicPrice = (double) reader.ReadVarUhLong();
      if (this.publicPrice < 0.0 || this.publicPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.publicPrice + ") on element of ObjectItemToSellInHumanVendorShop.publicPrice.");
    }
  }
}
