namespace SIMSApi
{
  
    public class ProductInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Payload { get; set; }
        public string ReachRange { get; set; }
        public List<string> Applications { get; set; }
        public List<string> Specialties { get; set; }
        public List<string> Features { get; set; }
        public List<string> TreatmentAreas { get; set; }
        public string Accuracy { get; set; }
        public string Wingspan { get; set; }
        public string Endurance { get; set; }
        public List<string> Sensors { get; set; } 
        public string Weight { get; set; }
        public string Speed { get; set; } 
        public List<string> Procedures { get; set; }
        public string Armament { get; set; }

        public string License { get; set; }
        public string LicenseDetails { get; set; }
    }

    public class RepairInstructions
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public List<string> Instructions { get; set; }
    }

    public class BillOfMaterialsItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Features { get; set; }
        public decimal Cost { get; set; }
        public List<string> Materials { get; set; }
    }
    public class CADModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Dimensions { get; set; }
        public string Weight { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public string Manufacturer { get; set; }
        public string PartNumber { get; set; }
        public string FileFormat { get; set; }
        public string ModelType { get; set; }


    }

    public class ProductLicenseInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string License { get; set; }
        public string LicenseDetails { get; set; }
    }
    public class SafetyInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string SafetyFeatures { get; set; }
        public string SafetyInstructions { get; set; }
    }

}
