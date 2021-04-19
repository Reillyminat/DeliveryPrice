namespace AppliancesModel
{
    public interface IOutputInputHandler
    {
        public void SelectApplianceToAdd(out int inputType, out int inputCount);

        public void SetApplianceProperties(out string name, out int guarantee, out Dimensions dimensions, out decimal price, out string producingCountry);

        public void SetWasherProperties(out int waterConsuming, out int maximumLoad);

        public void SetRefrigeratorProperties(out int totalVolume, out bool containsFreezer);

        public void SetKitchenStoveProperties(out bool combinedGasElectric, out bool containsOven);

        public void ShowStockNumbers(int washerCount, int refrigeratorCount, int kitchenStoveCount);

        public int CheckIntInput(string article, int lowerBound, int upperBound);

        public bool CheckBoolInput(string article);
    }
}
