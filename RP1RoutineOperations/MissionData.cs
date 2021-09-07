using KerbalConstructionTime;
namespace RP1RoutineOperations
{
	public class MissionData
	{
		/// <summary>
		/// The path of the file storing the confignode of the BuildListVessel.
		/// Is null if no valid vessel has yet been stored into it.
		/// </summary>
		public string VesselStoragePath => vesselStored ? Utils.SaveDir + "/" + Id : null;
		public int Id { get; set; }

		private bool vesselStored = false;

		private MissionData(int id)
		{
			Id = id;
		}

		/// <summary>
		/// Initializes a MissionData instance and saves the vessel data into a config node.
		/// The path on disk of the config node is stored into VesselStoragePath.
		/// </summary>
		/// <param name="vesselData"></param>
		/// <returns></returns>
		public static MissionData Create(BuildListVessel vesselData)
		{
			var data = new MissionData(vesselData.GetShip().GetHashCode());

			var storageItem = new BuildListStorageItem();
			storageItem.FromBuildListVessel(vesselData);

			var cnTemp = new ConfigNode("RoutineOpsVesselStorage");
			cnTemp = ConfigNode.CreateConfigFromObject(storageItem, cnTemp);
			var shipNode = new ConfigNode("ShipNode");
			vesselData.ShipNode.CopyTo(shipNode);
			cnTemp.AddNode(shipNode);

			data.vesselStored = cnTemp.Save(data.VesselStoragePath);

			return data;
		}
	}
}
