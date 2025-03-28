//  Authors:    Robert M. Scheller, James B. Domingo

using Landis.Utilities;
using System.Collections.Generic;

namespace Landis.Extension.Hurricane
{
	/// <summary>
	/// Parameters for the plug-in.
	/// </summary>
	public class InputParameters
		: IInputParameters
	{
		private int timestep;
        private string mapNamesTemplate;
		private string logFileName;

		//---------------------------------------------------------------------

		/// <summary>
		/// Timestep (years)
		/// </summary>
		public int Timestep
		{
			get {
				return timestep;
			}
            set {
                if (value < 0)
                    throw new InputValueException(value.ToString(),
                                                      "Value must be = or > 0.");
                timestep = value;
            }
		}

        public List<double> StormOccurenceProbabilities { get; set; }
        public List<IWindSpeedModificationTable> WindSpeedModificationTable { get; set; }

        public double LowBoundLandfallWindSpeed { get; set; }
        public double ModeLandfallWindSpeed { get; set; }
        public double HighBoundLandfallWindspeed { get; set; }
        //public double LandfallLatitudeMean { get; set; }
        //public double LandfallLatitudeStdDev { get; set; }
        public double StormDirectionMu { get; set; }
        public double StormDirectionSigma { get; set; }

        public double LandFallSigma { get; set; }

        public double CoastalCenterX { get; set; }
        public double CoastalCenterY { get; set; }
        public double CoastalSlope { get; set; }

        //public double CenterPointLatitude { get; set; }
        //public double CenterPointDistanceInland { get; set; }
        public double minimumWSforDamage { get; set; } = 96.5;

        public Dictionary<string, Dictionary<double, Dictionary<double, double>>> WindSpeedMortalityProbabilities { get; set; }
		public Dictionary<int, string> WindExposureMaps { get; set; }

		public bool InputUnitsEnglish { get; set; } = false;

        public int HurricaneRandomNumberSeed { get; set; } = -999;

        //---------------------------------------------------------------------

		/// <summary>
		/// Template for the filenames for output maps.
		/// </summary>
		public string MapNamesTemplate
		{
			get {
				return mapNamesTemplate;
			}
            set {
                MapNames.CheckTemplateVars(value);
                mapNamesTemplate = value;
            }
		}

		//---------------------------------------------------------------------

		/// <summary>
		/// Name of log file.
		/// </summary>
		public string LogFileName
		{
			get {
				return logFileName;
			}
            set {
                if (value == null)
                    throw new InputValueException(value.ToString(), "Value must be a file path.");
                logFileName = value;
            }
		}

        //---------------------------------------------------------------------

        public InputParameters() 
        {
        }
	}
}
