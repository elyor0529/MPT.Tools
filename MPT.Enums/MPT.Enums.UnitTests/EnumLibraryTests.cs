using System;
using System.Collections.Generic;
using cm = System.ComponentModel;
using xmlS = System.Xml.Serialization;

using NUnit.Framework;


namespace MPT.Enums.UnitTests
{
    [TestFixture]
    public class EnumLibraryTests
    {
        public enum EnumWithDescription
        {
             [cm.Description("Error Enum")] errorEnum = 0,
             [cm.Description("First Enum")] firstEnum,
             [cm.Description("")] secondEnum
        }

        public enum EnumWithAttribute
        {
            [xmlS.XmlEnumAttribute("Error Enum")] errorEnum = 0,
            [xmlS.XmlEnumAttribute("First Enum")] firstEnum,
            [xmlS.XmlEnumAttribute("")] secondEnum
        }

        public enum EnumWithoutDescription
        {
            errorEnum = 1,
            firstEnum,
            secondEnum,
        }


        [TestCase(EnumWithDescription.errorEnum, ExpectedResult = "Error Enum")]
        [TestCase(EnumWithDescription.firstEnum, ExpectedResult ="First Enum" )]
        [TestCase(EnumWithDescription.secondEnum, ExpectedResult = "")]
        [TestCase(3, ExpectedResult = "")] // Using Enum outside of range
        public string GetEnumDescription_of_Enum_with_Description_Returns_Matching_Description(EnumWithDescription enumToCheck)
        {
            return EnumLibrary.GetEnumDescription(enumToCheck);
        }

        [TestCase(EnumWithoutDescription.errorEnum, ExpectedResult = "errorEnum")]
        [TestCase(EnumWithoutDescription.firstEnum, ExpectedResult = "firstEnum")]
        [TestCase(EnumWithoutDescription.secondEnum, ExpectedResult = "secondEnum")]
        public string GetEnumDescription_of_Enum_without_Description_Returns_Matching_Enum_as_String(EnumWithoutDescription enumToCheck)
        {
            return EnumLibrary.GetEnumDescription(enumToCheck);
        }


        [TestCase("Error Enum", ExpectedResult = EnumWithDescription.errorEnum)]
        [TestCase("First Enum", ExpectedResult = EnumWithDescription.firstEnum)]
        [TestCase("", ExpectedResult = EnumWithDescription.secondEnum)]
        public EnumWithDescription ConvertStringToEnumByDescription_of_Existing_Enum_with_Description_Returns_Matching_Enum(string enumName)
        {
            return EnumLibrary.ConvertStringToEnumByDescription<EnumWithDescription>(enumName);
        }

        [Test]
        public void ConvertStringToEnumByDescription_of_Nonexisting_Enum_with_Description_Returns_FirstEnum()
        {
            EnumWithDescription expectedEnum = 0;
            EnumWithDescription testEnum = EnumLibrary.ConvertStringToEnumByDescription<EnumWithDescription>("nonexistentEnum");
            Assert.AreEqual(expectedEnum, testEnum);
        }


        [TestCase("errorEnum", ExpectedResult = EnumWithoutDescription.errorEnum)]
        [TestCase("firstEnum", ExpectedResult = EnumWithoutDescription.firstEnum)]
        [TestCase("secondEnum", ExpectedResult = EnumWithoutDescription.secondEnum)]
        public EnumWithoutDescription ConvertStringToEnumByDescription_of_Existing_Enum_without_Description_Returns_Matching_Enum(string enumName)
        {
            return EnumLibrary.ConvertStringToEnumByDescription<EnumWithoutDescription>(enumName);
        }


        [Test]
        public void ConvertStringToEnumByDescription_of_Nonexisting_Enum_without_Description_Returns_FirstEnum()
        {
            EnumWithoutDescription expectedEnum = 0;
            EnumWithoutDescription testEnum = EnumLibrary.ConvertStringToEnumByDescription<EnumWithoutDescription>("nonexistentEnum");
            Assert.AreEqual(expectedEnum, testEnum);
        }

        private const string enumListWithoutDescriptionExpected = "errorEnum, firstEnum, secondEnum";

        [TestCase(EnumWithoutDescription.errorEnum, ExpectedResult = enumListWithoutDescriptionExpected)]
        [TestCase(EnumWithoutDescription.firstEnum, ExpectedResult = enumListWithoutDescriptionExpected)]
        [TestCase(EnumWithoutDescription.secondEnum, ExpectedResult = enumListWithoutDescriptionExpected)]
        public string GetEnumDescriptionList_of_Enum_without_Descriptions_Returns_Matching_List(EnumWithoutDescription anyEnum)
        {
            List<string> enumList = EnumLibrary.GetEnumDescriptionList(anyEnum);
            string resultingList = "";
            int i = 0;
            foreach (string enumName in enumList)
            {
                resultingList += enumName;
                if (i < enumList.Count - 1)
                {
                    resultingList += ", ";
                }
                i++;
            }
            return resultingList;
        }
        
        private const string enumListDescriptionExpected = "Error Enum, First Enum, ";

        [TestCase(EnumWithDescription.errorEnum, ExpectedResult = enumListDescriptionExpected)]
        [TestCase(EnumWithDescription.firstEnum, ExpectedResult = enumListDescriptionExpected)]
        [TestCase(EnumWithDescription.secondEnum, ExpectedResult = enumListDescriptionExpected)]
        [TestCase(3, ExpectedResult = enumListDescriptionExpected)] // Choosing enum outside of range
        public string GetEnumDescriptionList_of_Enum_with_Descriptions_Returns_Matching_List(EnumWithDescription anyEnum)
        {
            List<string> enumList = EnumLibrary.GetEnumDescriptionList(anyEnum);
            string resultingList = "";
            int i = 0;
            foreach (string enumName in enumList)
            {
                resultingList += enumName;
                if (i < enumList.Count - 1)
                {
                    resultingList += ", ";
                }
                i++;
            }
            return resultingList;
        }

        [TestCase(EnumWithAttribute.errorEnum, ExpectedResult = "Error Enum")]
        [TestCase(EnumWithAttribute.firstEnum, ExpectedResult = "First Enum")]
        [TestCase(EnumWithAttribute.secondEnum, ExpectedResult = "")]
        public string GetEnumXMLAttribute_of_Enum_with_Attribute_Returns_Matching_Description(EnumWithAttribute enumToCheck)
        {
            return EnumLibrary.GetEnumXMLAttribute(enumToCheck);
        }

        [TestCase(EnumWithoutDescription.errorEnum, ExpectedResult = "errorEnum")]
        [TestCase(EnumWithoutDescription.firstEnum, ExpectedResult = "firstEnum")]
        [TestCase(EnumWithoutDescription.secondEnum, ExpectedResult = "secondEnum")]
        public string GetEnumXMLAttribute_of_Enum_without_Attribute_Returns_Matching_ToString(EnumWithoutDescription enumToCheck)
        {
            return EnumLibrary.GetEnumXMLAttribute(enumToCheck);
        }

        [TestCase("Error Enum", ExpectedResult = EnumWithAttribute.errorEnum)]
        [TestCase("First Enum", ExpectedResult = EnumWithAttribute.firstEnum)]
        [TestCase("", ExpectedResult = EnumWithAttribute.secondEnum)]
        public EnumWithAttribute ConvertStringToEnumByXMLAttribute_of_Existing_Enum_with_Attribute_Returns_Matching_Enum(
            string enumName)
        {
            return EnumLibrary.ConvertStringToEnumByXMLAttribute<EnumWithAttribute>(enumName);
        }

        [Test]
        public void ConvertStringToEnumByXMLAttribute_of_Nonexisting_Enum_with_Attribute_Returns_FirstEnum()
        {
            EnumWithAttribute expectedEnum = 0;
            EnumWithAttribute testEnum = EnumLibrary.ConvertStringToEnumByXMLAttribute<EnumWithAttribute>("nonexistentEnum");
            Assert.AreEqual(expectedEnum, testEnum);
        }

        [TestCase("errorEnum", ExpectedResult = EnumWithAttribute.errorEnum)]
        [TestCase("firstEnum", ExpectedResult = EnumWithAttribute.errorEnum)]
        [TestCase("seconEnum", ExpectedResult = EnumWithAttribute.errorEnum)]
        public EnumWithAttribute ConvertStringToEnumByXMLAttribute_of_Existing_Enum_without_Attribute_Returns_FirstEnum(
            string enumName)
        {
            return EnumLibrary.ConvertStringToEnumByXMLAttribute<EnumWithAttribute>(enumName);
        }

        [Test]
        public void ConvertStringToEnumByXMLAttribute_of_Nonexisting_Enum_without_Attribute_Returns_FirstEnum()
        {
            EnumWithAttribute expectedEnum = 0;
            EnumWithAttribute testEnum = EnumLibrary.ConvertStringToEnumByXMLAttribute<EnumWithAttribute>("nonexistentEnum");
            Assert.AreEqual(expectedEnum, testEnum);
        }

        [Test]
        public void GetListItemMatchingEnumByXMLAttribute_of_No_Matching_Item_Returns_Empty_String()
        {
            string expectedResult = "";
            List<string> nonMatchingEnumItems = new List<string>() {"Foo", "Bar", "Fie", "Fo", "Last Enum"};
            string actualItem = EnumLibrary.GetListItemMatchingEnumByXMLAttribute(EnumWithAttribute.firstEnum, nonMatchingEnumItems);

            Assert.AreEqual(expectedResult, actualItem);
        }

        [Test]
        public void GetListItemMatchingEnumByXMLAttribute_of_Matching_Item_Returns_Matching_Item()
        {
            string matchingItem = "First Enum";
            List<string> enumItems = new List<string>() { "Foo", "Bar", "Fie", matchingItem, "Last Enum" };
            string actualItem = EnumLibrary.GetListItemMatchingEnumByXMLAttribute(EnumWithAttribute.firstEnum, enumItems);

            Assert.AreEqual(matchingItem, actualItem);
        }

       
    }
}
