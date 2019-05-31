using Ekip.Framework.Entities;

namespace Ekip.Framework.Core
{
    public static class ClientExtensions
    {
        public static bool HasChanged(this Client client)
        {
            var clientChanged = client.HasDataChanged();
            var addressChanged = client.AddressIdSource.HasDataChanged();
            var motherChanged = client.MotherIdSource.HasDataChanged();
            var fatherChanged = client.FatherIdSource.HasDataChanged();
            return clientChanged || addressChanged || motherChanged || fatherChanged;
        }
    }
}
