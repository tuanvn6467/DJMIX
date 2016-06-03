using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GracenoteSDK;

namespace MusicIdentification.Utilities
{
    public static class Utils
    {
        public static string ReplaceSpecialCharacter(this string text)
        {
            return Regex.Replace(text, "[^0-9a-zA-Z]+", "");
        }

        public static GnFingerprintType GetFingerprintType(int type)
        {
            var result = GnFingerprintType.kFingerprintTypeStream3;
            switch (type)
            {
                case (int)FingerprintEnum.File:
                    result = GnFingerprintType.kFingerprintTypeFile;
                    break;
                case (int)FingerprintEnum.ThreeSeconds:
                    result = GnFingerprintType.kFingerprintTypeStream3;
                    break;
                case (int)FingerprintEnum.SixSeconds:
                    result = GnFingerprintType.kFingerprintTypeStream6;
                    break;
                default:
                    break;
            }
            return result;
        }
        public static int GetFingerprintInteger(int type)
        {
            var result = 3;
            switch (type)
            {
                case (int)FingerprintEnum.File:
                    result = 9;
                    break;
                case (int)FingerprintEnum.ThreeSeconds:
                    result = 3;
                    break;
                case (int)FingerprintEnum.SixSeconds:
                    result = 6;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
