using Microsoft.AspNetCore.Mvc;
using SIMSApi;

namespace SIMSApi.Controllers
{



    [ApiController]
    [Route("api/[controller]")]
    public class AssetsController : ControllerBase
    {
        private readonly ILogger<AssetsController> _logger;
        private readonly List<ProductInfo> _products;

        public AssetsController(ILogger<AssetsController> logger)
        {
            _products = new List<ProductInfo>
        {
            new ProductInfo { Id = 1, Name = "ABB IRB 6700", Category = "Industrial Robots", Description = "High-performance large payload industrial robot", Payload = "150-300 kg", ReachRange = "2.6-3.2 m", Applications = new List<string> { "Material handling", "Machine tending", "Spot welding" },  License = "Commercial",
        LicenseDetails = "License required for industrial usage. Annual renewal." },
            new ProductInfo { Id = 2, Name = "KUKA KR AGILUS", Category = "Industrial Robots", Description = "Compact and fast small robot", Payload = "6-10 kg", ReachRange = "700-1100 mm", Applications = new List<string> { "Assembly", "Handling", "Pick and place" },        License = "Commercial",
        LicenseDetails = "License required for industrial usage. One-time fee." },
            new ProductInfo { Id = 3, Name = "Da Vinci Surgical System", Category = "Medical Robots", Description = "Robotic surgical system for minimally invasive procedures", Specialties = new List<string> { "Urology", "Gynecology", "General surgery" }, Features = new List<string> { "3D HD vision", "Wristed instruments", "Ergonomic design" }, License = "Medical",
        LicenseDetails = "Medical license required for surgery. Strict regulatory requirements." },
            new ProductInfo { Id = 4, Name = "CyberKnife", Category = "Medical Robots", Description = "Robotic radiosurgery system", TreatmentAreas = new List<string> { "Brain", "Spine", "Lung" }, Accuracy = "Sub-millimeter", Features = new List<string> { "Real-time tumor tracking", "Non-invasive" }, License = "Medical",
        LicenseDetails = "FDA approval required for use in hospitals. High-cost licensing." },
            new ProductInfo { Id = 5, Name = "Predator Drone", Category = "Military Robots", Description = "Unmanned aerial vehicle for reconnaissance and strike missions", Wingspan = "20 m", Endurance = "24+ hours", Payload = "1,700 kg", Sensors = new List<string> { "Electro-optical", "Infrared", "Synthetic aperture radar" },License = "Military",
        LicenseDetails = "Military clearance required for operation. Classified license." },
            new ProductInfo { Id = 6, Name = "PackBot", Category = "Military Robots", Description = "Tactical mobile robot for dangerous missions", Weight = "18 kg", Speed = "9.3 km/h", Applications = new List<string> { "Explosive ordnance disposal", "Reconnaissance", "HazMat handling" }, License = "Military",
        LicenseDetails = "Military authorization required for use. Secure operation license." },
            new ProductInfo { Id = 7, Name = "Universal Robots UR5e", Category = "Industrial Robots", Description = "Collaborative robot for flexible automation", Payload = "5 kg", ReachRange = "850 mm", Features = new List<string> { "Easy programming", "Safe human-robot collaboration", "Flexible deployment" },  License = "Commercial",
        LicenseDetails = "Commercial license required for industrial operations." },
            new ProductInfo { Id = 8, Name = "MAKO Robotic Arm", Category = "Medical Robots", Description = "Robotic arm for orthopedic surgery", Procedures = new List<string> { "Total knee replacement", "Total hip replacement", "Partial knee replacement" }, Features = new List<string> { "Haptic technology", "3D CT-based planning", "Accurate implant positioning" },  License = "Medical",
        LicenseDetails = "Requires medical license and hospital accreditation." },
            new ProductInfo { Id = 9, Name = "BigDog", Category = "Military Robots", Description = "Quadruped robot for rough terrain", Speed = "6.4 km/h", Payload = "150 kg", Features = new List<string> { "Dynamic balancing", "All-terrain capability", "Autonomous navigation" },License = "Military",
        LicenseDetails = "Restricted to military use only. Security clearance required." },
            new ProductInfo { Id = 10, Name = "TALON", Category = "Military Robots", Description = "Tracked military robot for dangerous missions", Weight = "52 kg", Speed = "8.3 km/h", Applications = new List<string> { "Explosive ordnance disposal", "Reconnaissance", "Communications" },        License = "Military",
        LicenseDetails = "License for military use only. Clearance required." },
            new ProductInfo { Id = 11, Name = "FANUC R-2000iC", Category = "Industrial Robots", Description = "Versatile industrial robot for heavy payload handling", Payload = "100-270 kg", ReachRange = "2.4-3.1 m", Applications = new List<string> { "Palletizing", "Machine tending", "Material removal" } ,        License = "Commercial",
        LicenseDetails = "Commercial license required for industrial use."},
            new ProductInfo { Id = 12, Name = "Yaskawa Motoman HC20DT", Category = "Industrial Robots", Description = "Collaborative robot for human-robot interaction", Payload = "20 kg", ReachRange = "1.9 m", Features = new List<string> { "Power and force limiting", "Hand-guiding", "Easy programming" } ,        License = "Commercial",
        LicenseDetails = "Standard industrial license. Available for purchase."},
            new ProductInfo { Id = 13, Name = "Versius", Category = "Medical Robots", Description = "Modular robotic system for minimal access surgery", Specialties = new List<string> { "Gynecology", "Urology", "Upper GI" }, Features = new List<string> { "Biomimicking joint configuration", "3D HD visualization", "Open console design" },     License = "Medical",
        LicenseDetails = "Requires medical licensing and hospital accreditation." },
            new ProductInfo { Id = 14, Name = "ROSATM", Category = "Medical Robots", Description = "Robotic surgical assistant for brain and spine procedures", Applications = new List<string> { "Neurosurgery", "Spine surgery" }, Features = new List<string> { "Frameless stereotaxy", "Intraoperative imaging integration", "Minimally invasive approach" },      License = "Medical",
        LicenseDetails = "Medical use only with FDA approval." },
            new ProductInfo { Id = 15, Name = "SWORDS", Category = "Military Robots", Description = "Special Weapons Observation Reconnaissance Detection System", Weight = "27 kg", Armament = "M249 light machine gun", Features = new List<string> { "Remote operation", "All-terrain mobility", "Weapon stabilization" } ,   License = "Military",
        LicenseDetails = "Restricted to military use. Special clearance required."}
        };
            _logger = logger;
        }
        [HttpGet("ProductInfo/{id}")]
        public ActionResult<ProductInfo> GetProductInfo(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("RepairInstructions/{id}")]
        public ActionResult<RepairInstructions> GetRepairInstructions(int id)
        {
            var repairInstructionMap = new Dictionary<int, List<string>>
    {
        {
            1, // ABB IRB 6700
            new List<string>
            {
                "Disconnect power and lock out electrical systems",
                "Inspect robot arm joints for wear and lubrication levels",
                "Check calibration of motion encoders using precision laser alignment tool",
                "Clean and replace worn servo motor brushes",
                "Recalibrate end-effector tool center point (TCP) using 3D measurement system"
            }
        },
        {
            2, // KUKA KR AGILUS
            new List<string>
            {
                "Perform comprehensive cable harness inspection",
                "Verify pneumatic system pressure and seal integrity",
                "Clean and realign optical encoders",
                "Replace worn reducer gearbox components",
                "Validate robot path accuracy using laser tracking system"
            }
        },
        {
            3, // Da Vinci Surgical System
            new List<string>
            {
                "Sterilize and disinfect all robotic arm surfaces",
                "Calibrate instrument tracking sensors",
                "Replace worn surgical instrument grippers",
                "Update surgical planning software",
                "Perform comprehensive system diagnostic using manufacturer's toolkit"
            }
        },
        {
            4, // CyberKnife
            new List<string>
            {
                "Align radiation beam collimators",
                "Verify tumor tracking camera calibration",
                "Replace radiation source positioning motors",
                "Perform radiation shielding integrity test",
                "Calibrate patient positioning laser alignment system"
            }
        },
        {
            5, // Predator Drone
            new List<string>
            {
                "Inspect airframe for structural fatigue",
                "Recalibrate navigation and guidance systems",
                "Replace worn propulsion system components",
                "Update satellite communication encryption protocols",
                "Perform comprehensive avionics system diagnostic"
            }
        },
        {
            6, // PackBot
            new List<string>
            {
                "Check tracked mobility system for wear",
                "Inspect and replace battery cell modules",
                "Calibrate environmental sensors",
                "Update remote communication encryption",
                "Verify structural integrity of modular chassis"
            }
        },
        {
            7, // Universal Robots UR5e
            new List<string>
            {
                "Perform collaborative safety system verification",
                "Replace joint friction dampers",
                "Calibrate force-torque sensors",
                "Update robot programming interface",
                "Clean and lubricate cable management systems"
            }
        },
        {
            8, // MAKO Robotic Arm
            new List<string>
            {
                "Verify optical tracking system calibration",
                "Replace surgical arm motion encoders",
                "Update surgical planning algorithms",
                "Perform comprehensive joint lubrication",
                "Validate haptic feedback mechanisms"
            }
        },
        {
            9, // BigDog
            new List<string>
            {
                "Inspect hydraulic actuator seals",
                "Calibrate terrain navigation sensors",
                "Replace suspension system components",
                "Update autonomous navigation algorithms",
                "Verify load-bearing structural integrity"
            }
        },
        {
            10, // TALON
            new List<string>
            {
                "Check tracked mobility system components",
                "Calibrate remote operation communication systems",
                "Replace environmental sensor arrays",
                "Verify explosive ordnance disposal tool functionality",
                "Update mission control software encryption"
            }
        },
        {
            11, // FANUC R-2000iC
            new List<string>
            {
                "Inspect heavy-payload support structures",
                "Replace servo motor windings",
                "Calibrate precision positioning encoders",
                "Perform comprehensive vibration analysis",
                "Update industrial automation interface"
            }
        },
        {
            12, // Yaskawa Motoman HC20DT
            new List<string>
            {
                "Verify human-robot collaboration safety systems",
                "Replace joint torque sensing elements",
                "Calibrate machine vision systems",
                "Update collaborative programming interface",
                "Perform comprehensive motion profile diagnostics"
            }
        },
        {
            13, // Versius
            new List<string>
            {
                "Sterilize surgical robotic arm surfaces",
                "Calibrate 3D visualization systems",
                "Replace surgical instrument attachment mechanisms",
                "Update minimally invasive surgery algorithms",
                "Verify surgeon control interface functionality"
            }
        },
        {
            14, // ROSA
            new List<string>
            {
                "Calibrate neurosurgical navigation systems",
                "Replace optical tracking markers",
                "Verify stereotactic positioning accuracy",
                "Update surgical planning software",
                "Perform comprehensive robotic arm diagnostic"
            }
        },
        {
            15, // SWORDS
            new List<string>
            {
                "Inspect weapon mounting systems",
                "Calibrate remote operation communication protocols",
                "Replace mobility system components",
                "Update mission-critical encryption systems",
                "Verify weapon stabilization mechanisms"
            }
        }
    };

            if (!repairInstructionMap.TryGetValue(id, out var instructions))
            {
                return NotFound();
            }

            var repairInstructions = new RepairInstructions
            {
                ProductId = id,
                ProductName = _products.First(p => p.Id == id).Name,
                Category = _products.First(p => p.Id == id).Category,
                Instructions = instructions
            };

            return Ok(repairInstructions);
        }

        [HttpGet("BillOfMaterials/{id}")]
        public ActionResult<BillOfMaterialsItem> GetBillOfMaterialItem(int id)
        {
            var bomItem = _bomItems.FirstOrDefault(b => b.Id == id);

            if (bomItem == null)
            {
                return NotFound();
            }

            return Ok(bomItem);
        }

        [HttpGet("CADModel/{id}")]
        public ActionResult<BillOfMaterialsItem> GetCADModel(int id)
        {
            var Item = _cadModels.FirstOrDefault(b => b.Id == id);

            if (Item == null)
            {
                return NotFound();
            }

            return Ok(Item);
            
        }
       

        [HttpGet("LicenseInfo/{id}")]
        public ActionResult<ProductLicenseInfo> GetLicenseInfo(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var productLicenseInfo = new ProductLicenseInfo
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                License = product.License,
                LicenseDetails = product.LicenseDetails
            };

            return Ok(productLicenseInfo);
        }
        [HttpGet("SafetyInfo/{id}")]
        public ActionResult<SafetyInfo> GetSafetyInfo(int id)
        {
            var item = _safetyInfoList.FirstOrDefault(s => s.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
        private static List<BillOfMaterialsItem> _bomItems = new List<BillOfMaterialsItem>
{
    new BillOfMaterialsItem
    {
        Id = 1,
        Name = "ABB IRB 6700",
        Category = "Industrial Robots",
        Features = "High payload, high speed, and flexibility",
        Cost = 150000,
        Materials = new List<string> { "Steel", "Electronics", "Hydraulics" }
    },
    new BillOfMaterialsItem
    {
        Id = 2,
        Name = "KUKA KR AGILUS",
        Category = "Industrial Robots",
        Features = "Compact, precise, and agile",
        Cost = 120000,
        Materials = new List<string> { "Aluminum", "Sensors", "Servo Motors" }
    },
    new BillOfMaterialsItem
    {
        Id = 3,
        Name = "Da Vinci Surgical System",
        Category = "Medical Robots",
        Features = "Minimally invasive surgery with robotic assistance",
        Cost = 300000,
        Materials = new List<string> { "Stainless Steel", "Optics", "Medical Electronics" }
    },
    new BillOfMaterialsItem { Id = 4, Name = "CyberKnife", Category = "Medical Robots", Features = "Radiation therapy with precision", Cost = 250000, Materials = new List<string> { "Steel", "Electronics", "Hydraulics" } },
    new BillOfMaterialsItem { Id = 5, Name = "Predator Drone", Category = "Military Robots", Features = "Surveillance and reconnaissance", Cost = 400000, Materials = new List<string> { "Aluminum", "Sensors", "Servo Motors" } },
    new BillOfMaterialsItem { Id = 6, Name = "PackBot", Category = "Military Robots", Features = "Reconnaissance and explosive disposal", Cost = 50000, Materials = new List<string> { "Stainless Steel", "Optics", "Medical Electronics" } },
    new BillOfMaterialsItem { Id = 7, Name = "Universal Robots UR5e", Category = "Industrial Robots", Features = "Collaborative robot with high versatility", Cost = 60000, Materials = new List<string> { "Steel", "Electronics", "Hydraulics" } },
    new BillOfMaterialsItem { Id = 8, Name = "MAKO Robotic Arm", Category = "Medical Robots", Features = "Orthopedic surgery with precision", Cost = 250000 , Materials = new List<string> { "Aluminum", "Sensors", "Servo Motors" }},
    new BillOfMaterialsItem { Id = 9, Name = "BigDog", Category = "Military Robots", Features = "Rough terrain mobility and payload carrying", Cost = 200000, Materials = new List<string> { "Stainless Steel", "Optics", "Medical Electronics" } },
    new BillOfMaterialsItem { Id = 10, Name = "TALON", Category = "Military Robots", Features = "Mobile robot for hazardous environments", Cost = 100000, Materials = new List<string> { "Steel", "Electronics", "Hydraulics" } },
    new BillOfMaterialsItem { Id = 11, Name = "FANUC R-2000iC", Category = "Industrial Robots", Features = "High precision, heavy lifting capacity", Cost = 80000, Materials = new List<string> { "Aluminum", "Sensors", "Servo Motors" } },
    new BillOfMaterialsItem { Id = 12, Name = "Yaskawa Motoman HC20DT", Category = "Industrial Robots", Features = "Collaborative robot with 20kg payload", Cost = 70000, Materials = new List<string> { "Stainless Steel", "Optics", "Medical Electronics" } },
    new BillOfMaterialsItem { Id = 13, Name = "Versius", Category = "Medical Robots", Features = "Surgical robot with flexible arms", Cost = 350000, Materials = new List<string> { "Steel", "Electronics", "Hydraulics" } },
    new BillOfMaterialsItem { Id = 14, Name = "ROSATM", Category = "Medical Robots", Features = "Robotic system for orthopedic procedures", Cost = 200000, Materials = new List<string> { "Aluminum", "Sensors", "Servo Motors" } },
    new BillOfMaterialsItem { Id = 15, Name = "SWORDS", Category = "Military Robots", Features = "Weaponized robot system", Cost = 500000, Materials = new List<string> { "Stainless Steel", "Optics", "Medical Electronics" } }
};
        // Add Materials for remaining items...
    

        public List<SafetyInfo> _safetyInfoList = new List<SafetyInfo>
{
    new SafetyInfo
    {
        Id = 1,
        Name = "ABB IRB 6700",
        Category = "Industrial Robots",
        SafetyFeatures = "Emergency stop button, Collision detection sensors, Operator safety zone.",
        SafetyInstructions = "Ensure proper calibration of safety sensors before operation. Always wear safety gear and avoid entering the robot's operating area."
    },
    new SafetyInfo
    {
        Id = 2,
        Name = "KUKA KR AGILUS",
        Category = "Industrial Robots",
        SafetyFeatures = "Safe Operation Mode, Limited speed settings, Protective covers.",
        SafetyInstructions = "Program robot movements to avoid collisions. Never operate without safety covers and ensure the robot’s path is clear of obstructions."
    },
    new SafetyInfo
    {
        Id = 3,
        Name = "Da Vinci Surgical System",
        Category = "Medical Robots",
        SafetyFeatures = "Real-time monitoring, Precision instrument control, Integrated alarms.",
        SafetyInstructions = "Only trained professionals should operate. Follow sterile procedures and ensure all surgical instruments are secure before use."
    },
    new SafetyInfo
    {
        Id = 4,
        Name = "CyberKnife",
        Category = "Medical Robots",
        SafetyFeatures = "Real-time tumor tracking, Collision-free workspace, Radiation shielding.",
        SafetyInstructions = "Operate within the designated treatment areas. Follow all medical safety protocols and ensure proper calibration before each use."
    },
    new SafetyInfo
    {
        Id = 5,
        Name = "Predator Drone",
        Category = "Military Robots",
        SafetyFeatures = "Secure communication channels, Automatic flight control, GPS-based navigation.",
        SafetyInstructions = "Restricted airspace use. Only authorized military personnel may operate. Pre-flight checks should include communication systems and GPS functionality."
    },
    new SafetyInfo
    {
        Id = 6,
        Name = "PackBot",
        Category = "Military Robots",
        SafetyFeatures = "Remote operation, Shock resistance, Non-lethal deterrence.",
        SafetyInstructions = "Always operate remotely. Ensure the robot's path is clear of obstacles. Avoid areas with extreme hazards unless mission critical."
    },
    new SafetyInfo
    {
        Id = 7,
        Name = "Universal Robots UR5e",
        Category = "Industrial Robots",
        SafetyFeatures = "Force sensing, Safe human-robot interaction, Easy emergency stop.",
        SafetyInstructions = "Ensure safety protocols are followed, and do not manually adjust robot programming during operation. Maintain safe distance from moving parts."
    },
    new SafetyInfo
    {
        Id = 8,
        Name = "MAKO Robotic Arm",
        Category = "Medical Robots",
        SafetyFeatures = "Precise 3D imaging, Feedback-driven operation, Haptic feedback.",
        SafetyInstructions = "Follow all pre-surgical safety steps. Ensure all components are sterile and functioning before initiating procedures."
    },
    new SafetyInfo
    {
        Id = 9,
        Name = "BigDog",
        Category = "Military Robots",
        SafetyFeatures = "Dynamic balancing, Robust mobility, Terrain adaptability.",
        SafetyInstructions = "Ensure secure deployment zones. Avoid operation in hazardous weather conditions and check stability before operation."
    },
    new SafetyInfo
    {
        Id = 10,
        Name = "TALON",
        Category = "Military Robots",
        SafetyFeatures = "Secure communications, Autonomous navigation, All-terrain mobility.",
        SafetyInstructions = "Operate only in authorized zones. Use secure communication channels and inspect all sensors before operation."
    },
    new SafetyInfo
    {
        Id = 11,
        Name = "FANUC R-2000iC",
        Category = "Industrial Robots",
        SafetyFeatures = "Automatic shut-off in case of system failure, Protective fencing, Safety interlock system.",
        SafetyInstructions = "Always monitor the robot’s activity and conduct regular safety checks. Make sure operators are trained and understand emergency stop procedures."
    },
    new SafetyInfo
    {
        Id = 12,
        Name = "Yaskawa Motoman HC20DT",
        Category = "Industrial Robots",
        SafetyFeatures = "Power and force limiting, Safe human interaction, Flexible operation mode.",
        SafetyInstructions = "Use the hand-guiding mode for collaborative tasks. Do not override safety features. Always wear appropriate safety equipment."
    },
    new SafetyInfo
    {
        Id = 13,
        Name = "Versius",
        Category = "Medical Robots",
        SafetyFeatures = "Minimally invasive design, Real-time feedback, Surgical precision.",
        SafetyInstructions = "Only certified personnel should use. Follow all sterilization and safety protocols. Ensure that all surgical instruments are correctly calibrated."
    },
    new SafetyInfo
    {
        Id = 14,
        Name = "ROSATM",
        Category = "Medical Robots",
        SafetyFeatures = "Intraoperative imaging, Accurate navigation, Remote operation capabilities.",
        SafetyInstructions = "Operate with full FDA compliance. Only trained neurosurgeons should use, and all imaging equipment should be tested before the procedure."
    },
    new SafetyInfo
    {
        Id = 15,
        Name = "SWORDS",
        Category = "Military Robots",
        SafetyFeatures = "Remote operation, Secure communication, Weapon stabilization.",
        SafetyInstructions = "Only authorized military personnel may operate. Ensure all communication channels are secure, and perform a pre-mission check on all systems."
    }
};

        private static List<CADModel> _cadModels = new List<CADModel>
{
    new CADModel
    {
        Id = 1,
        Name = "ABB IRB 6700",
        Category = "Industrial Robots",
        Dimensions = "2.3m x 1.5m x 2.5m",
        Weight = "410 kg",
        Material = "Steel",
        Color = "Orange",
        Manufacturer = "ABB Robotics",
        PartNumber = "6700-AB",
        FileFormat = "STL",
        ModelType = "3D Model"
    },
    new CADModel
    {
        Id = 2,
        Name = "KUKA KR AGILUS",
        Category = "Industrial Robots",
        Dimensions = "1.1m x 0.7m x 1.0m",
        Weight = "24 kg",
        Material = "Aluminum",
        Color = "Yellow",
        Manufacturer = "KUKA Robotics",
        PartNumber = "AG-001",
        FileFormat = "STEP",
        ModelType = "3D Model"
    },
    new CADModel
    {
        Id = 3,
        Name = "Da Vinci Surgical System",
        Category = "Medical Robots",
        Dimensions = "1.8m x 1.5m x 1.6m",
        Weight = "600 kg",
        Material = "Titanium, Steel",
        Color = "Silver",
        Manufacturer = "Intuitive Surgical",
        PartNumber = "DVSS-01",
        FileFormat = "IGES",
        ModelType = "3D Model"
    },
    new CADModel
    {
        Id = 4,
        Name = "CyberKnife",
        Category = "Medical Robots",
        Dimensions = "3.5m x 2.0m x 1.8m",
        Weight = "1500 kg",
        Material = "Steel, Aluminum",
        Color = "White, Black",
        Manufacturer = "Accuray",
        PartNumber = "CK-001",
        FileFormat = "STL",
        ModelType = "3D Model"
    },
    new CADModel
    {
        Id = 5,
        Name = "Predator Drone",
        Category = "Military Robots",
        Dimensions = "8.0m x 20.0m x 4.0m",
        Weight = "4500 kg",
        Material = "Aluminum, Carbon Fiber",
        Color = "Gray",
        Manufacturer = "General Atomics",
        PartNumber = "PRED-001",
        FileFormat = "STEP",
        ModelType = "3D Model"
    },
    new CADModel
    {
        Id = 6,
        Name = "PackBot",
        Category = "Military Robots",
        Dimensions = "1.0m x 0.5m x 0.3m",
        Weight = "30 kg",
        Material = "Aluminum, Steel",
        Color = "Black",
        Manufacturer = "iRobot",
        PartNumber = "PB-001",
        FileFormat = "STL",
        ModelType = "3D Model"
    },
    new CADModel
    {
        Id = 7,
        Name = "Universal Robots UR5e",
        Category = "Industrial Robots",
        Dimensions = "1.0m x 0.7m x 1.3m",
        Weight = "25 kg",
        Material = "Aluminum",
        Color = "White",
        Manufacturer = "Universal Robots",
        PartNumber = "UR5e-001",
        FileFormat = "STEP",
        ModelType = "3D Model"
    },
    new CADModel
    {
        Id = 8,
        Name = "MAKO Robotic Arm",
        Category = "Medical Robots",
        Dimensions = "1.5m x 1.0m x 1.2m",
        Weight = "100 kg",
        Material = "Titanium, Stainless Steel",
        Color = "Blue, White",
        Manufacturer = "Stryker",
        PartNumber = "MAKO-01",
        FileFormat = "STL",
        ModelType = "3D Model"
    },
    new CADModel
    {
        Id = 9,
        Name = "BigDog",
        Category = "Military Robots",
        Dimensions = "1.5m x 1.0m x 1.5m",
        Weight = "200 kg",
        Material = "Aluminum, Steel",
        Color = "Green",
        Manufacturer = "Boston Dynamics",
        PartNumber = "BD-001",
        FileFormat = "IGES",
        ModelType = "3D Model"
    },
    new CADModel
    {
        Id = 10,
        Name = "TALON",
        Category = "Military Robots",
        Dimensions = "1.0m x 0.6m x 0.4m",
        Weight = "30 kg",
        Material = "Aluminum",
        Color = "Camo",
        Manufacturer = "QinetiQ North America",
        PartNumber = "TAL-01",
        FileFormat = "STEP",
        ModelType = "3D Model"
    },
    new CADModel
    {
        Id = 11,
        Name = "FANUC R-2000iC",
        Category = "Industrial Robots",
        Dimensions = "2.0m x 1.4m x 2.3m",
        Weight = "280 kg",
        Material = "Steel",
        Color = "Yellow",
        Manufacturer = "FANUC",
        PartNumber = "R2000-IC",
        FileFormat = "STL",
        ModelType = "3D Model"
    },
    new CADModel
    {
        Id = 12,
        Name = "Yaskawa Motoman HC20DT",
        Category = "Industrial Robots",
        Dimensions = "1.2m x 0.8m x 1.6m",
        Weight = "25 kg",
        Material = "Aluminum",
        Color = "Orange",
        Manufacturer = "Yaskawa Electric Corporation",
        PartNumber = "HC20DT-01",
        FileFormat = "STEP",
        ModelType = "3D Model"
    },
    new CADModel
    {
        Id = 13,
        Name = "Versius",
        Category = "Medical Robots",
        Dimensions = "1.2m x 0.9m x 1.8m",
        Weight = "70 kg",
        Material = "Titanium",
        Color = "Silver",
        Manufacturer = "Intuitive Surgical",
        PartNumber = "VERS-01",
        FileFormat = "STL",
        ModelType = "3D Model"
    },
    new CADModel
    {
        Id = 14,
        Name = "ROSATM",
        Category = "Medical Robots",
        Dimensions = "3.0m x 1.5m x 1.2m",
        Weight = "200 kg",
        Material = "Steel, Plastic",
        Color = "White",
        Manufacturer = "Accuray",
        PartNumber = "ROSA-01",
        FileFormat = "IGES",
        ModelType = "3D Model"
    },
    new CADModel
    {
        Id = 15,
        Name = "SWORDS",
        Category = "Military Robots",
        Dimensions = "1.2m x 0.9m x 1.5m",
        Weight = "40 kg",
        Material = "Aluminum, Titanium",
        Color = "Gray",
        Manufacturer = "DARPA",
        PartNumber = "SW-01",
        FileFormat = "STEP",
        ModelType = "3D Model"
    }
};
    }
    }
