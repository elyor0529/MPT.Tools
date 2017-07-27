using System;
using MPT.CSI.API.Core.Program.ModelBehavior;
using MPT.CSI.API.Core.Program.ModelBehavior.Definition;
using MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property;
#if BUILD_SAP2000v16
using CSiProgram = SAP2000v16;
#elif BUILD_SAP2000v17
using CSiProgram = SAP2000v17;
#elif BUILD_SAP2000v18
using CSiProgram = SAP2000v18;
#elif BUILD_SAP2000v19
using CSiProgram = SAP2000v19;
#elif BUILD_CSiBridgev18
using CSiProgram = CSiBridge18;
#elif BUILD_CSiBridgev19
using CSiProgram = CSiBridge19;
#elif BUILD_ETABS2013
using CSiProgram = ETABS2013;


#elif BUILD_ETABS2015
using CSiProgram = ETABS2015;
#elif BUILD_ETABS2016
using CSiProgram = ETABS2016;
#endif

namespace MPT.CSI.API.Core.Support
{
    /// <summary>
    /// Converts enumerations between those used in this library and those used in the CSi program supported by a given compilation.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    internal class CSiEnumConverter
    {
        // eItemType
        internal static CSiProgram.eItemType ToCSi(eItemType enumValue)
        {
            return (CSiProgram.eItemType)enumValue;
        }

        internal static eItemType FromCSi(CSiProgram.eItemType enumValue)
        {
            return (eItemType)enumValue;
        }

        // eItemTypeElement
        internal static CSiProgram.eItemTypeElm ToCSi(eItemTypeElement enumValue)
        {
            return (CSiProgram.eItemTypeElm)enumValue;
        }

        internal static eItemTypeElement FromCSi(CSiProgram.eItemTypeElm enumValue)
        {
            return (eItemTypeElement)enumValue;
        }

        // eUnits
        internal static CSiProgram.eUnits ToCSi(eUnits enumValue)
        {
            return (CSiProgram.eUnits)enumValue;
        }

        internal static eUnits FromCSi(CSiProgram.eUnits enumValue)
        {
            return (eUnits)enumValue;
        }

        // eLoadPatternType
        internal static CSiProgram.eLoadPatternType ToCSi(eLoadPatternType enumValue)
        {
            return (CSiProgram.eLoadPatternType)enumValue;
        }

        internal static eLoadPatternType FromCSi(CSiProgram.eLoadPatternType enumValue)
        {
            return (eLoadPatternType)enumValue;
        }

        // eLoadCaseType
        internal static CSiProgram.eLoadCaseType ToCSi(eLoadCaseType enumValue)
        {
            return (CSiProgram.eLoadCaseType)enumValue;
        }

        internal static eLoadCaseType FromCSi(CSiProgram.eLoadCaseType enumValue)
        {
            return (eLoadCaseType)enumValue;
        }

        // eLoadCaseType
        internal static CSiProgram.eCNameType ToCSi(eCaseComboType enumValue)
        {
            return (CSiProgram.eCNameType)enumValue;
        }

        internal static eCaseComboType FromCSi(CSiProgram.eCNameType enumValue)
        {
            return (eCaseComboType)enumValue;
        }

        // eConstraintType
        internal static CSiProgram.eConstraintType ToCSi(eConstraintType enumValue)
        {
            return (CSiProgram.eConstraintType)enumValue;
        }

        internal static eConstraintType FromCSi(CSiProgram.eConstraintType enumValue)
        {
            return (eConstraintType)enumValue;
        }


        // eConstraintAxis
        internal static CSiProgram.eConstraintAxis ToCSi(eConstraintAxis enumValue)
        {
            return (CSiProgram.eConstraintAxis)enumValue;
        }

        internal static eConstraintAxis FromCSi(CSiProgram.eConstraintAxis enumValue)
        {
            return (eConstraintAxis)enumValue;
        }

        // eFrameType
        internal static CSiProgram.eFramePropType ToCSi(eFrameSectionType enumValue)
        {
            return (CSiProgram.eFramePropType)enumValue;
        }

        internal static eFrameSectionType FromCSi(CSiProgram.eFramePropType enumValue)
        {
            return (eFrameSectionType)enumValue;
        }

        // eLinkType
        internal static CSiProgram.eLinkPropType ToCSi(eLinkPropertyType enumValue)
        {
            return (CSiProgram.eLinkPropType)enumValue;
        }

        internal static eLinkPropertyType FromCSi(CSiProgram.eLinkPropType enumValue)
        {
            return (eLinkPropertyType)enumValue;
        }

        // eMaterialPropertyType
        internal static CSiProgram.eMatType ToCSi(eMaterialPropertyType enumValue)
        {
            return (CSiProgram.eMatType)enumValue;
        }

        internal static eMaterialPropertyType FromCSi(CSiProgram.eMatType enumValue)
        {
            return (eMaterialPropertyType)enumValue;
        }
    }
}
