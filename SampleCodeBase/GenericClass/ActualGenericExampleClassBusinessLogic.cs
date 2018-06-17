using System;
using System.Collections.Generic;

namespace SampleCodeBase.GenericClass
{
    /// <summary>
    /// How the classes are being called or created in the actual business scenario.
    /// </summary>
    public class ActualGenericExampleClassBusinessLogic
    {
        private IRequired<string> _requiredString;

        public ActualGenericExampleClassBusinessLogic(IRequired<string> requiredString)
        {
            _requiredString = requiredString;
        }

        public void SampleCreateExampleOfRequired()
        {
            var r1 = new RequiredClass<string>(_requiredString);
            var r2 = new RequiredClass<RequiredClass<string>>(r1);

            r2.TempMethod(r1);
        }

        public void SampleCreateExampleOfComplexRequiredGenericClass()
        {
            var r1 = new RequiredClass<string>(_requiredString);

            // So if I want to create ComplexRequiredGenericClass with Business Value , it needs to follow these steps
            var r2 = new ComplexRequiredGenericClass<RequiredClass<string>>(r1);

            // Business value for ComplexMethod
            r2.ComplexMethod(r1, "Hello World");
            r2.ComplexMethod(r1, "HelloXXTW World");
            r2.ComplexMethod(r1.T1Type.T1Type.T1Type, "HelloXXXX World");
        }

        public void SampleCreateExampleOfGenericExampleClassBusinessValueForComplexNumber2()
        {
            // observe how the "ComplexNumber2" is called.
            // So to test ComplexNumber2 with business value
            var genericExampleClass = new GenericExampleClass<RequiredClass<string>,
                                                              RequiredClass<string>,
                                                              DateTime,
                                                              ComplexRequiredGenericClass2<RequiredClass<string>>>();

            // So to call ComplexNumber2 with business value above steps needs to setup with fakes.
            var x = genericExampleClass.ComplexNumber2;
        }

        public void SampleCreateExampleOfGenericExampleClassForComplexByteArray()
        {
            var r1 = new RequiredClass<string>(_requiredString);
            var genericExampleClass = new GenericExampleClass<RequiredClass<string>,
                    RequiredClass<string>,
                    DateTime,
                    ComplexRequiredGenericClass2<RequiredClass<string>>>(r1, DateTime.Now);

            // So to call ComplexByteArray with business value above steps needs to setup with fakes.
            var x = genericExampleClass.ComplexByteArray;
        }

        public void SampleCreateExampleOfGenericExampleClassForComplexDictionaryItemPopulate()
        {
            var r1 = new RequiredClass<string>(_requiredString);

            var genericExampleClass = new GenericExampleClass<RequiredClass<string>,
                    RequiredClass<string>,
                    DateTime,
                    ComplexRequiredGenericClass2<RequiredClass<string>>>(5);

            var complexRequired = new ComplexRequiredGenericClass2<RequiredClass<string>>(r1, r1, null);
            var newDictionary = new Dictionary<int, ComplexRequiredGenericClass2<RequiredClass<string>>>();

            newDictionary.Add(51100, complexRequired);
            newDictionary.Add(51101, complexRequired);
            newDictionary.Add(0, complexRequired);
            newDictionary.Add(1, complexRequired);

            // So to call ComplexDictionaryItemPopulate with business value above steps needs to setup with fakes.
            genericExampleClass.ComplexDictionaryItemPopulate(newDictionary, complexRequired, complexRequired);
        }

        public void SampleCreateExampleOfGenericExampleClassForCreateT1()
        {
            var genericExampleClass = new GenericExampleClass<RequiredClass<string>,
                    RequiredClass<string>,
                    DateTime,
                    ComplexRequiredGenericClass2<RequiredClass<string>>>(5);

            // So to call CreateT1 with business value above steps needs to setup with fakes.
            var x = genericExampleClass.CreateT1();
        }

        public void SampleCreateExampleOfGenericExampleClassForCreateT3()
        {
            var genericExampleClass = new GenericExampleClass<RequiredClass<string>,
                    RequiredClass<string>,
                    DateTime,
                    ComplexRequiredGenericClass2<RequiredClass<string>>>(5);

            // So to call CreateT1 with business value above steps needs to setup with fakes.
            var x = genericExampleClass.CreateT3();
        }

        public void BusinessLogicWiseCalledContainsRequiredMethod3()
        {
            var t5 = new RequiredStringMethod3();
            // So to call ContainsRequiredMethod3 with business value above steps needs to setup with fakes.
            t5.ContainsRequiredMethod3();
        }
    }
}
